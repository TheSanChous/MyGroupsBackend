using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGroups.Application.Interfaces;
using MyGroups.Domain.Models.Users;
using System.Security.Authentication;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace MyGroups.Application.Models.Users.Commands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IDatabaseContext databaseContext;

        public RegisterUserCommandHandler(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await UserWithEmailExists(request.Email))
            {
                throw new AuthenticationException($"User with email \"{request.Email}\" already exsits");
            }

            var salt = CreateSalt(256);
            var hashedPassword = CreatePasswordHash(request.Password, salt);

            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                HashedPassword = hashedPassword,
                Salt = salt
            };

            await databaseContext.Users.AddAsync(user, cancellationToken);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task<bool> UserWithEmailExists(string email)
        {
            var user = await databaseContext.Users
                .SingleOrDefaultAsync(u => u.Email == email);

            return !(user is null);
        }

        private string CreatePasswordHash(string password, byte[] salt)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] passwordAndSalt = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();

            byte[] hashedPassword = sha256.ComputeHash(passwordAndSalt);

            return Encoding.UTF8.GetString(hashedPassword);
        }

        private byte[] CreateSalt(int size)
        {
            RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[size];
            cryptoServiceProvider.GetBytes(buffer);

            return buffer;
        }
    }
}
