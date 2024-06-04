using Microsoft.EntityFrameworkCore;

// Define a classe de contexto que herda de DbContext, que é o principal ponto de integração com o Entity Framework Core.
namespace Backend.Data
{
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
        // Define conjuntos de dados (tabelas) para cada entidade. DbSet<T> representa uma coleção de todas as entidades no contexto.
    public DbSet<Academia> Academias { get; set; }
	public DbSet<Rede> Redes { get; set; }
	public DbSet<Endereco> Enderecos { get; set; }
	public DbSet<Pessoa> Pessoas { get; set; }
	public DbSet<Role> Roles { get; set; }

	// Configura o modelo de dados usando o ModelBuilder.
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Configura a entidade Academia para ter uma relação de um para muitos com Endereco.
		modelBuilder.Entity<Academia>()
			.HasOne(a => a.Endereco) // Cada Academia tem um Endereco.
			.WithMany() // Um Endereco pode estar relacionado a muitas Academias.
			.HasForeignKey(a => a.EnderecoId); // Chave estrangeira em Academia referenciando Endereco.

		// Configura a entidade Academia para ter uma relação de muitos para um com Rede.
		modelBuilder.Entity<Academia>()
			.HasOne(a => a.Rede) // Cada Academia pertence a uma Rede.
			.WithMany(r => r.Academias) // Uma Rede pode ter muitas Academias.
			.HasForeignKey(a => a.CnpjRede); // Chave estrangeira em Academia referenciando Rede pelo CNPJ.

		// Configura a entidade Rede para ter uma relação de um para muitos com Endereco.
		modelBuilder.Entity<Rede>()
			.HasOne(r => r.Endereco) // Cada Rede tem um Endereco.
			.WithMany() // Um Endereco pode estar relacionado a muitas Redes.
			.HasForeignKey(r => r.EnderecoId); // Chave estrangeira em Rede referenciando Endereco.

		// Configura a entidade Pessoa para ter uma relação de um para muitos com Endereco.
		modelBuilder.Entity<Pessoa>()
			.HasOne(p => p.Endereco) // Cada Pessoa tem um Endereco.
			.WithMany() // Um Endereco pode estar relacionado a muitas Pessoas.
			.HasForeignKey(p => p.EnderecoId); // Chave estrangeira em Pessoa referenciando Endereco.

		// Configura a entidade Pessoa para ter uma relação de muitos para um com Role.
		modelBuilder.Entity<Pessoa>()
			.HasOne(p => p.Role) // Cada Pessoa tem um Role.
			.WithMany(r => r.Pessoas) // Um Role pode estar relacionado a muitas Pessoas.
			.HasForeignKey(p => p.RoleName); // Chave estrangeira em Pessoa referenciando Role.

		// Chama o método base para garantir que qualquer configuração adicional no DbContext base seja aplicada.
		base.OnModelCreating(modelBuilder);
	}
}

}
