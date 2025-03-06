namespace OrdersManagement.Domain
{
    public record struct Result<T>
    {
        /// <summary>
        /// Indicates whether the operation was successful.
        /// </summary>
        public bool IsSuccess { get; init; }

        /// <summary>
        /// The value returned by the operation if it was successful, otherwise <c>null</c>.
        /// </summary>
        public T? Value { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> with a success status and the specified value.
        /// </summary>
        /// <param name="value">The value to store if the operation is successful.</param>
        public Result(T value)
        {
            Value = value;
            IsSuccess = true;
        }
    }
}
