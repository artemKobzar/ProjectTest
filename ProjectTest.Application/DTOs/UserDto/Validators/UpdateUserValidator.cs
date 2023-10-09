using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Application.DTOs.UserDto.Validators
{
    public class UpdateUserValidator : AbstractValidator<UserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("{PropertyName} is required").Length(1, 30).WithMessage("{PropertyName} must not exceed 30 characters").NotNull();
            RuleFor(u => u.LastName).NotEmpty().WithMessage("{PropertyName} is required").Length(1, 30).WithMessage("{PropertyName} must not exceed 30 characters").NotNull();
            RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("{PropertyName} is required").Length(1, 30).WithMessage("{PropertyName} must not exceed 30 characters").NotNull();
            RuleFor(u => u.Address).NotEmpty().WithMessage("{PropertyName} is required").Length(1, 200).WithMessage("{PropertyName} must not exceed 200 characters").NotNull();
            RuleFor(u => u.Email).EmailAddress().NotEmpty().WithMessage("{PropertyName} is required").Length(1, 200).WithMessage("{PropertyName} must not exceed 200 characters").NotNull();
        }
    }
}