using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Dtos.VeiculoPatioDto
{
	public class ObterVeiculoPatioDto : ObterVeiculosPatioDto
	{
		public double Valor { get; set; }
		public string Modelo { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
	
	}
}
