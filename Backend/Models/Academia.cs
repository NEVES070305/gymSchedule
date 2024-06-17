using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Academia
{
    public string Cnpj { get; set; }
    public string Nome { get; set; }
    public int EnderecoId { get; set; }
    public string CnpjRede { get; set; }

    public Endereco Endereco { get; set; }
    public Rede Rede { get; set; }
}