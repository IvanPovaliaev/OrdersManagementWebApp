using System;

namespace OrdersManagement.Application.Models
{
    public record class ShortOrderInfoViewModel
    {
        public Guid Id { get; init; }
        public required string SenderCity { get; init; }
        public required string RecipientCity { get; init; }
        public required double Weight { get; init; }
        public required DateTime ExpirationDate { get; init; }
    }
}
