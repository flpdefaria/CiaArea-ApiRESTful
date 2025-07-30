using CiaArea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CiaArea.EntityConfigurations;

public class VooConfiguration : IEntityTypeConfiguration<Voo>
{
    public void Configure(EntityTypeBuilder<Voo> builder)
    {
        builder.ToTable("Voos");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Origem)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(a => a.Destino)
            .IsRequired()
            .HasMaxLength(3);
        
        builder.Property(a => a.DataHoraPartida)
            .IsRequired();
        
        builder.Property(a => a.DataHoraChegada)
            .IsRequired();
        
        builder.HasOne(a => a.Aeronave)
            .WithMany(a => a.Voos)
            .HasForeignKey(a => a.AeronaveId);
        
        builder.HasOne(a => a.Piloto)
            .WithMany(a => a.Voos)
            .HasForeignKey(a => a.PilotoId);
        
        builder.HasOne(v => v.Cancelamento)
            .WithOne(c => c.Voo)
            .HasForeignKey<Cancelamento>(c => c.VooId);
        
    }
}