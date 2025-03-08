using DevBlog.BusinessLogic.DTO.Requests;
using FluentValidation;

namespace DevBlog.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty()
                .WithMessage("Email is required");

            RuleFor(m => m.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
