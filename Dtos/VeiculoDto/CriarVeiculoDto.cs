using Estacionamento.API.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Dtos.VeiculoDto
{
	public class CriarVeiculoDto
	{
		public string Placa { get; set; }
		public string Cor { get; set; }
		public string Modelo { get; set; }
		public string Proprietario { get; set; }
		public TipoVeiculoEnum Tipo { get; set; }
	}
}
