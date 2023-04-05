using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreSystem.Application.Models.Orders.Commands.CreateOrder;
using StoreSystem.Application.Models.Orders.Commands.DeleteOrder;
using StoreSystem.Application.Models.Orders.Commands.UpdateOrder;
using StoreSystem.Application.Models.Orders.Queries.GetOrderById;
using StoreSystem.Application.Models.Orders.Queries.GetOrdersByClientAndDate;
using StoreSystem.Application.Models.Orders.Queries.ViewModels;
using StoreSystem.WebApi.Models.OrderModel;

namespace StoreSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Получить заказ по Id
        /// </summary>
        /// <param name="id"> Id заказа </param>
        /// <returns> Заказ </returns>
        [HttpGet("{id}")]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrdersVm>> GetOrderById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest($"Не заполнен параметр: {nameof(id)}");
            }

            var query = new GetOrderByIdQuery { Id = id };
            var vm = await Mediator.Send(query);

            if (vm == null)
            {
                return NotFound($"Не найден заказ с Id: {id}");
            }

            return Ok(vm);
        }

        /// <summary>
        /// Получить список заказов по клиенту и датам
        /// </summary>
        /// <param name="clientId"> Id клиента </param>
        /// <param name="dateFrom"> От </param>
        /// <param name="dateTo"> До </param>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrdersVm>> GetOrderByClientAndDate(Guid clientId, DateTime dateFrom, DateTime dateTo)
        {
            if (clientId == Guid.Empty)
            {
                return BadRequest($"Не заполнен параметр: {nameof(clientId)}");
            }

            if (dateFrom == DateTime.MinValue)
            {
                return BadRequest($"Не заполнен параметр: {nameof(dateFrom)}");
            }

            if (dateTo == DateTime.MinValue)
            {
                return BadRequest($"Не заполнен параметр: {nameof(dateTo)}");
            }

            var query = new GetOrdersByClientAndDateQuery
            {
                ClientId = clientId,
                DateFrom = dateFrom,
                DateTo = dateTo
            };
            var vm = await Mediator.Send(query);

            if (vm == null)
            {
                return StatusCode(500);
            }

            return Ok(vm);
        }

        /// <summary>
        /// Создать заказ
        /// </summary>
        /// <param name="request"> Тело запроса </param>
        /// <returns> Id созданного заказа </returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var command = _mapper.Map<CreateOrderCommand>(request);
            var orderId = await Mediator.Send(command);
            return Ok(orderId);
        }

        /// <summary>
        /// Обновить заказ
        /// </summary>
        /// <param name="request"> Тело запроса </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderRequest request)
        {
            var command = _mapper.Map<UpdateOrderCommand>(request);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="id"> Id заказа </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var command = new DeleteOrderCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
