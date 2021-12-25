using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyGroups.Application.Common.Exceptions;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.Application.Models.Users.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IConfiguration configuration;

        public LoginUserCommandHandler(IDatabaseContext databaseContext, IConfiguration configuration)
        {
            this.databaseContext = databaseContext;
            this.configuration = configuration;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await databaseContext.Users
                .SingleOrDefaultAsync(user => user.Email == request.Email, cancellationToken);

            if (user is null)
            {
                throw new NotFoundException(nameof(User), request.Email);
            }

            if (user.HashedPassword != CreatePasswordHash(request.Password, user.Salt))
            {
                throw new AuthenticationException("Wrong password");
            }

            return CreateUserAccessToken(user);
        }

        private string CreatePasswordHash(string password, byte[] salt)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] passwordAndSalt = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();

            byte[] hashedPassword = sha256.ComputeHash(passwordAndSalt);

            return Encoding.UTF8.GetString(hashedPassword);
        }

        private string CreateUserAccessToken(User user)
        {
            var lifetimeString = configuration["Authentication:Lifetime"];

            var lifetime = TimeSpan.FromHours(double.Parse(lifetimeString));

            var key = configuration.GetSection("Authentication:Key").Value;

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Authentication:Issuer"],
                audience: configuration["Authentication:Audience"],
                claims: CreateUserClaims(user),
                notBefore: DateTime.Now,
                expires: DateTime.Now.Add(lifetime),
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IEnumerable<Claim> CreateUserClaims(User user)
        {
            return new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
        }
    }
}
