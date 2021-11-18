using FluentValidation;

namespace CustomerManagement.Service.Models
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CustomerValidator()
        {
            RuleFor(m => m.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Firstname is required");


            RuleFor(m => m.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lastname is required");


            RuleFor(m => m.Password)
              .NotEmpty()
              .NotNull()
              .WithMessage("Password  is required");

            RuleFor(m => m.PhoneNumber)
              .NotEmpty()
              .NotNull()
              .WithMessage("Mobile  is required");

            

            RuleFor(m => m.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MaximumLength(100).WithMessage("Email must be valid email address");

        }
    }
}
