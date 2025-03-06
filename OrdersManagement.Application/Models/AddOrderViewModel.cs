using OrdersManagement.Application.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrdersManagement.Application.Models
{
    public class AddOrdersViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public string SenderCity { get; init; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string SenderAddress { get; init; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string RecipientCity { get; init; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string RecipientAddress { get; init; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Значение должно быть больше 0")]
        public double Weight { get; init; }

        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Date)]
        [ExpirationDateValidation(3)]
        public DateTime ExpirationDate { get; set; }
    }
}
