using System;

namespace OrdersManagement.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; init; }
        public required string SenderCity { get; init; }
        public required string SenderAddress { get; init; }
        public required string RecipientCity { get; init; }
        public required string RecipientAddress { get; init; }
        public required int Weight { get; init; }
        public required DateTime ExpirationDate { get; set; }
    }
}
