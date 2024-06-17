using Backend.Data;
using Backend.Models;

namespace Backend.Repository
{
    public class RedeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext; 
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
        public List<Rede> Listar()
        {
            return _applicationDbContext.Redes.ToList();
        }

        public Rede Editar(RedeUpdateModel rede)
        {
            Rede redeDB = BuscarPorCnpj(rede.Cnpj);

            if (redeDB == null) throw new Exception("Houve um erro na atualização da rede!");

            // Atualize apenas os campos especificados
            redeDB.Cnpj = redeDB.Cnpj;
            redeDB.Nome = rede.Nome;
            redeDB.EnderecoId = rede.EnderecoId;

            _applicationDbContext.Redes.Update(redeDB);
            _applicationDbContext.SaveChanges();

            return redeDB;
        }
        public Rede? BuscarPorCnpj(string cnpj)
        {
            return _applicationDbContext.Redes.FirstOrDefault(x => x.Cnpj == cnpj);
        }

        public bool Apagar(string cnpj)
        {
            Rede redeDB = BuscarPorCnpj(cnpj);

            if (redeDB == null) throw new Exception("Houve um erro na deleção do contato!");

            _applicationDbContext.Redes.Remove(redeDB);
            _applicationDbContext.SaveChanges();

            return true;
        }
    }
}
