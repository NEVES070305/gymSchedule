using Backend.Data;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Backend.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaRepository pessoaRepository;
        private readonly ApplicationDbContext context;
        // Inicializa o EnderecoRepository através do construtor
        public PessoaController(PessoaRepository pessoaRepository, ApplicationDbContext context)
        {
            this.pessoaRepository = pessoaRepository;
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var pessoas = pessoaRepository.Listar();
            return View(pessoas);
        }
        [HttpPost]
        public IActionResult Editar(Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pessoa = pessoaRepository.Editar(pessoa);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(pessoa);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int cpf)
        {
            Pessoa pessoa = pessoaRepository.BuscarPorID(cpf);
            return View(pessoa);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = pessoaRepository.Apagar(id);

                if (apagado) TempData["MensagemSucesso"] = "Contato apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu contato, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
            public async Task<IActionResult> ApagarConfirmacao(int id)
            {
                var pessoa = await context.Pessoas.FindAsync(id);
                if (pessoa == null)
        {
            return NotFound();
        }
        return View(pessoa);
    }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Pessoa pessoa)
        {
            pessoaRepository.Adicionar(pessoa);
            return RedirectToAction("Index");
        }
    }
}
