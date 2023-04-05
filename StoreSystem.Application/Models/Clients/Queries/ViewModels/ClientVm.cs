using System;
using AutoMapper;
using StoreSystem.Application.Common.Mappings;
using StoreSystem.Domain;

namespace StoreSystem.Application.Models.Clients.Queries.ViewModels
{
    public class ClientVm : IMapWith<Client>
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Client, ClientVm>()
                .ForMember(clientVm => clientVm.Id,
                    opt => opt.MapFrom(client => client.Id))
                .ForMember(clientVm => clientVm.FullName,
                    opt => opt.MapFrom(client => client.FullName))
                .ForMember(clientVm => clientVm.PhoneNumber,
                    opt => opt.MapFrom(client => client.PhoneNumber));
        }
    }
}
