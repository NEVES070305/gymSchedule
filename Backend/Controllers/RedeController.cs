using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class RedeController : Controller
    {
        private readonly RedeRepository redeRepository;
        public RedeController(RedeRepository redeRepository){
            this.redeRepository = redeRepository;
        }
        public async Task<IActionResult> Index()
        {
            var redes = redeRepository.Listar();
            return View(redes);
        }

        public IActionResult Editar(string cnpj)
        {
            var rede = redeRepository.BuscarPorCnpj(cnpj);
            if (rede == null)
            {
                return NotFound();
            }

            var viewModel = new RedeUpdateModel
            {
                Cnpj = rede.Cnpj,
                Nome = rede.Nome,
                EnderecoId = rede.EnderecoId
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Editar(RedeUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                redeRepository.Editar(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult ApagarConfirmacao(string cnpj)
        {
            var rede = redeRepository.BuscarPorCnpj(cnpj);
            if (rede == null)
            {
                return View("Index");
            }
            return View(rede);
        }
        [HttpPost]
        public IActionResult Criar(Rede rede)
        {
            redeRepository.Adicionar(rede);
            return RedirectToAction("Index");
        }
    }
}
