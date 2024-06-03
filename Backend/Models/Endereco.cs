using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Endereco
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Estado { get; set; }

    [Required]
    [MaxLength(70)]
    public string Cidade { get; set; }

    [Required]
    [MaxLength(50)]
    public string Bairro { get; set; }

    [Required]
    [MaxLength(150)]
    public string Rua { get; set; }

    [Required]
    public int Numero { get; set; }
}