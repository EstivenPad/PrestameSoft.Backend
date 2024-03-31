using FluentValidation;
using PrestameSoft.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Commands.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandValidator(IClientRepository clientRepository)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(12).WithMessage("{PropertyName} must have 10 digits");

            RuleFor(p => p.Identification)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(13).WithMessage("{PropertyName} must have 11 digits")
                .MustAsync(ClientNameUnique).WithMessage("A client already exist with the Identification: {PropertyValue}");

            _clientRepository = clientRepository;
        }

        private Task<bool> ClientNameUnique(string identification, CancellationToken token)
        {
            return _clientRepository.IsClientUnique(identification);
        }
    }
}
