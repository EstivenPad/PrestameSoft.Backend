using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Commands.DeleteLoan
{

    public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, Unit>
    {
        private readonly ILoanRepository _loanRepository;

        public DeleteLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            //Retrieve domain entity object
            var loanToDelete = await _loanRepository.GetByIdAsync(request.Id);

            //Verify that record exist
            if (loanToDelete is null)
                throw new NotFoundException(nameof(Loan), request.Id);
            
            //Delete in database
            await _loanRepository.DeleteAsync(loanToDelete);

            return Unit.Value;
        }
    }
}
