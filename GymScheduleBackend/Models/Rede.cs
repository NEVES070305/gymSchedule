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

    public ICollection<Academia> Academias { get; set; }
}
