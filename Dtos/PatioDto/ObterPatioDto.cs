using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Dtos.PatioDto
{
	public class ObterPatioDto : AlterarPatioDto
	{
		public int Id { get; set; }
		public double Faturado { get; set; }
	}
}
