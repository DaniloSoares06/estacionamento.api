using Estacionamento.API.Dominios;
using Estacionamento.API.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Contexto
{
	public class VeiculoMapeamento : IEntityTypeConfiguration<Veiculo>
	{
		public void Configure(EntityTypeBuilder<Veiculo> builder)
		{

			builder.ToTable("VEICULO");

			builder
				.Property(a => a.Id)
				.ValueGeneratedOnAdd();

			builder.Property(ta => ta.Placa)
			   .HasMaxLength(8)
			   .IsRequired();

			builder.Property(ta => ta.Cor)
			   .HasMaxLength(16)
			   .IsRequired();			
			
			builder.Property(ta => ta.Proprietario)
			   .HasMaxLength(32)
			   .IsRequired();

			builder.Property(ta => ta.Modelo)
			   .HasMaxLength(32)
			   .IsRequired();

			builder.Property(b => b.Tipo)
				.IsRequired();
		}
	}
}
