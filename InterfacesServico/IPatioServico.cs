using Estacionamento.API.Dominios;
using Estacionamento.API.Dtos.PatioDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.InterfacesServico
{
	public interface IPatioServico
	{
		void Criar (CriarPatioDto patioDto);
		void Alterar(AlterarPatioDto patioDto, int id);
		ObterPatioDto ObterPorId(int id);
		IList<ObterPatiosDto> ObterTodos();
		void Excluir(int id);
	}
}
