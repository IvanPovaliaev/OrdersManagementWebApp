using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersManagement.Application.Models;
using OrdersManagement.Application.Requests.Orders.Commands.AddOrder;
using OrdersManagementWebApp.Models;
using System.Diagnostics;

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
