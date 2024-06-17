using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository    
{
    public class PessoaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PessoaRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Pessoa Adicionar(Pessoa pessoa)
        {
            _applicationDbContext.Pessoas.Add(pessoa);
            _applicationDbContext.SaveChanges();
            return pessoa;
        }

        public Pessoa? BuscarPorUsernameESenha(LoginModel loginModel)
        {
            return _applicationDbContext.Pessoas.FirstOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);
        }

        public List<Pessoa> Listar()
        {
            return _applicationDbContext.Pessoas.ToList();
        }

        public Pessoa Editar(PessoaUpdateModel pessoa)
        {
            Pessoa pessoaDB = BuscarPorCPF(pessoa.CPF);

            if (pessoaDB == null)
            {
                throw new Exception("Pessoa não encontrada para edição.");
            }

            // Atualize apenas os campos especificados
            pessoaDB.Nome = pessoa.Nome;
            pessoaDB.Sobrenome = pessoa.Sobrenome;
            pessoaDB.UltimoNome = pessoa.UltimoNome;
            pessoaDB.EnderecoId = pessoa.EnderecoId;

            _applicationDbContext.Pessoas.Update(pessoaDB);
            _applicationDbContext.SaveChanges();

            return pessoaDB;
        }
        public Pessoa? BuscarPorCPF(int cpf)
        {
            return _applicationDbContext.Pessoas.FirstOrDefault(x => x.CPF == cpf);
        }

        public bool Apagar(int cpf)
        {
            Pessoa pessoaDB = BuscarPorCPF(cpf);

            if (pessoaDB == null) return false;

            _applicationDbContext.Pessoas.Remove(pessoaDB);
            _applicationDbContext.SaveChanges();

            return true;
        }
    }
}