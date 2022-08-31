using AutoMapper;
using Estacionamento.API.Contexto;
using Estacionamento.API.Dominios;
using Estacionamento.API.Dtos.VeiculoDto;
using Estacionamento.API.Dtos.VeiculoPatioDto;
using Estacionamento.API.Enum;
using Estacionamento.API.InterfacesServico;
using Estacionamento.API.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Servicos
{
	public class VeiculoServico : IVeiculoServico
	{
		private readonly EstacionamentoContexto _estacionamentoContexto;
		private readonly VeiculoPatioRepositorio _veiculoPatioRepositorio;
		private readonly VeiculoRepositorio _veiculoRepositorio;
		private IMapper _mapper;
		private readonly PatioServico _patioServico;

		public VeiculoServico(EstacionamentoContexto estacionamentoContexto, IMapper mapper, PatioServico patioServico, VeiculoPatioRepositorio veiculoPatioRepositorio, VeiculoRepositorio veiculoRepositorio)
		{
			_estacionamentoContexto = estacionamentoContexto;
			_mapper = mapper;
			_patioServico = patioServico;
			_veiculoPatioRepositorio = veiculoPatioRepositorio;
			_veiculoRepositorio = veiculoRepositorio;
		}

		private Veiculo Criar(CriarVeiculoDto veiculoDto)
		{
			var veiculo = Veiculo.CriarVeiculo(veiculoDto);

			_veiculoRepositorio.Adicionar(veiculo);

			return veiculo;			
		}

		public void Alterar(AlterarVeiculoDto veiculoDto, string placa)
		{
			var veiculoObtido = ObterVeiculoDominio(placa);

			veiculoObtido.AlterarVeiculo(veiculoDto);

			_veiculoRepositorio.Atualizar(veiculoObtido);
		}

		public ObterVeiculoDto ObterPorPlaca(string placa)
		{
			var veiculoObtido = ObterVeiculoDominio(placa);

			var veiculoDto = _mapper.Map<ObterVeiculoDto>(veiculoObtido);

			return veiculoDto;
		}

		public IList<ObterVeiculoDto> ObterTodos()
		{
			var veiculos = _veiculoRepositorio.ObterTodos();
			if (veiculos != null)
			{
				List<ObterVeiculoDto> veiculosDto = _mapper.Map<List<ObterVeiculoDto>>(veiculos);
				return veiculosDto;
			}
			else
				throw new Exception("Não existe veículo Cadastrado");
		}

		public void Excluir(string placa)
		{
			var veiculoObtido = ObterVeiculoDominio(placa);

			_veiculoRepositorio.Excluir(veiculoObtido);
		}

		public void RegistrarEntrada(CriarVeiculoDto veiculodto, int patioId)
		{
			var veiculo = Criar(veiculodto);

			if (VerificarSeNaoExisteVaga(patioId))
				throw new Exception("O pátio estar lotado não existe vaga");

			if (VerificarSeExisteVeiculoComMesmaPlacaNoPatio(veiculo.Placa, patioId ))
				throw new Exception("Já existe um veículo com essa placa no pátio.");

			if (VerificarSeVeiculoEstarAtivoEmAlgumPatio(veiculo.Placa))
				throw new Exception("Este veículo estar estacionado em algum pátio no momento.");

			var patioObtido = _patioServico.ObterPorId(patioId);			

			var veiculoCadastrado = new VeiculoPatio(patioObtido.Id, veiculo.Id) { };						
			
			_veiculoPatioRepositorio.Adicionar(veiculoCadastrado);

			veiculoCadastrado.Patio.AlterarVagasDisponiveis(-1);

			_veiculoPatioRepositorio.Atualizar(veiculoCadastrado);

		}
		public RegistrarSaidaDto RegistrarSaida(string placa)
		{
			var veiculoObtido = ObterVeiculoPatioDominio(placa);

			var valorASerCobrado = CalcularValorParaSerCobrado(placa);

			veiculoObtido.AlterarAtivo(false);
			veiculoObtido.Patio.AlterarFaturadoPatio(valorASerCobrado);
			veiculoObtido.Patio.AlterarVagasDisponiveis(+1);

			_veiculoPatioRepositorio.Atualizar(veiculoObtido);

			var veiculoDto = _mapper.Map<RegistrarSaidaDto>(veiculoObtido);
			return veiculoDto;
		}

		public ObterVeiculoPatioDto ObterVeiculoNoPatioPorPlaca(string placa)
		{
			var veiculoObtido = ObterVeiculoPatioDominio(placa);
			CalcularValorParaSerCobrado(placa);

			var veiculo = _mapper.Map<ObterVeiculoPatioDto>(veiculoObtido);
			return veiculo;
		}
		public IList<ObterVeiculosNoPatioEspecificoDto> ObterTodosOsVeiculosNoPatioEspecifico(int patioId)
		{
			var veiculosNoPatio = _estacionamentoContexto.VeiculoPatios.Where(p => p.PatioId == patioId && p.Ativo == true).ToList();
			foreach (var v in veiculosNoPatio)
			{
				CalcularValorParaSerCobrado(v.Veiculo.Placa);
			}

			List<ObterVeiculosNoPatioEspecificoDto> veiculos = _mapper.Map<List<ObterVeiculosNoPatioEspecificoDto>>(veiculosNoPatio);

			return veiculos;
		}
		public IList<ObterVeiculosPatioDto> ObterTodosVeiculosPatio()
		{
			var veiculos = _veiculoRepositorio.ObterTodosVeiculosNoPatio();

			if (veiculos != null)
			{
				List<ObterVeiculosPatioDto> veiculosDto = _mapper.Map<List<ObterVeiculosPatioDto>>(veiculos);			
				return veiculosDto;
			}
			else
				throw new Exception("Não existe veículos cadastrados");
		}

		//Métodos privados

		#region

		private VeiculoPatio ObterVeiculoPatioDominio(string placa)
		{
			var veiculoObtido = _estacionamentoContexto.VeiculoPatios.Where(v => v.Veiculo.Placa == placa && v.Ativo == true).FirstOrDefault();
			if (veiculoObtido == null)
				throw new Exception($"O veículo com essa '{placa}' não se encontra no pátio");

			return veiculoObtido;
		}
		private Veiculo ObterVeiculoDominio(string placa)
		{
			var veiculo = _estacionamentoContexto.Veiculos.Where(v => v.Placa == placa).FirstOrDefault();
			if (veiculo != null)
				return veiculo;
			else
				throw new Exception("O veiculo informado não existe");
		}	
		private bool VerificarSeExisteVeiculoComMesmaPlacaNoPatio(string placa, int patioId)
		{
			var veiculoComMesmaPlaca = _estacionamentoContexto.VeiculoPatios.Where(p => p.Veiculo.Placa == placa && p.Ativo == true && p.PatioId == patioId) .FirstOrDefault();
			if (veiculoComMesmaPlaca != null)
				return true;

			return false;
		}
		
		private bool VerificarSeVeiculoEstarAtivoEmAlgumPatio(string placa)
		{
			var veiculoAtivo = _estacionamentoContexto.VeiculoPatios.Where(v => v.Veiculo.Placa == placa && v.Ativo == true).FirstOrDefault();
			if (veiculoAtivo != null)
				return true;

			return false;			
		}

		private bool VerificarSeNaoExisteVaga(int patioId)
		{
			var patio = _estacionamentoContexto.VeiculoPatios.Where(p => p.PatioId == patioId).FirstOrDefault();

			if (patio.Patio.VagasDisponiveis < 1)
				return true;

			return false;				
		}

		private double CalcularValorParaSerCobrado(string placa)
		{
			var veiculoObtido = ObterVeiculoPatioDominio(placa);

			veiculoObtido.AlterarHoraSaida(DateTime.Now);

			TimeSpan tempoPermanencia = veiculoObtido.HoraSaida - veiculoObtido.HoraEntrada;

			double valorASerCobrado = 0;

			if (veiculoObtido.Veiculo.Tipo == TipoVeiculoEnum.Automovel)
			{		
				valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2 * 5  ;

			}
			else if (veiculoObtido.Veiculo.Tipo == TipoVeiculoEnum.Moto)
			{
				valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1 * 3;
			}

			var valorFinal = valorASerCobrado + 5;
			veiculoObtido.AlterarValor(valorFinal);

			return veiculoObtido.Valor;
		}
		#endregion
	}
}