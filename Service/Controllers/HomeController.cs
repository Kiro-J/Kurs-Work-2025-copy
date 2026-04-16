using Microsoft.AspNetCore.Mvc;
using Service.Domain.ViewModels.LoginAndRegistration;

namespace Service.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult SiteInformation() => View();
        public IActionResult Functions() => View();
        public IActionResult Contacts() => View();
    }
}
