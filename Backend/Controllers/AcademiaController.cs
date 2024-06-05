using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class AcademiaController : Controller
    {
        AcademiaRepository academiaRepository = new();
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
        public IActionResult Criar(Academia academia)
        {
            academiaRepository.Adicionar(academia);
            return RedirectToAction("Index");  
        }
    }
}
