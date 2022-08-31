using Estacionamento.API.Dominios.Validacao;
using Estacionamento.API.Dtos.PatioDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Estacionamento.API.Dominios
{
	public class Patio
	{
		public int Id { get; private set; }
		public string Nome { get; set; }
		public string Endereco { get; private set; }
		public int Capacidade { get; private set; }		
		public int VagasDisponiveis { get; private set; }
		public string Cidade { get; private set; }
		public string Bairro { get; private set; }
		public string UF { get; private set; }
		public double Faturado  { get; private set; }
		[JsonIgnore]
		public virtual IList<VeiculoPatio> Veiculos { get; private set; } = new List<VeiculoPatio>();

		public static Patio CriarPatio(CriarPatioDto patioDto)
		{
			var patio = new Patio()
			{
				Nome = patioDto.Nome.ToUpper(),
				Capacidade = patioDto.Capacidade,
				VagasDisponiveis = patioDto.Capacidade,
				Endereco = patioDto.Endereco.ToUpper(),
				Cidade = patioDto.Cidade.ToUpper(),
				Bairro = patioDto.Bairro.ToUpper(),
				UF = patioDto.UF.ToUpper(),
				Faturado = 0,			
			};

			//new PatioValidacao(patio);

			return patio;
		}		

		public void AlterarNome(string nome)
		{
			if (nome.Length > 32)
				throw new Exception("O Nome não pode ser maior que 32 caracteres");

			this.Nome = nome.ToUpper();
		}
		public void AlterarEndereco(string endereco)
		{
			if (endereco.Length > 64)
				throw new Exception("O Endereço não pode ser maior que 64 caracteres");

			this.Endereco = endereco.ToUpper();
		}
		public void AlterarCidade(string cidade)
		{
			if (cidade.Length > 32)
				throw new Exception("A Cidade não pode ser maior que 32 caracteres");

			this.Cidade = cidade.ToUpper();
		}
		public void AlterarEstado(string uf)
		{
			if (UF.Length > 2)
				throw new Exception("A UF do estado não pode ser maior que 2 caracteres");

			this.UF = uf.ToUpper();
		}
		public void AlterarBairro(string bairro)
		{
			if (bairro.Length > 24)
				throw new Exception("O Bairro não pode ser maior que 24 caracteres");

			this.Bairro = bairro.ToUpper();
		}
		public void AlterarCapacidade( int capacidade)
		{
			if (capacidade < 10)
				throw new Exception("A Capacidade do pátio não pode ser menor que 10 vagas");
			this.Capacidade = capacidade;
		}
		public void AlterarVagasDisponiveis(int veiculo)
		{
			if (veiculo == 1 || veiculo == -1)
			{
				this.VagasDisponiveis += veiculo;
			}
			else
				throw new Exception("O numero de veiculo cadastrado não pode ser diferente de 1");
		}
		public void AlterarFaturadoPatio(double faturado)
		{
			if (faturado < 0)
				throw new Exception("O valordo faturado não pode ser menor que 0");

			Faturado += faturado;
		}
	}
}
