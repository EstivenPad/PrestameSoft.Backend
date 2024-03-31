using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Queries.GetClientDetail
{
    public record GetClientDetailsQuery(int Id) : IRequest<ClientDetailsDto>;
}
