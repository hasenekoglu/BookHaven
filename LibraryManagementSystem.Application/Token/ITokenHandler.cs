﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Token
{
    public interface ITokenHandler
    { 
        Dtos.Token CreateAccessToken(int minute);

    }
}
