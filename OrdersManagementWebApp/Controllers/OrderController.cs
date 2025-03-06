using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersManagement.Application.Models;
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

        public IActionResult Index()
        {
            var order = new AddOrdersViewModel();
            return View(order);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
