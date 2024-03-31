using AutoMapper;
using PrestameSoft.Application.Features.Client.Commands.CreateClient;
using PrestameSoft.Application.Features.Client.Commands.UpdateClient;
using PrestameSoft.Application.Features.Client.Queries.GetAllClients;
using PrestameSoft.Application.Features.Client.Queries.GetClientDetail;
using PrestameSoft.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.MappingProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientDto, Client>().ReverseMap();
            CreateMap<Client, ClientDetailsDto>();
            CreateMap<CreateClientCommand, Client>();
            CreateMap<UpdateClientCommand, Client>();
        }
    }
}
