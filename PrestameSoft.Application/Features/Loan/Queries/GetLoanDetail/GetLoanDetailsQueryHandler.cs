using AutoMapper;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using PrestameSoft.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Queries.GetLoanDetail
{
    public class GetLoanDetailsQueryHandler : IRequestHandler<GetLoanDetailsQuery, LoanDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _loanRepository;

        public GetLoanDetailsQueryHandler(IMapper mapper, ILoanRepository loanRepository)
        {
            _mapper = mapper;
            _loanRepository = loanRepository;
        }
        public async Task<LoanDetailsDto> Handle(GetLoanDetailsQuery request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetLoanWithDetails(request.Id);

            if (loan is null)
                throw new NotFoundException(nameof(Loan), request.Id);

            var data = _mapper.Map<LoanDetailsDto>(loan);

            return data;
        }
    }
}
