using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Commands.InactiveLoan
{
    public class InactiveLoanCommandHandler : IRequestHandler<InactiveLoanCommand, Unit>
    {
        private readonly ILoanRepository _loanRepository;

        public InactiveLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Unit> Handle(InactiveLoanCommand request, CancellationToken cancellationToken)
        {
            //Retrieve domain entity object
            var loanToInactive = await _loanRepository.GetByIdAsync(request.Id);

            //Verify that record exist
            if (loanToInactive is null)
                throw new NotFoundException(nameof(Loan), request.Id);

            //Inactive in database
            await _loanRepository.InactiveAsync(loanToInactive);

            return Unit.Value;
        }
    }
}
