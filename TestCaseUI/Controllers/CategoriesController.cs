using Microsoft.AspNetCore.Mvc;

namespace TestCaseUI.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryAdd()
        {
            return View();
        }
        public IActionResult CategoryUpdate()
        {
            return View();
        }
    }
}
