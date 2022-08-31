using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Dtos.VeiculoPatioDto
{
	public class RegistrarSaidaDto 
	{
		public string Placa { get; set; }
		public string Endereco { get; set; }
		public double Valor { get; set; }
		public DateTime HoraEntrada { get; set; }
		public DateTime HoraSaida { get; set; }

	}
}
