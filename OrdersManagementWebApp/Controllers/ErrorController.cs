using Microsoft.AspNetCore.Mvc;
using OrdersManagement.Application.Models;
using System.Diagnostics;

namespace OrdersManagementWebApp.Controllers
{
    public class ErrorController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
