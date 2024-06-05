using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class RedeController : Controller
    {
        RedeRepository redeRepository = new();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Rede rede)
        {
            redeRepository.Adicionar(rede);
            return RedirectToAction("Index");
        }
    }
}
