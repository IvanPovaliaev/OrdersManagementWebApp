using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersManagement.Application.Models;
using OrdersManagement.Application.Requests.Orders.Commands.AddOrder;
using OrdersManagement.Application.Requests.Orders.Queries.GetAllOrders;
using OrdersManagement.Application.Requests.Orders.Queries.GetOrder;
using System;
using System.Threading.Tasks;

namespace OrdersManagementWebApp.Controllers
{
    /// <summary>
    /// Controller for managing orders in the system.
    /// </summary>
    public class OrderController : Controller
    {
        private readonly ISender _sender;

        public OrderController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Displays the index view with an empty order form.
        /// </summary>
        /// <returns>The view for the order creation form.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var order = new AddOrdersViewModel();
            return View(order);
        }

        /// <summary>
        /// Retrieves and displays all orders.
        /// </summary>
        /// <returns>A view displaying the list of all orders.</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var orders = await _sender.Send(new GetAllOrdersQuery());
            return View(orders);
        }

        /// <summary>
        /// Retrieves the details of a specific order based on the provided order ID.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>A partial view displaying the order details if successful, or a bad request response if the order is not found.</returns>
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _sender.Send(new GetOrderQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return PartialView("_OrderDetails", result.Value);
        }

        /// <summary>
        /// Creates a new order based on the provided order data.
        /// </summary>
        /// <param name="order">The order data to be created.</param>
        /// <returns>A view displaying the created order or a bad request response if the creation fails.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(AddOrdersViewModel order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _sender.Send(new AddOrderCommand(order));
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return View(result.Value);
        }
    }
}
