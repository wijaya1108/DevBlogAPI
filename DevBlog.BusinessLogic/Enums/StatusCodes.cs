using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.Enums
{
    public enum StatusCodes
    {
        Success = 200,
        Created = 201,
        BadRequest = 400,
        NotFound = 404,
        InternalServerError = 500
    }
}
