using DevBlog.BusinessLogic.DTO.Requests;
using FluentValidation;

namespace DevBlog.Validators
{
    public class BlogCreateRequestValidator : AbstractValidator<BlogCreateRequest>
    {
        public BlogCreateRequestValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage("Title is required");

            RuleFor(m => m.UserId)
                .NotEmpty()
                .WithMessage("User Id is required");
        }
    }
}
