using GymScheduleBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class ApplicationDbContext : DbContext
{
    public DbSet<Academia> Academias { get; set; }
    public DbSet<Rede> Redes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Academia>()
            .HasOne(a => a.Rede)
            .WithMany(r => r.Academias)
            .HasForeignKey(a => a.CnpjRede);

        modelBuilder.Entity<Endereco>()
            .HasKey(e => new { e.Estado, e.Cidade, e.Bairro, e.Rua, e.Numero });

        modelBuilder.Entity<Pessoa>()
            .OwnsOne(p => p.Endereco);

        base.OnModelCreating(modelBuilder);
    }
}
