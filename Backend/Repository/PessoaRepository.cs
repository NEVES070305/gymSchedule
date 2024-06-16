using Backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public async Task<Pessoa?> BuscarPorIDAsync(int cpf)
        {
            return await _applicationDbContext.Pessoas.FirstOrDefaultAsync(x => x.CPF == cpf);
        }

        public List<Pessoa> Listar()
        {
            return _applicationDbContext.Pessoas.ToList();
        }

        public async Task<Pessoa> EditarAsync(Pessoa pessoa)
        {
            Pessoa pessoaDB = await BuscarPorIDAsync(pessoa.CPF);

            if (pessoaDB == null)
            {
                throw new Exception("Houve um erro na atualização do contato!");
            }

            pessoaDB.Nome = pessoa.Nome;
            pessoaDB.Sobrenome = pessoa.Sobrenome;
            // Atualize outros campos conforme necessário

            _applicationDbContext.Pessoas.Update(pessoaDB);
            await _applicationDbContext.SaveChangesAsync();

            return pessoaDB;
        }

        public async Task<bool> ApagarAsync(int cpf)
        {
            Pessoa pessoaDB = await BuscarPorIDAsync(cpf);

            if (pessoaDB == null)
            {
                throw new Exception("Houve um erro na deleção do contato!");
            }

            _applicationDbContext.Pessoas.Remove(pessoaDB);
            await _applicationDbContext.SaveChangesAsync();

            return true;
        }
    }
}
