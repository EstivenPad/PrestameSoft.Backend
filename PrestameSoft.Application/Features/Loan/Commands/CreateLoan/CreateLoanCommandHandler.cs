using AutoMapper;
using MediatR;
using PrestameSoft.Application.Constants;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using PrestameSoft.Application.Features.Loan.Queries.GetAllLoans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _loanRepository;
        private readonly IClientRepository _clientRepository;

        public CreateLoanCommandHandler(IMapper mapper, ILoanRepository loanRepository, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _loanRepository = loanRepository;
            _clientRepository = clientRepository;
        }

        public async Task<int> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateLoanCommandValidator(_clientRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Loan Request", validationResult);

            //Convert to domain entity object
            var loanToCreate = _mapper.Map<Domain.Loan>(request);

            loanToCreate.CapitalRemaining = loanToCreate.Amount;
            loanToCreate.Status = Status.Activo.ToString();
            
            //Add to database
            await _loanRepository.CreateAsync(loanToCreate);

            //Return Unit
            return loanToCreate.Id;
        }
    }
}
