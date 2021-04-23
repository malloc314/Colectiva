using Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class PseudoProbableSequencePostValidator : AbstractValidator<PseudoProbableSequenceDto>
    {
        public PseudoProbableSequencePostValidator()
        {
            #region First
            RuleFor(r => (int)r.First).ExclusiveBetween(1, 50).WithMessage("The first number of sequence must exclusive between 1, 50");
            #endregion

            #region Second
            RuleFor(r => (int)r.Second).ExclusiveBetween(1, 50).WithMessage("The second number of sequence must exclusive between 1, 50");
            #endregion

            RuleFor(r => (int)r.Thrid).ExclusiveBetween(1, 50).WithMessage("The thrid number of sequence must exclusive between 1, 50");
            RuleFor(r => (int)r.Fourth).ExclusiveBetween(1, 50).WithMessage("The fourth number of sequence must exclusive between 1, 50");
            RuleFor(r => (int)r.Fifth).ExclusiveBetween(1, 50).WithMessage("The fifth number of sequence must exclusive between 1, 50");
            RuleFor(r => (int)r.Sixth).ExclusiveBetween(1, 10).WithMessage("The sixth number of sequence must exclusive between 1, 10");
            RuleFor(r => (int)r.Seventh).ExclusiveBetween(1, 10).WithMessage("The seventh number of sequences must exclusive between 1, 10");

        }
    }
}