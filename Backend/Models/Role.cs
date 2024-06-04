using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Role
{
    [Key]
    [Required]
    [MaxLength(50)]
    public string Nome { get; set; }

    public ICollection<Pessoa> Pessoas { get; set; }
}