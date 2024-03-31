using AutoMapper;
using PrestameSoft.Application.Features.Loan.Commands.CreateLoan;
using PrestameSoft.Application.Features.Loan.Commands.UpdateLoan;
using PrestameSoft.Application.Features.Loan.Queries.GetAllLoans;
using PrestameSoft.Application.Features.Loan.Queries.GetLoanDetail;
using PrestameSoft.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.MappingProfiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile() 
        { 
            CreateMap<LoanDto, Loan>().ReverseMap();
            CreateMap<Loan, LoanDetailsDto>();
            CreateMap<CreateLoanCommand, Loan>();
            CreateMap<UpdateLoanCommand, Loan>();
        }
    }
}
