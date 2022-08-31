using Estacionamento.API.Dtos.VeiculoDto;
using Estacionamento.API.Dtos.VeiculoPatioDto;
using Estacionamento.API.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Estacionamento.API.Controllers
{
	[ApiController]
	[Route("api/veiculos")]
	public class VeiculoController : ControllerBase
	{
		private readonly VeiculoServico _veiculoServico;

		public VeiculoController(VeiculoServico veiculoServico)
		{
			_veiculoServico = veiculoServico;
		}

		[HttpPut("{veiculo-placa}")]
		public StatusCodeResult AlterarVeiculo([FromRoute(Name = "veiculo-placa")] string placa, [FromBody] AlterarVeiculoDto veiculoDto)
		{
			if (veiculoDto == null)
				throw new ArgumentNullException(null, "Objeto veículo nulo (não foi informado).");

			if (string.IsNullOrEmpty(placa))
				throw new Exception("A placa precisa ser informada");

			_veiculoServico.Alterar(veiculoDto, placa);
			return this.StatusCode(200);
		}

		[HttpGet("{veiculo-placa}")]
		public OkObjectResult ObterVeiculoPorPlaca([FromRoute(Name = "veiculo-placa")] string placa)
		{
			if (string.IsNullOrEmpty(placa))
				throw new Exception("A placa precisa ser informada");

			return Ok(_veiculoServico.ObterPorPlaca(placa.ToUpper()));
		}

		[HttpGet]
		public OkObjectResult ObterTodosOsVeiculos()
		{
			return Ok(_veiculoServico.ObterTodos());
		}

		[HttpDelete("{veiculo-placa}")]
		public StatusCodeResult ExcluiVeiculo([FromRoute(Name = "veiculo-placa")] string placa)
		{
			if (string.IsNullOrEmpty(placa))
				throw new Exception("A placa precisa ser informada");

			_veiculoServico.Excluir(placa.ToUpper());
			return this.StatusCode(200);
		}

		[HttpPost("registrar-entrada")]
		public StatusCodeResult RegistrarEntradaVeiculo([FromBody] CriarVeiculoDto veiculoDto ,int IdPatio)
		{
			if (veiculoDto == null)
				throw new Exception("O objeto veículo precisa ser informado.");

			_veiculoServico.RegistrarEntrada(veiculoDto, IdPatio);
			return this.StatusCode(200);
		}

		[HttpPut("registrar-saida")]
		public OkObjectResult RegistraSaidaVeiculo([FromQuery] string placa)
		{
			if (string.IsNullOrEmpty(placa))
				throw new Exception("A placa precisa ser informada");

			return Ok(_veiculoServico.RegistrarSaida(placa.ToUpper()));
		}
		[HttpGet("obter-veiculo-patio/{veiculo-placa}")]
		public OkObjectResult ObterVeiculoPatio([FromRoute(Name = "veiculo-placa")] string placa)
		{
			if (string.IsNullOrEmpty(placa))
				throw new Exception("A placa precisa ser informada");
			
			return Ok(_veiculoServico.ObterVeiculoNoPatioPorPlaca(placa.ToUpper()));
		}

		[HttpGet("obter-veiculos-patios/{patio-id}")]
		public OkObjectResult ObterVeiculosNoPatioEspecifico ([FromRoute(Name ="patio-id")] int patioId)
		{
			return Ok(_veiculoServico.ObterTodosOsVeiculosNoPatioEspecifico(patioId));
		}

		[HttpGet("veiculos-patio")]
		public OkObjectResult ObterTodosOsVeiculosEmTodosOsPatios()
		{
			return Ok(_veiculoServico.ObterTodosVeiculosPatio());
		}
	}
}
