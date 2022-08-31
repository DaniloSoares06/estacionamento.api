using AutoMapper;
using Estacionamento.API.Dominios;
using Estacionamento.API.Dtos.PatioDto;
using Estacionamento.API.Dtos.VeiculoDto;
using Estacionamento.API.Dtos.VeiculoPatioDto;

namespace Estacionamento.API.Perfils
{
	public class DominioParaDto : Profile
	{
		public DominioParaDto()
		{
			CreateMap<Patio, ObterPatioDto>();
			CreateMap<Patio, ObterPatiosDto>();

			CreateMap<Veiculo, ObterVeiculoDto>();

			CreateMap<VeiculoPatio, ObterVeiculosPatioDto>()
				.ForMember(d => d.Placa, opt => opt.MapFrom(o => o.Veiculo.Placa))
				.ForMember(d => d.Proprietario, opt => opt.MapFrom(o => o.Veiculo.Proprietario))
				.ForMember(d => d.Endereco, opt => opt.MapFrom(o => o.Patio.Endereco))
				.ForMember(d => d.VagasDisponiveis, opt => opt.MapFrom(o => o.Patio.VagasDisponiveis))
				.ForMember(d => d.TipoVeiculo, opt => opt.MapFrom(o => o.Veiculo.Tipo));


			CreateMap<VeiculoPatio, ObterVeiculoPatioDto>()
				.ForMember(d => d.Placa, opt => opt.MapFrom(o => o.Veiculo.Placa))
				.ForMember(d => d.Proprietario, opt => opt.MapFrom(o => o.Veiculo.Proprietario))
				.ForMember(d => d.Modelo, opt => opt.MapFrom(o => o.Veiculo.Modelo))
				.ForMember(d => d.VagasDisponiveis, opt => opt.MapFrom(o => o.Patio.VagasDisponiveis))
				.ForMember(d => d.Endereco, opt => opt.MapFrom(o => o.Patio.Endereco))
				.ForMember(d => d.Bairro, opt => opt.MapFrom(o => o.Patio.Bairro))
				.ForMember(d => d.Cidade, opt => opt.MapFrom(o => o.Patio.Cidade));

			CreateMap<VeiculoPatio, RegistrarSaidaDto>()
				.ForMember(d => d.Placa, opt => opt.MapFrom(o => o.Veiculo.Placa))
				.ForMember(d => d.Endereco, opt => opt.MapFrom(o => o.Patio.Endereco));

			CreateMap<VeiculoPatio, ObterVeiculosNoPatioEspecificoDto>()
			.ForMember(d => d.Placa, opt => opt.MapFrom(o => o.Veiculo.Placa))
			.ForMember(d => d.Proprietario, opt => opt.MapFrom(o => o.Veiculo.Proprietario))
			.ForMember(d => d.TipoVeiculo, opt => opt.MapFrom(o => o.Veiculo.Tipo));
		}
	}
}
