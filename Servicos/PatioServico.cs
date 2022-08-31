using AutoMapper;
using Estacionamento.API.Contexto;
using Estacionamento.API.Dominios;
using Estacionamento.API.Dtos.PatioDto;
using Estacionamento.API.InterfacesServico;
using Estacionamento.API.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento.API.Servicos
{
	public class PatioServico : IPatioServico
	{
		private readonly EstacionamentoContexto _estacionamentoContexto;
		private readonly PatioRepositorio _patioRepositorio;
		private IMapper _mapper;

		public PatioServico(EstacionamentoContexto estacionamentoContexto, IMapper mapper, PatioRepositorio patioRepositorio)
		{
			_estacionamentoContexto = estacionamentoContexto;
			_mapper = mapper;
			_patioRepositorio = patioRepositorio;
		}

		public void Criar(CriarPatioDto patioDto)
		{
			if (VerificarSeExistePatioComMesmoEndereco(patioDto.Endereco))
				throw new Exception("Já existe um patio cadastrado nesse endereço.");

			var patio = Patio.CriarPatio(patioDto);

			_patioRepositorio.Adicionar(patio);
		}
			

		public void Alterar(AlterarPatioDto patioDto, int id)
		{
			if (VerificarSeExistePatioComMesmoEndereco(patioDto.Endereco))
				throw new Exception("Já existe um patio cadastrado nesse email.");

			var patio = this.ObterPatioDominio(id);

			patio.AlterarCapacidade(patioDto.Capacidade);
			patio.AlterarEndereco(patioDto.Endereco);
			patio.AlterarCidade(patioDto.Cidade);
			patio.AlterarEstado(patioDto.UF);

			_patioRepositorio.Atualizar(patio);
		}

		public ObterPatioDto ObterPorId(int id)
		{
			var patioObtido = ObterPatioDominio(id);

			ObterPatioDto patioDto = _mapper.Map<ObterPatioDto>(patioObtido);
			return patioDto;
		}

		public IList<ObterPatiosDto> ObterTodos()
		{
			var patios = _patioRepositorio.ObterTodos();
			if (patios != null)
			{
				List<ObterPatiosDto> patiosDto = _mapper.Map<List<ObterPatiosDto>>(patios);
				return patiosDto;
			}
			else
				throw new Exception(" Não existe pátio cadastrado no sistema");
		}

		public void Excluir(int id)
		{
			var patio = this.ObterPatioDominio(id);

			_patioRepositorio.Excluir(patio);
		}

		private Patio ObterPatioDominio(int id)
		{
			var patio = _estacionamentoContexto.Patios.Where(P => P.Id == id).FirstOrDefault();
			if (patio != null)
				return patio;
			else
				throw new Exception("O Patio com este Id não existe");
		}

		private bool VerificarSeExistePatioComMesmoEndereco(string endereco)
		{
			var patioComMesmoEndereco = _estacionamentoContexto.Patios.Where(p => p.Endereco == endereco).FirstOrDefault();
			if (patioComMesmoEndereco != null)
				return true;

			return false;
		}
	}
}
