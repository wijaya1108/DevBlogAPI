using DevBlog.BusinessLogic.DTO.Requests;
using FluentValidation;

namespace DevBlog.Validators
{
    public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
    {
        public UserCreateRequestValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
