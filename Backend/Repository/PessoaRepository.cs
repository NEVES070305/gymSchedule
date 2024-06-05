using Backend.Data;

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
    }
}
