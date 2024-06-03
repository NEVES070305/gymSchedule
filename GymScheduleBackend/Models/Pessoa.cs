using GymScheduleBackend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pessoa
{
    [Key]
    [Column(TypeName = "char(11)")]
    public string Cpf { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nome { get; set; }

    [Required]
    [MaxLength(40)]
    public string Sobrenome { get; set; }

    [MaxLength(40)]
    public string UltimoNome { get; set; }

    [ForeignKey("Endereco")]
    [Required]
<<<<<<< HEAD
    public Endereco EnderecoId { get; set; }
=======
    [ForeignKey("Endereco")]
    public int EnderecoId { get; set; }
>>>>>>> 35c8a5380cc06d6844a3f8a65beedc8230620af3
    public Endereco Endereco { get; set; }


    [ForeignKey("Role")]
    public string RoleId {  get; set; }
    public Role Role { get; set; }
}
