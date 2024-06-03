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

<<<<<<< HEAD
    [ForeignKey(Endereco)]
0   [Required]
=======
    [Required]
    [ForeignKey("Endereco")]
    public int EnderecoId { get; set; }
>>>>>>> 35c8a5380cc06d6844a3f8a65beedc8230620af3
    public Endereco Endereco { get; set; }

    public ICollection<Academia> Academias { get; set; }
}
