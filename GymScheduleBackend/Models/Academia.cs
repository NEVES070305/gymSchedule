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
    public Endereco Endereco { get; set; }

    [ForeignKey("Rede")]
    [Column(TypeName = "char(14)")]
    public string CnpjRede { get; set; }
    public Rede Rede { get; set; }
}
