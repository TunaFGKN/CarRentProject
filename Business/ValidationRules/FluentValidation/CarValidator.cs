using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarDescription).NotEmpty();
            RuleFor(p => p.CarDescription).MinimumLength(2);
            RuleFor(p => p.CarDailyPrice).NotEmpty();
            RuleFor(p => p.CarDailyPrice).GreaterThan(0);
            RuleFor(p => p.CarDailyPrice).GreaterThanOrEqualTo(9999999).When(p => p.CarBrandId == 1);
        }
    }
}
