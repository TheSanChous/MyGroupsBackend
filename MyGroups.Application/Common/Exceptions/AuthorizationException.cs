﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.Common.Exceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message)
            : base($"User not authorized. '{message}'") { }
    }
}
