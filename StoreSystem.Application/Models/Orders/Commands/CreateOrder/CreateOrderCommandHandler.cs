using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Application.Interfaces;
using StoreSystem.Domain;

namespace StoreSystem.Application.Models.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IStoreSystemDbContext _dbContext;
        public CreateOrderCommandHandler(IStoreSystemDbContext dbContext) => 
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                ClientId = request.ClientId
            };

            var orderItems = request.OrderItems;
            var productsInOrder = orderItems.Select(orderItem => (orderItem.ProductId, orderItem.Quantity)).ToList();

            foreach (var productInOrder in productsInOrder)
            {
                var (productId, quantity) = productInOrder;
                var product = await _dbContext.Products
                    .FirstOrDefaultAsync(prod => prod.Id == productId, cancellationToken);
                if (product == null || quantity > product.Quantity)
                {
                    return Guid.Empty;
                }

                product.Quantity -= quantity;
            }

            foreach (var orderItem in orderItems)
            {
                orderItem.Id = Guid.NewGuid();
                orderItem.OrderId = order.Id;
            }

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.OrderItems.AddRangeAsync(orderItems, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
