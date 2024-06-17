using Backend.Data;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class AcademiaController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly AcademiaRepository academiaRepository;
        public AcademiaController(AcademiaRepository academiaRepository, ApplicationDbContext context){
            this.academiaRepository = academiaRepository
;
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var academias = academiaRepository.Listar();
            return View(academias);
        }

        public IActionResult Editar(string cnpj)
        {
            var academia = academiaRepository.BuscarPorCnpj(cnpj);
            if (academia == null)
            {
                return NotFound();
            }

            var viewModel = new RedeUpdateModel
            {
                Cnpj = academia.Cnpj,
                Nome = academia.Nome,
                EnderecoId = academia.EnderecoId
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Editar(AcademiaUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                academiaRepository.Editar(model);
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
                bool apagado = academiaRepository.Apagar(cnpj);

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
        public IActionResult Criar(Academia academia)
        {
            academiaRepository.Adicionar(academia);
            return RedirectToAction("Index");
        }
    }
}