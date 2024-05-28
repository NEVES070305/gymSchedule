using System.ComponentModel.DataAnnotations;

public class Endereco
{
	[Key]
	[MaxLength(50)]
	public string Estado { get; set; }

	[Key]
	[MaxLength(70)]
	public string Cidade { get; set; }

	[Key]
	[MaxLength(50)]
	public string Bairro { get; set; }

	[Key]
	[MaxLength(150)]
	public string Rua { get; set; }

	[Key]
	public int Numero { get; set; }
}
