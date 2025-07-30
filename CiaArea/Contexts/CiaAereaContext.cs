using CiaArea.Entities;
using Microsoft.EntityFrameworkCore;

namespace CiaArea.Contexts;

public class CiaAereaContext: DbContext
{
    private readonly IConfiguration _configuration;

    public CiaAereaContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
    public DbSet<Cancelamento> Cancelamentos => Set<Cancelamento>();
    public DbSet<Manutencao> Manutencoes => Set<Manutencao>();
    public DbSet<Piloto> Pilotos => Set<Piloto>();
    public DbSet<Voo> Voos => Set<Voo>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CiaAerea"));
    }
}