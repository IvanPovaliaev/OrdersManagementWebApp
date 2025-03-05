namespace OrdersManagement.Domain
{
    public record struct Result<T>
    {
        public bool IsSuccess { get; init; }
        public T? Value { get; init; }
    }
}
