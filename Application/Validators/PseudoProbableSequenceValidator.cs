using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class PseudoProbableSequenceValidator : AbstractValidator<PseudoProbableSequenceQuantity>
    {
        public PseudoProbableSequenceValidator()
        {
            #region Quantity
            
            RuleFor(r => r.Qty).LessThanOrEqualTo(16).WithMessage("The number of sequences generated must not exceed 16");

            #endregion
        }
    }
}
