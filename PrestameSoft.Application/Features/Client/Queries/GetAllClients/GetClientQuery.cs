using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Queries.GetAllClients
{
    public record GetClientQuery : IRequest<List<ClientDto>>;
}
