using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreSystem.Application.Models.Products.Queries.GetProductsWithFiltration;
using StoreSystem.Application.Models.Products.Queries.ViewModels;
using StoreSystem.Domain;

namespace StoreSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Получить список товаров с возможностью фильтрации
        /// </summary>
        /// <param name="typeId"> Id типа товара </param>
        /// <param name="isInStock"> Наличие на складе </param>
        /// <param name="price"> Цена </param>
        /// <returns> Список товаров </returns>
        [HttpGet]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductsVm>> GetProductsWithFiltration(Guid? typeId, bool? isInStock, decimal? price)
        {
            var query = new GetProductsWithFiltrationQuery { ProductTypeId = typeId, IsInStock = isInStock, Price = price };
            var vm = await Mediator.Send(query);

            if (vm == null)
            {
                return StatusCode(500);
            }

            if (vm.Products.Count == 0)
            {
                return NoContent();
            }

            return Ok(vm);
        }
    }
}
