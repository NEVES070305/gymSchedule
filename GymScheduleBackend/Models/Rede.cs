using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Rede
{
    [Key]
    [Column(TypeName = "char(14)")]
    public string Cnpj { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [ForeignKey(Endereco)]
0   [Required]
    public Endereco Endereco { get; set; }

    public ICollection<Academia> Academias { get; set; }
}
