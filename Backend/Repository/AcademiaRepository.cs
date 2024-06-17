using Backend.Data;
using Backend.Models;

namespace Backend.Repository
{
    public class AcademiaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
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
        public List<Academia> Listar()
        {
            return _applicationDbContext.Academias.ToList();
        }

        public Academia Editar(AcademiaUpdateModel academia)
        {
            Academia AcademiaDB = BuscarPorCnpj(academia.Cnpj);

            if (AcademiaDB == null) throw new Exception("Houve um erro na atualização da Academia!");

            // Atualize apenas os campos especificados
            AcademiaDB.Nome = academia.Nome;
            AcademiaDB.EnderecoId = academia.EnderecoId;

            _applicationDbContext.Academias.Update(AcademiaDB);
            _applicationDbContext.SaveChanges();

            return AcademiaDB;
        }
        public Academia? BuscarPorCnpj(string cnpj)
        {
            return _applicationDbContext.Academias.FirstOrDefault(x => x.Cnpj == cnpj);
        }

        public bool Apagar(string cnpj)
        {
            Academia AcademiaDB = BuscarPorCnpj(cnpj);

            if (AcademiaDB == null) throw new Exception("Houve um erro na deleção do contato!");

            _applicationDbContext.Academias.Remove(AcademiaDB);
            _applicationDbContext.SaveChanges();

            return true;
        }
    }
}
