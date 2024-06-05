using Backend.Data;

namespace Backend.Repository
{
    public class EnderecoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EnderecoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Endereco Adicionar(Endereco endereco)
        {
            _applicationDbContext.Enderecos.Add(endereco);
            _applicationDbContext.SaveChanges();
            return endereco;
        }
    }
}
