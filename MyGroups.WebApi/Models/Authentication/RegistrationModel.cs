using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroups.WebApi.Models.Authentication
{
    public class RegistrationModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
}
