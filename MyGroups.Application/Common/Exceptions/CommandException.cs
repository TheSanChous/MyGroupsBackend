﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.Common.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException(string message) 
            : base($"Command error. {message}.")
        {
        }
    }
}
