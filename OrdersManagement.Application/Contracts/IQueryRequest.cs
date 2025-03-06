﻿using MediatR;

namespace OrdersManagement.Application.Contracts
{
    /// <summary>
    /// Represents a query request that returns a response.
    /// </summary>
    /// <typeparam name="TResponse">The type of response returned by the request.</typeparam>
    public interface IQueryRequest<TResponse> : IRequest<TResponse>;
}
