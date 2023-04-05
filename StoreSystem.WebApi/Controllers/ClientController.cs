using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreSystem.Application.Models.Clients.Queries.GetClients;
using StoreSystem.Application.Models.Clients.Queries.ViewModels;

namespace StoreSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : BaseController
    {
        private readonly IMapper _mapper;

        public ClientController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClientsVm>> GetAllClients()
        {
            var query = new GetClientsQuery();
            var vm = await Mediator.Send(query);

            if (vm == null)
            {
                return StatusCode(500);
            }

            if (vm.Clients.Count == 0)
            {
                return NoContent();
            }

            return Ok(vm);
        }
    }
}
