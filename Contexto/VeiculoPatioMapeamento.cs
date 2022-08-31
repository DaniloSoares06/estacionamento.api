using Estacionamento.API.Dominios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Contexto
{
	public class VeiculoPatioMapeamento : IEntityTypeConfiguration<VeiculoPatio>
	{
		public void Configure(EntityTypeBuilder<VeiculoPatio> builder)
		{
			builder.ToTable("VEICULO_PATIO");

			builder.HasKey(dp => new { dp.VeiculoId, dp.PatioId });

			builder.Property(dp => dp.PatioId);

			builder.Property(dp => dp.VeiculoId);

			builder.Property(b => b.HoraEntrada);

			builder.Property(b => b.HoraSaida);

			builder.HasOne(dp => dp.Veiculo)
				   .WithMany(b => b.Patios)
				   .HasForeignKey(dp => dp.VeiculoId);

			builder.HasOne(dp => dp.Patio)
				   .WithMany(p => p.Veiculos)
				   .HasForeignKey(dp => dp.PatioId);
		}
	}
}
