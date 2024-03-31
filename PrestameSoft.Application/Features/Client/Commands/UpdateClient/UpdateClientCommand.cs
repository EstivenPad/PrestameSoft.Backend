using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
