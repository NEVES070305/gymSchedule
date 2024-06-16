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

        public Pessoa? BuscarPorLogin(string login)
        {
            return _applicationDbContext.Pessoas.FirstOrDefault(x => x.Username.ToUpper() == login.ToUpper());
        }
    }
}
