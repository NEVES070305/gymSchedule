using Backend.Data;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("[controller]/[action]")]
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

        [HttpGet]
        public IActionResult Editar(int cpf)
        {
            Pessoa pessoa = pessoaRepository.BuscarPorCPF(cpf);
            if (pessoa == null)
            {
                return NotFound();
            }

            var model = new PessoaUpdateModel
            {
                CPF = pessoa.CPF,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                UltimoNome = pessoa.UltimoNome,
                EnderecoId = pessoa.EnderecoId
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(PessoaUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                pessoaRepository.Editar(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = pessoaRepository.Apagar(id);

                if (apagado)
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                else
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato, tente novamente!";

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamente, detalhe do erro: {erro.Message}";
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
            if (ModelState.IsValid)
            {
                pessoaRepository.Adicionar(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }
    }
}
