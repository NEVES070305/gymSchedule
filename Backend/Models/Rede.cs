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
	public int EnderecoId { get; set; }
	public Endereco Endereco { get; set; }

	public ICollection<Academia> Academias { get; set; }
}