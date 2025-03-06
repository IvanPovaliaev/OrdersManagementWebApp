using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersManagement.Application.Models;
using OrdersManagement.Application.Requests.Orders.Commands.AddOrder;
using OrdersManagement.Application.Requests.Orders.Queries.GetAllOrders;
using OrdersManagement.Application.Requests.Orders.Queries.GetOrder;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OrdersManagementWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISender _sender;

        public OrderController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var order = new AddOrdersViewModel();
            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var orders = await _sender.Send(new GetAllOrdersQuery());
            return View(orders);
        }

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
