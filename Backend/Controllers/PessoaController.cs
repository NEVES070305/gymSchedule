using AspNetCore;
using Backend.Data;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaRepository pessoaRepository;

        public PessoaController(PessoaRepository pessoaRepository)
        {
            this.pessoaRepository = pessoaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var pessoas = pessoaRepository.Listar();
            return View(pessoas);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int cpf)
        {
            var pessoa = await pessoaRepository.BuscarPorIDAsync(cpf);
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
                EnderecoId = pessoa.EnderecoId,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PessoaUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var pessoa = await pessoaRepository.BuscarPorIDAsync(model.CPF);
            if (pessoa == null)
            {
                return NotFound();
            }

            // Atualize apenas os campos desejados
            pessoa.Nome = model.Nome;
            pessoa.Sobrenome = model.Sobrenome;
            // Atualize outros campos conforme necessário

            await pessoaRepository.EditarAsync(pessoa);

            TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Apagar(int id)
        {
            try
            {
                bool apagado = await pessoaRepository.ApagarAsync(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato, tente novamente!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
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
