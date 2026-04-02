using Microsoft.EntityFrameworkCore;
using SistemaHR.Models;

namespace SistemaHR.Data;

public class AppDbContext : DbContext
{
    // O construtor recebe as opções de configuração (como a connection string)
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Aqui você define quais classes virarão tabelas no banco
    // É o equivalente ao @Entity do Spring, mas centralizado aqui
    public DbSet<Funcionarios> Funcionarios { get; set; }

    // Dica de mestre: Se quiser configurar nomes de colunas ou chaves compostas,
    // usamos este método (Fluent API), que é muito mais poderoso que Annotations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Exemplo: Garantir que o Email seja único
        modelBuilder.Entity<Funcionarios>()
            .HasIndex(f => f.Email)
            .IsUnique();
    }
}