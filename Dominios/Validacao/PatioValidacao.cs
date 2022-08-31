using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.API.Dominios.Validacao
{
	public class PatioValidacao : AbstractValidator<Patio>
	{
		public PatioValidacao(Patio patio)
		{
			this.RuleFor(patio => patio.Endereco).NotEmpty()
				.WithMessage("O Endereço do pátio deve ser informado.");

			this.RuleFor(patio => patio.Endereco).MaximumLength(32)
				.WithMessage("O Endereço não pode ser maior que 32 caracteres");

			this.RuleFor(patio => patio.Cidade).NotEmpty()
				.WithMessage("A Cidade do pátio deve ser informado.");

			this.RuleFor(patio => patio.Cidade).MaximumLength(32)
				.WithMessage("A Cidade não pode ser maior que 32 caracteres");

			this.RuleFor(patio => patio.UF).NotEmpty()
				.WithMessage("A UF do pátio deve ser informado.");

			this.RuleFor(patio => patio.UF).MaximumLength(2)
				.WithMessage("A UF do pátio não pode ser maior que 2 caracteres");
		}
	}
}
