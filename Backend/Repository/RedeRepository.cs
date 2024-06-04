using Backend.Data;

namespace Backend.Repository
{
    public class RedeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RedeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
