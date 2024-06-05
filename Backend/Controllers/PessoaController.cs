using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
