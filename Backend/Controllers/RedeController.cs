using Backend.Data;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class RedeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly RedeRepository redeRepository;
        public RedeController(RedeRepository redeRepository, ApplicationDbContext context){
            this.redeRepository = redeRepository;
            this.context = context;
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
        public async Task<IActionResult> ApagarConfirmacao(string id)
        {
            var pessoa = await context.Redes.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }
        public IActionResult Apagar(string cnpj)
        {
            try
            {
                bool apagado = redeRepository.Apagar(cnpj);

                if (apagado) TempData["MensagemSucesso"] = "Contato apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu contato, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Criar(Rede rede)
        {
            redeRepository.Adicionar(rede);
            return RedirectToAction("Index");
        }
    }
}