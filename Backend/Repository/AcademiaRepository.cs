using Backend.Data;

namespace Backend.Repository
{
    public class AcademiaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AcademiaRepository()
        {

        }
        public AcademiaRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Academia Adicionar(Academia academia)
        {   
            _applicationDbContext.Academias.Add(academia);
            _applicationDbContext.SaveChanges();
            return academia;
        }
    }
}
