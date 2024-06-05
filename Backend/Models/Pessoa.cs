using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int EnderecoId { get; set; }
    public string RoleName { get; set; }
    public Endereco Endereco { get; set; }
    public Role Role { get; set; }
}