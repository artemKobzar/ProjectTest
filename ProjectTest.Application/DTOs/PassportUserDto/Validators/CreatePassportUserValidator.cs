using FluentValidation;
using ProjectTest.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.DTOs.PassportUserDto.Validators
{
    public class CreatePassportUserValidator: AbstractValidator<CreatePassportUserDto>
    {
        public CreatePassportUserValidator() 
        {
            RuleFor(p => p.Gender).NotEmpty().WithMessage("{PropertyName} is required").Length(4, 6).WithMessage("{PropertyName} must not exceed 6 characters").NotNull();
            RuleFor(p => p.Nationality).NotEmpty().WithMessage("{PropertyName} is required").Length(1, 30).WithMessage("{PropertyName} must not exceed 30 characters").NotNull();
            RuleFor(p => p.ValidDate).NotEmpty().WithMessage("{PropertyName} is required").Must(ValidDate).WithMessage("{PropertyName} must have format: yyyy-MM-dd").NotNull();
            RuleFor(p => p.UserId).NotEmpty().WithMessage("{PropertyName} is required").WithMessage("{PropertyName} must not exceed 200 characters").NotNull();

        }
        
        protected bool ValidDate(DateOnly date)
        {
            DateOnly parsedDate;
            string format = "yyyy-MM-dd";
            string inputDate = date.ToString();
            if (DateOnly.TryParseExact(inputDate, format, null, DateTimeStyles.None, out parsedDate))
            { return true; }
            else { return false; }
        }

    }
}
