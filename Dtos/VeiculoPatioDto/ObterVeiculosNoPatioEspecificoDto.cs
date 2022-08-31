using Estacionamento.API.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Dtos.VeiculoPatioDto
{
	public class ObterVeiculosNoPatioEspecificoDto 
	{
		public string Placa { get; set; }
		public string Proprietario { get; set; }
		public TipoVeiculoEnum TipoVeiculo { get; set; }
		public double Valor { get; set; }
		public DateTime HoraEntrada { get; set; }
	}
}
