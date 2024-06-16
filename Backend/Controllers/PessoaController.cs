using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaRepository pessoaRepository;

        // Inicializa o EnderecoRepository através do construtor
        public PessoaController(PessoaRepository pessoaRepository)
        {
            this.pessoaRepository = pessoaRepository;
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
        public IActionResult Apagar()
        {
            return View();
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
