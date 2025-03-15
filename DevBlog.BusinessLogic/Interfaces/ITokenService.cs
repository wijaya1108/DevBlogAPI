﻿using DevBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
