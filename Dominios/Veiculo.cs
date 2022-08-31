using Estacionamento.API.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Runtime;
using Estacionamento.API.Dtos.VeiculoDto;

namespace Estacionamento.API.Dominios
{
	public class Veiculo
	{
		public int Id { get; private set; }
		public string Placa { get; private set; }
		public string Cor { get; private set; }
		public string Modelo { get; private set; }
		public string Proprietario { get; private set; }
		public TipoVeiculoEnum Tipo { get; private set; }
		[JsonIgnore]
		public virtual IList<VeiculoPatio> Patios { get; private set; } = new List<VeiculoPatio>();

		public static Veiculo CriarVeiculo(CriarVeiculoDto veiculoDto)
		{
			var veiculo = new Veiculo()
			{
				Modelo = veiculoDto.Modelo.ToUpper(),
				Placa = veiculoDto.Placa.ToUpper(),
				Cor = veiculoDto.Cor.ToUpper(),
				Proprietario = veiculoDto.Proprietario.ToUpper(),
				Tipo = veiculoDto.Tipo,
			};			

			return veiculo;
		}

		public void  AlterarVeiculo(AlterarVeiculoDto veiculoDto)
		{
			this.AlteraPlaca(veiculoDto.Placa);
			this.AlterarCor(veiculoDto.Cor);
			this.AlterarModelo(veiculoDto.Modelo);
			this.AlterarProprietario(veiculoDto.Proprietario);
			this.AlterarTipoVeiculo(veiculoDto.Tipo);
		}

		public void AlteraPlaca(string placa)
		{
			if (placa.Length > 8)
				throw new Exception("A Placa do veículo não pode ser maior que 8 caracteres");

			this.Placa = placa.ToUpper();
		}

		public void AlterarCor(string cor)
		{
			if (cor.Length > 16)
				throw new Exception("A Cor do veículo não pode ser maior que 16 caracteres");

			this.Cor = cor.ToUpper();
		}

		public void AlterarModelo(string modelo)
		{
			if (modelo.Length > 32)
				throw new Exception("O Modelo do veículo não pode ser maior que 32 caracteres");

			this.Modelo = modelo.ToUpper();
		}

		public void AlterarProprietario(string proprietario)
		{
			if (proprietario.Length > 32)
				throw new Exception("O Proprietário do veículo não pode ser maior que 32 caracteres");

			this.Proprietario = proprietario.ToUpper();
		}

		public void AlterarTipoVeiculo(TipoVeiculoEnum tipo)
		{
			IList<TipoVeiculoEnum> tipos = new List<TipoVeiculoEnum>() { TipoVeiculoEnum.Automovel, TipoVeiculoEnum.Moto };

			if (!tipos.Contains(tipo))
				throw new Exception("O Modelo do veículo não pode ser maior que 32 caracteres");

			this.Tipo = tipo;
		}
	}
}
