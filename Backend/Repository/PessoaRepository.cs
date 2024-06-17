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

        public Pessoa Editar(PessoaUpdateModel model)
        {
            Pessoa pessoaDB = _applicationDbContext.Pessoas.Find(model.CPF);

            if (pessoaDB == null) throw new Exception("Houve um erro na atualização do contato!");

            pessoaDB.Nome = model.Nome;
            pessoaDB.Sobrenome = model.Sobrenome;
            pessoaDB.UltimoNome = model.UltimoNome;
            pessoaDB.EnderecoId = model.EnderecoId;

            _applicationDbContext.Entry(pessoaDB).Property(p => p.Nome).IsModified = true;
            _applicationDbContext.Entry(pessoaDB).Property(p => p.Sobrenome).IsModified = true;
            _applicationDbContext.Entry(pessoaDB).Property(p => p.UltimoNome).IsModified = true;
            _applicationDbContext.Entry(pessoaDB).Property(p => p.EnderecoId).IsModified = true;

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