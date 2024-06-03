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
    public Endereco EnderecoId { get; set; }
    public Endereco Endereco { get; set; }


    [ForeignKey("Role")]
    public string RoleId {  get; set; }
    public Role Role { get; set; }
}
