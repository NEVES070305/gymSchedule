using Backend.Data;

namespace Backend.Repository
{
    public class RedeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext; 
        public RedeRepository()
        {
        }
        public RedeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Rede Adicionar(Rede rede)
        {
            _applicationDbContext.Redes.Add(rede);
            _applicationDbContext.SaveChanges();
            return rede;
        }
    }
}
