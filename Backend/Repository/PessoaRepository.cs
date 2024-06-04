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
    }
}
