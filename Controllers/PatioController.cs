using Estacionamento.API.Dtos.PatioDto;
using Estacionamento.API.Servicos;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Estacionamento.API.Controllers
{
	[ApiController]
	[Route("api/patios")]
	public class PatioController : ControllerBase
	{
		private readonly PatioServico _patioServico;

		public PatioController(PatioServico patioServico)
		{
			_patioServico = patioServico;
		}

		/// <summary>
		/// Cria um novo Patio
		/// </summary>
		[HttpPost]
		public StatusCodeResult CriarPatio([FromBody] CriarPatioDto patioDto)
		{
			if (patioDto == null)
				throw new ArgumentNullException(null, "Objeto patio nulo (não foi informado).");

			this._patioServico.Criar(patioDto);
			return this.StatusCode((int)HttpStatusCode.Created);
		}

		/// <summary>
		/// Obtêm um Pátio por id
		/// </summary>
		[HttpGet("{patio-id}")]
		public OkObjectResult ObterPatioPorId([FromRoute(Name = "patio-id")] int id)
		{
			return Ok(_patioServico.ObterPorId(id));
		}

		/// <summary>
		/// Obtêm todos os Patios
		/// </summary>
		[HttpGet]
		public OkObjectResult ObterTodosOsPatios()
		{
			return Ok(_patioServico.ObterTodos());
		}

		/// <summary>
		/// Altera um Pátio
		/// </summary>
		[HttpPut("{patio-id}")]
		public StatusCodeResult AlterarPatio([FromRoute(Name = "patio-id")] int id, [FromBody] AlterarPatioDto patioDto)
		{	
			_patioServico.Alterar(patioDto, id);
			return StatusCode(204);
		}

		/// <summary>
		/// Exclui um Pátio
		/// </summary>
		[HttpDelete("{patio-id}")]
		public StatusCodeResult DeletarPatio([FromRoute(Name ="patio-id")] int id)
		{
			_patioServico.Excluir(id);
			return StatusCode(204);
		}
	}
}
