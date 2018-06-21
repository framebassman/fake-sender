using Microsoft.AspNetCore.Mvc;

namespace FakeSender.Api.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Redirect("/swagger/#/");
        }
    }
}