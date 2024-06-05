using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Role
{
    public string Name { get; set; }
    public ICollection<Pessoa> Pessoas { get; set; }
}