using Estacionamento.API.Dominios;
using Estacionamento.API.Dtos.VeiculoDto;
using Estacionamento.API.Dtos.VeiculoPatioDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.InterfacesServico
{
	public interface IVeiculoServico
	{		
		void Alterar(AlterarVeiculoDto veiculoDto, string placa);
		Dtos.VeiculoDto.ObterVeiculoDto ObterPorPlaca(string placa);
		IList<Dtos.VeiculoDto.ObterVeiculoDto> ObterTodos();
		void Excluir(string placa);
		public void RegistrarEntrada(CriarVeiculoDto veiculoDto, int patioId);
		public RegistrarSaidaDto RegistrarSaida(string placa);
	}
}
