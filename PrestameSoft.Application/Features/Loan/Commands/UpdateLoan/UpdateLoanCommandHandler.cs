using AutoMapper;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Commands.UpdateLoan
{
    public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _loanRepository;
        private readonly IClientRepository _clientRepository;

        public UpdateLoanCommandHandler(IMapper mapper, ILoanRepository loanRepository, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _loanRepository = loanRepository;
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateLoanCommandValidator(_clientRepository, _loanRepository);
            var validationResult = await validator.ValidateAsync(request);
            
            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Loan Request");

            var loanToUpdate = await _loanRepository.GetByIdAsync(request.Id);
            
            loanToUpdate.CapitalRemaining = request.Amount;

            //Convert to domain entity object
            _mapper.Map(request, loanToUpdate);

            //Update in database
            await _loanRepository.UpdateAsync(loanToUpdate);

            return Unit.Value;
        }
    }
}
