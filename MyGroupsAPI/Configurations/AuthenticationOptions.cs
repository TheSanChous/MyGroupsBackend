using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroupsAPI.Configurations
{
    public class AuthenticationOptions
    {
        private readonly IConfiguration configuration;

        public string Issuer { get; private set; }
        public string Audience { get; private set; }
        public TimeSpan Lifetime { get; private set; }
        public string Key { get; private set; }

        public AuthenticationOptions(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }

        public void SetDefaultFromConfiguration()
        {
            var defaultAuthenticationOptions = configuration.GetSection("AuthenticationOptions:Default");

            Issuer = defaultAuthenticationOptions.GetValue<string>("Issuer");

            Audience = defaultAuthenticationOptions.GetValue<string>("Audience");

            var lifetimeInMinutes = defaultAuthenticationOptions.GetValue<int>("LifetimeInMinutes");
            Lifetime = TimeSpan.FromMinutes(lifetimeInMinutes);

            Key = defaultAuthenticationOptions.GetValue<string>("Key");
        }
    }
}
