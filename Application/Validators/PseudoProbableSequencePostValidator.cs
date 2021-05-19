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
            #region 1..50 and 1..10
            RuleFor(r => (int)r.First).ExclusiveBetween(0, 51).WithMessage("The first number of sequence must exclusive between 1, 50");
            RuleFor(r => (int)r.Second).ExclusiveBetween(0, 51).WithMessage("The second number of sequence must exclusive between 1, 50");
            RuleFor(r => (int)r.Thrid).ExclusiveBetween(0, 51).WithMessage("The thrid number of sequence must exclusive between 1, 50");
            RuleFor(r => (int)r.Fourth).ExclusiveBetween(0, 51).WithMessage("The fourth number of sequence must exclusive between 1, 50");
            RuleFor(r => (int)r.Fifth).ExclusiveBetween(0, 51).WithMessage("The fifth number of sequence must exclusive between 1, 50");

            RuleFor(r => (int)r.Sixth).ExclusiveBetween(0, 11).WithMessage("The sixth number of sequence must exclusive between 1, 10");
            RuleFor(r => (int)r.Seventh).ExclusiveBetween(0, 11).WithMessage("The seventh number of sequences must exclusive between 1, 10");
            #endregion

            #region is empty
            RuleFor(r => (int)r.First).NotEmpty().WithMessage("The first number cannot be empty");
            RuleFor(r => (int)r.Second).NotEmpty().WithMessage("The second number cannot be empty");
            RuleFor(r => (int)r.Thrid).NotEmpty().WithMessage("The thrid number cannot be empty");
            RuleFor(r => (int)r.Fourth).NotEmpty().WithMessage("The fourth number cannot be empty");
            RuleFor(r => (int)r.Fifth).NotEmpty().WithMessage("The fifth number cannot be empty");

            RuleFor(r => (int)r.Sixth).NotEmpty().WithMessage("The sixth number cannot be empty");
            RuleFor(r => (int)r.Seventh).NotEmpty().WithMessage("The seventh number cannot be empty");
            #endregion
        }
    }
}