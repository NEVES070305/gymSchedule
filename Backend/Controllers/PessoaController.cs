using Backend.Data;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System;

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

        public IActionResult Editar(string cpf)
        {
            var pessoa = pessoaRepository.BuscarPorCPF(cpf);
            if (pessoa == null)
            {
                return NotFound();
            }

            var viewModel = new PessoaUpdateModel
            {
                CPF = pessoa.CPF,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                UltimoNome = pessoa.UltimoNome,
                EnderecoId = pessoa.EnderecoId
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Editar(PessoaUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                pessoaRepository.Editar(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }
        public IActionResult Apagar(string id)
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