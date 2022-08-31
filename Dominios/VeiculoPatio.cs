using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Dominios
{
	public class VeiculoPatio
	{
		public  virtual Veiculo Veiculo{ get; private set; }
		public int VeiculoId { get; private set; }
		public virtual Patio Patio { get; private set; }
		public int PatioId { get; private set; }
		public DateTime HoraEntrada { get; private set; }
		public DateTime HoraSaida { get; private set; }
		public double Valor { get; private set; }
		public bool Ativo { get; private set; }


		public VeiculoPatio(int patioId, int veiculoId)
		{
			PatioId = patioId;
			VeiculoId = veiculoId;
			HoraEntrada = DateTime.Now;
			Valor = 5;
			Ativo = true;
		}

		public void AlterarValor(double valor)
		{
			if (valor < 5)
				throw new Exception("O valor a ser cobrado não pode ser menor que 5");

			Valor = valor;
		}

		public void AlterarAtivo(bool ativo)
		{
			Ativo = ativo;
		}

		public void AlterarHoraSaida(DateTime horaSaida)
		{
			HoraSaida = horaSaida;
		}
	}
}
