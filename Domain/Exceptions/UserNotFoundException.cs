﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UserNotFoundException : HttpStatusException
    {
        public UserNotFoundException(string message) : base(413, message)
        {
        }
    }
}
