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
        public List<Endereco> Listar()
        {
            return _applicationDbContext.Enderecos.ToList();
        }

        public Endereco Editar(Endereco endereco)
        {
            Endereco enderecoDB = BuscarPorID(endereco.Id);

            if (enderecoDB == null) throw new Exception("Houve um erro na atualização do contato!");

            enderecoDB.Bairro = endereco.Bairro;
            enderecoDB.Cidade = endereco.Cidade;
            enderecoDB.Numero = endereco.Numero;
            enderecoDB.Rua = endereco.Rua;

            _applicationDbContext.Enderecos.Update(enderecoDB);
            _applicationDbContext.SaveChanges();

            return enderecoDB;
        }
        public Endereco? BuscarPorID(int id)
        {
            return _applicationDbContext.Enderecos.FirstOrDefault(x => x.Id == id);
        }

        public bool Apagar(int id)
        {
            Endereco enderecoDB = BuscarPorID(id);

            if (enderecoDB == null) throw new Exception("Houve um erro na deleção do contato!");

            _applicationDbContext.Enderecos.Remove(enderecoDB);
            _applicationDbContext.SaveChanges();

            return true;
        }
    }
}
