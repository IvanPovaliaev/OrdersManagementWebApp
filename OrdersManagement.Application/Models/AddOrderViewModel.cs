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

        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше 0")]
        public double Weight { get; init; }

        [Required(ErrorMessage = "Обязательное поле")]
        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(3).Date;
    }
}
