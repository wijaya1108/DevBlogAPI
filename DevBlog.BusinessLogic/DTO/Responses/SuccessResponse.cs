using DevBlog.BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.DTO.Responses
{
    public class SuccessResponse
    {
        public bool Success { get; set; }
        public StatusCodes StatusCode { get; set; }
        public object? Data { get; set; }
        public List<string>? ErrorList { get; set; }

        public SuccessResponse()
        {
            Success = true;
            StatusCode = StatusCodes.Success;
            ErrorList = new List<string>();
        }
    }
}
