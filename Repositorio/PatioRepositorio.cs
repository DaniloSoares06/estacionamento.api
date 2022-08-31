using Estacionamento.API.Contexto;
using Estacionamento.API.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Repositorio
{
	public class PatioRepositorio
	{
		private readonly EstacionamentoContexto _estacionamentoContexto;

		public PatioRepositorio(EstacionamentoContexto estacionamentoContexto)
		{
			_estacionamentoContexto = estacionamentoContexto;
		}

		public void Adicionar(Patio patio)
		{
			_estacionamentoContexto.Patios.Add(patio);
			_estacionamentoContexto.SaveChanges();
		}
		public IList<Patio> ObterTodos()
		{
			return _estacionamentoContexto.Patios.ToList();
		}
		public void Atualizar(Patio patio)
		{
			_estacionamentoContexto.Patios.Update(patio);
			_estacionamentoContexto.SaveChanges();
		}

		public void Excluir(Patio patio)
		{
			_estacionamentoContexto.Patios.Remove(patio);
			_estacionamentoContexto.SaveChanges();

		}
	}
}
