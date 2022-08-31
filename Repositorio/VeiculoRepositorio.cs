using Estacionamento.API.Contexto;
using Estacionamento.API.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Repositorio
{
	public class VeiculoRepositorio
	{
		private readonly EstacionamentoContexto _estacionamentoContexto;

		public VeiculoRepositorio(EstacionamentoContexto estacionamentoContexto)
		{
			_estacionamentoContexto = estacionamentoContexto;
		}

		public void Adicionar(Veiculo veiculo)
		{
			_estacionamentoContexto.Veiculos.Add(veiculo);
			_estacionamentoContexto.SaveChanges();
		}

		public void Atualizar(Veiculo veiculo)
		{
			_estacionamentoContexto.Veiculos.Update(veiculo);
			_estacionamentoContexto.SaveChanges();
		}
		public IList<Veiculo> ObterTodos()
		{
			return _estacionamentoContexto.Veiculos.ToList();
		}
		public IList<VeiculoPatio> ObterTodosVeiculosNoPatio()
		{
			return _estacionamentoContexto.VeiculoPatios.Where(v => v.Ativo == true).ToList();
		}

		public void Excluir(Veiculo veiculo)
		{
			_estacionamentoContexto.Veiculos.Remove(veiculo);
			_estacionamentoContexto.SaveChanges();

		}
	}
}
