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
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Pessoa pessoa)
        {
            pessoaRepository.Adicionar(pessoa);
            return RedirectToAction("Index");
        }
        /*    CRIANDO EDITAR E APAGAR - André  Minuto-26    */
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult Apagar()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
