using Estacionamento.API.Dominios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.API.Contexto
{
	public class PatioMapeamento : IEntityTypeConfiguration<Patio>
	{
		public void Configure(EntityTypeBuilder<Patio> builder)
		{
			builder.ToTable("PATIO");

			builder
				.Property(a => a.Id)
				.ValueGeneratedOnAdd();

			builder.Property(ta => ta.Endereco)
			   .HasMaxLength(64)
			   .IsRequired();

			builder.Property(ta => ta.Nome)
				   .HasMaxLength(32)
				   .IsRequired();

			builder.Property(ta => ta.Cidade)
			   .HasMaxLength(32)
			   .IsRequired();

			builder.Property(ta => ta.UF)
			   .HasMaxLength(2)
			   .IsRequired();

			builder.Property(ta => ta.Bairro)
			   .HasMaxLength(24)
			   .IsRequired();

			builder.Property(ta => ta.Capacidade);


			builder.Property(dp => dp.VagasDisponiveis);

			builder.Property(ta => ta.Faturado);
		}
	}
}
