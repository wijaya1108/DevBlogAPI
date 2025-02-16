﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.DTO.Requests
{
    public record UserCreateRequest(
        string FirstName,
        string? LastName,
        string Email,
        string Password
        );
}
