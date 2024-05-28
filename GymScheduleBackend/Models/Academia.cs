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
    [MaxLength(70)]
    public string Cidade { get; set; }

    [Required]
    [MaxLength(50)]
    public string Estado { get; set; }

    [Required]
    [MaxLength(50)]
    public string Bairro { get; set; }

    [Required]
    [MaxLength(150)]
    public string Rua { get; set; }

    [Required]
    public int Numero { get; set; }

    [ForeignKey("Rede")]
    [Column(TypeName = "char(14)")]
    public string CnpjRede { get; set; }
    public Rede Rede { get; set; }
}
