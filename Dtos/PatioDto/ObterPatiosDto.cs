using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Dtos.PatioDto
{
	public class ObterPatiosDto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public string Cidade { get; set; }
		public double Faturado { get; set; }
		public int VagasDisponiveis { get; set; }
	}
}
