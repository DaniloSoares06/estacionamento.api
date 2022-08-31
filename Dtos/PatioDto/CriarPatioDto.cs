using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Dtos.PatioDto
{
	public class CriarPatioDto
	{
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string UF { get; set; }
		public int Capacidade { get; set; }		
	}
}
