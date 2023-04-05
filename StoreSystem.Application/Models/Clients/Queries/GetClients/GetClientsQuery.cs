using MediatR;
using StoreSystem.Application.Models.Clients.Queries.ViewModels;

namespace StoreSystem.Application.Models.Clients.Queries.GetClients
{
    public class GetClientsQuery : IRequest<ClientsVm>
    {
    }
}
