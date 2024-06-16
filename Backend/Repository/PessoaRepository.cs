using Backend.Data;
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

        public Pessoa Editar(Pessoa pessoa)
        {
            Pessoa pessoaDB = BuscarPorID(pessoa.CPF);

            if (pessoaDB == null) throw new Exception("Houve um erro na atualização do contato!");

            pessoaDB.Nome = pessoa.Nome;
            pessoaDB.Sobrenome = pessoa.Sobrenome;
            pessoaDB.UltimoNome = pessoa.UltimoNome;
            pessoaDB.RoleName = pessoa.RoleName;
            pessoaDB.EnderecoId = pessoa.EnderecoId;
            pessoaDB.Password = pessoa.Password;
            pessoaDB.Username = pessoa.Username;

            _applicationDbContext.Pessoas.Update(pessoaDB);
            _applicationDbContext.SaveChanges();

            return pessoaDB;
        }
        public Pessoa? BuscarPorID(int cpf)
        {
            return _applicationDbContext.Pessoas.FirstOrDefault(x => x.CPF == cpf);
        }

        public bool Apagar(int id)
        {
            Pessoa pessoaDB = BuscarPorID(id);

            if (pessoaDB == null) throw new Exception("Houve um erro na deleção do contato!");

            _applicationDbContext.Pessoas.Remove(pessoaDB);
            _applicationDbContext.SaveChanges();

            return true;
        }
    }
}
