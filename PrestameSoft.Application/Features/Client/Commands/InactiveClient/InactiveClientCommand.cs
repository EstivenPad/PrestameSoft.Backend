using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Commands.InactiveClient
{
    public class InactiveClientCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
