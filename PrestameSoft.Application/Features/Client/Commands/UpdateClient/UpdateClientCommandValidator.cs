using FluentValidation;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Features.Client.Commands.CreateClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Commands.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandValidator(IClientRepository clientRepository)
        {
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(ClientMustExist);

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
                .Length(13).WithMessage("{PropertyName} must have 11 digits");

            _clientRepository = clientRepository;
        }

        private async Task<bool> ClientMustExist(int id, CancellationToken token)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            return client != null;
        }

        private Task<bool> ClientNameUnique(string identification, CancellationToken token)
        {
            return _clientRepository.IsClientUnique(identification);
        }
    }
}
