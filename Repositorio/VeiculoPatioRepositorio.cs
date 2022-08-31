using Estacionamento.API.Contexto;
using Estacionamento.API.Dominios;
using System.Collections.Generic;

namespace Estacionamento.API.Repositorio
{
	public class VeiculoPatioRepositorio
	{
		private readonly EstacionamentoContexto _estacionamentoContexto;

		public VeiculoPatioRepositorio(EstacionamentoContexto estacionamentoContexto)
		{
			_estacionamentoContexto = estacionamentoContexto;
		}

		public void Adicionar(VeiculoPatio veiculo)
		{
			_estacionamentoContexto.VeiculoPatios.Add(veiculo);
			_estacionamentoContexto.SaveChanges();
		}
		
		public void Atualizar(VeiculoPatio veiculo)
		{
			_estacionamentoContexto.VeiculoPatios.Update(veiculo);
			_estacionamentoContexto.SaveChanges();
		}
	}
}
