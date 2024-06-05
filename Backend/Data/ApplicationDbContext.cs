using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Academia> Academias { get; set; }
        public DbSet<Rede> Redes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Academia>()
                  .HasKey(a => a.Cnpj);  // Definindo a chave primária

            modelBuilder.Entity<Academia>()
                .HasOne(a => a.Endereco)
                .WithMany()
                .HasForeignKey(a => a.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict); // Definindo o comportamento de exclusão

            modelBuilder.Entity<Academia>()
                .HasOne(a => a.Rede)
                .WithMany(r => r.Academias)
                .HasForeignKey(a => a.CnpjRede)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rede>()
                .HasKey(r => r.Cnpj);  // Definindo a chave primária

            modelBuilder.Entity<Rede>()
                .HasOne(r => r.Endereco)
                .WithMany()
                .HasForeignKey(r => r.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.Id);  // Definindo a chave primária

            modelBuilder.Entity<Pessoa>()
                .HasKey(p => p.Id);  // Definindo a chave primária

            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.Role)
                .WithMany(r => r.Pessoas)
                .HasForeignKey(p => p.RoleName)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.Name);  // Definindo a chave primária

            base.OnModelCreating(modelBuilder);
        }
    }
}
