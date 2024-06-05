using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Rede
{
    public string Cnpj { get; set; }
    public string Nome { get; set; }
    public int EnderecoId { get; set; }

    public Endereco Endereco { get; set; }
    public ICollection<Academia> Academias { get; set; }
}