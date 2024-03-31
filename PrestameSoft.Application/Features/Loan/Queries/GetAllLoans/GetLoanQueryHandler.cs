using AutoMapper;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Features.Client.Queries.GetClientDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Queries.GetAllLoans
{
    public class GetLoanQueryHandler : IRequestHandler<GetLoanQuery, List<LoanDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _loanRepository;

        public GetLoanQueryHandler(IMapper mapper, ILoanRepository loanRepository)
        {
            _mapper = mapper;
            _loanRepository = loanRepository;
        }

        public async Task<List<LoanDto>> Handle(GetLoanQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var loans = await _loanRepository.GetAsync();

            //Convert data objects to DTO objects
            var data = _mapper.Map<List<LoanDto>>(loans);

            //Return list DTO objects
            return data;
        }
    }
}
