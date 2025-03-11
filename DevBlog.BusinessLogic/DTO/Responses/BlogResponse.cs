using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.BusinessLogic.DTO.Responses
{
    public record BlogResponse(
        int Id,
        string Title,
        string? Content,
        DateTime CreatedOn,
        DateTime? ModifiedOn,
        bool IsDeleted,
        int UserId,
        string UserFirstName,
        string? UserLastName);
}
