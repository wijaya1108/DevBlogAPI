using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.DTO.Responses
{
    public record BlogCreateResponse(
        int Id,
        string Title,
        string? Content,
        int UserId,
        DateTime CreatedOn,
        DateTime? ModifiedOn,
        bool IsDeleted
        );
}
