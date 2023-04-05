using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Application.Common.Exceptions;
using StoreSystem.Application.Interfaces;
using StoreSystem.Application.Models.Clients.Queries.ViewModels;
using StoreSystem.Domain;

namespace StoreSystem.Application.Models.Clients.Queries.GetClients
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, ClientsVm>
    {
        private readonly IStoreSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetClientsQueryHandler(IStoreSystemDbContext dbContext, IMapper mapper) 
            => (_dbContext, _mapper)  = (dbContext, mapper);

        public async Task<ClientsVm> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var clientsQuery = await _dbContext.Clients
                .ProjectTo<ClientVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (clientsQuery == null)
            {
                throw new NotFoundException(nameof(Client), "Clients error");
            }

            return new() { Clients = clientsQuery };
        }
    }
}
