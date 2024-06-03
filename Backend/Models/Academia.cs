using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Academia
{
    [Key]
    [Column(TypeName = "char(14)")]
    public string Cnpj { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    public int EnderecoId { get; set; }
    public Endereco Endereco { get; set; }

    [Column(TypeName = "char(14)")]
    public string CnpjRede { get; set; }
    public Rede Rede { get; set; }
}