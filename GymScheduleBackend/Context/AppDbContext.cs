using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Academia> Academias { get; set; }
    public DbSet<Rede> Redes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Academia>()
            .HasOne(a => a.Endereco)
            .WithMany()
            .HasForeignKey(a => a.EnderecoId);

        modelBuilder.Entity<Academia>()
            .HasOne(a => a.Rede)
            .WithMany(r => r.Academias)
            .HasForeignKey(a => a.CnpjRede);

        modelBuilder.Entity<Rede>()
            .HasOne(r => r.Endereco)
            .WithMany()
            .HasForeignKey(r => r.EnderecoId);

        modelBuilder.Entity<Pessoa>()
            .HasOne(p => p.Endereco)
            .WithMany()
            .HasForeignKey(p => p.EnderecoId);

        modelBuilder.Entity<Pessoa>()
            .HasOne(p => p.Role)
            .WithMany(r => r.Pessoas)
            .HasForeignKey(p => p.RoleId);

        base.OnModelCreating(modelBuilder);
    }
}
