using Estacionamento.API.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Dtos.VeiculoPatioDto
{
	public class ObterVeiculosPatioDto
	{
		public string Endereco { get; set; }
		public int VagasDisponiveis { get; set; }
		public string Placa { get; set; }
		public string Proprietario { get; set; }		
		public TipoVeiculoEnum TipoVeiculo {get; set;}
		public DateTime HoraEntrada { get; set; }
	}
}
