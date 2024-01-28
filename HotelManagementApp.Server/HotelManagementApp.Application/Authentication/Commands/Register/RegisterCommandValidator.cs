using FluentValidation;
using HotelManagementApp.Application.Authentication.Register.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementApp.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        { 
            RuleFor(x=> x.FirstName).NotEmpty();
            RuleFor(x=> x.LastName).NotEmpty();
            RuleFor(x=> x.Email).NotEmpty().EmailAddress();
            RuleFor(x=> x.Password).NotEmpty();
        }

    }
}
