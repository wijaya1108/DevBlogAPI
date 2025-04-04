﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.DTO.Responses
{
    public record UserResponse(
            int Id,
            string FirstName,
            string? LastName,
            string Email
        );
}
