﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Commands.CreateUser
{
    public class CreateUserCommandResponse
    {
        public  bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}