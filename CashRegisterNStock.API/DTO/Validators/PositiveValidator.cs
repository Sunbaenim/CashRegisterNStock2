using System;
using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.API.DTO.Validators
{
    public class PositiveValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is null) throw new ArgumentNullException();

            if (!decimal.TryParse(value.ToString(), out decimal number)) throw new Exception("Value is not a number");

            return number > 0;
        }
    }
}
