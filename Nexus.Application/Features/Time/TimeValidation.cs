using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Application.Features.AddTime
{
    public class TimeValidation : AbstractValidator<TimeCommand>
    {
        public TimeValidation()
        {
            RuleFor(x => x.PCId)
                .NotEmpty()
                .WithMessage("PC ID is required.");

            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer ID is required.");

            RuleFor(x => x.AmountInserted)
                .GreaterThan(0)
                .WithMessage("Amount must be greater than 0.");
        }
    }
}
