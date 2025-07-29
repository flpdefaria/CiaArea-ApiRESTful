using CiaArea.Entities;
using Microsoft.EntityFrameworkCore;

namespace CiaArea.Contexts;

public class CiaAreaContext: DbContext
{
    public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
    public DbSet<Cancelamento> Cancelamentos => Set<Cancelamento>();
    public DbSet<Manutencao> Manutencaos => Set<Manutencao>();
    public DbSet<Piloto> Pilotos => Set<Piloto>();
    public DbSet<Voo> Voos => Set<Voo>();
}