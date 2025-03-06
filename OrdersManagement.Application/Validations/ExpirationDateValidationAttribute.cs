﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OrdersManagement.Application.Validations
{
    public class ExpirationDateValidationAttribute : ValidationAttribute
    {
        private readonly int _minDays;

        public ExpirationDateValidationAttribute(int minDays)
        {
            _minDays = minDays;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date < DateTime.Today.AddDays(_minDays))
                {
                    return new ValidationResult($"Дата не может быть раньше, чем через {_minDays} дня(ей).");
                }
            }
            return ValidationResult.Success;
        }
    }

}
