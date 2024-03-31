using FluentValidation;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Commands.CreateLoan
{
    public class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
    {
        private readonly IClientRepository _clientRepository;

        public CreateLoanCommandValidator(IClientRepository clientRepository)
        {
            RuleFor(l => l.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(l => l.ClientId)
                .GreaterThan(0)
                .MustAsync(ClientMustExist).WithMessage("Client doesn't exist");

            _clientRepository = clientRepository;
        }

        private async Task<bool> ClientMustExist(int clientId, CancellationToken token)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);
            return client != null;            
        }
    }
}
