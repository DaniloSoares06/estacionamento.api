using Estacionamento.API.Dominios;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.API.Contexto
{
	public class EstacionamentoContexto : DbContext
	{
		public DbSet<Veiculo> Veiculos { get; set; }
		public DbSet<Patio> Patios { get; set; }
		public DbSet<VeiculoPatio> VeiculoPatios { get; set; }
		public EstacionamentoContexto(DbContextOptions<EstacionamentoContexto> opt) : base(opt)	{	}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new VeiculoMapeamento());
			builder.ApplyConfiguration(new PatioMapeamento());
			builder.ApplyConfiguration(new VeiculoPatioMapeamento());
		}
	}
}
