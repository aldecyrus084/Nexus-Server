using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.Features.Customer.Create
{
    public class CreateCustomerValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(150)
                .WithMessage("Name must not exceed 150 characters.");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required.")
                .MinimumLength(4)
                .WithMessage("Username must be at least 4 characters.")
                .MaximumLength(50)
                .WithMessage("Username must not exceed 50 characters.")
                .Matches("^[a-zA-Z0-9_.-]+$")
                .WithMessage("Username can only contain letters, numbers, underscores, dots, and hyphens.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters.")
                .MaximumLength(100)
                .WithMessage("Password must not exceed 100 characters.");

            RuleFor(x => x.IpAddress)
                .Must(ip => System.Net.IPAddress.TryParse(ip, out _))
                .When(x => !string.IsNullOrWhiteSpace(x.IpAddress))
                .WithMessage("Invalid IP address.");
        }
    }
}
