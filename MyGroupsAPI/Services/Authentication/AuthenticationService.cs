using Data;
using Data.Models;
using Microsoft.Extensions.Configuration;
using MyGroupsAPI.Configurations;
using MyGroupsAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using MyGroupsAPI.Exceptions;

namespace MyGroupsAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DatabaseContext databaseContext;
        private readonly AuthenticationOptions authenticationOptions;

        public AuthenticationService(
            DatabaseContext databaseContext,
            AuthenticationOptions authenticationOptions)
        {
            this.databaseContext = databaseContext;
            this.authenticationOptions = authenticationOptions;
            this.authenticationOptions.SetDefaultFromConfiguration();
        }

        public async Task<string> LoginAsync(LoginModel loginModel)
        {
            User user = GetUser(loginModel);

            return GenerateJwt(user);
        }

        public async System.Threading.Tasks.Task RegisterAsync(RegistrationModel registrationModel)
        {
            User user = CreateUser(registrationModel);
            UserSettings userSettings = CreateUserSettings(user);

            user.Settings = userSettings;

            await databaseContext.Users.AddAsync(user);
            await databaseContext.UserSettings.AddAsync(userSettings);

            await databaseContext.SaveChangesAsync();
        }

        private UserSettings CreateUserSettings(User user)
        {
            UserSettings userSettings = new UserSettings
            {
                User = user,
                UserId = user.Id
            };

            return userSettings;
        }

        private User CreateUser(RegistrationModel registrationModel)
        {
            if (ExistUser(registrationModel))
            {
                throw new ServiceException("User exist");
            }

            byte[] salt = GenerateSalt(128);

            User user = new User
            {
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                Email = registrationModel.Email,
                HashedPassword = GetHashedPassword(registrationModel.Password, salt),
                Salt = salt
            };

            return user;
        }

        private bool ExistUser(RegistrationModel registrationModel)
        {
            return databaseContext.Users
                .Where(user => user.Email == registrationModel.Email)
                .Any();
        }

        private User GetUser(LoginModel loginModel)
        {
            User user = databaseContext.Users.SingleOrDefault(user => user.Email == loginModel.Email);

            if(user is null)
            {
                throw new ServiceException("User not found");
            }

            if(!(user.HashedPassword == GetHashedPassword(loginModel.Password, user.Salt)))
            {
                throw new ServiceException("Wrong password");
            }

            return user;
        }

        private string GetHashedPassword(string password, byte[] salt)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] bytePassword = Encoding.UTF8.GetBytes(password);

            bytePassword.ToList().AddRange(salt);

            Console.WriteLine(Encoding.UTF8.GetString(bytePassword));

            byte[] hash = sha256.ComputeHash(bytePassword);

            return Encoding.UTF8.GetString(hash);
        }

        private byte[] GenerateSalt(int length)
        {
            var random = new RNGCryptoServiceProvider();

            byte[] salt = new byte[length];

            random.GetNonZeroBytes(salt);

            return salt;
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            return new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
            };
        }

        private string GenerateJwt(User user)
        {
            var token = new JwtSecurityToken(
                issuer: authenticationOptions.Issuer,
                audience: authenticationOptions.Audience,
                claims: GetClaims(user),
                expires: DateTime.Now.Add(authenticationOptions.Lifetime),
                signingCredentials: new SigningCredentials(
                    authenticationOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256
                    )
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
