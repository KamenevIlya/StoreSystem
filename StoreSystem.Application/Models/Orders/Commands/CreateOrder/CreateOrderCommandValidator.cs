using System;
using FluentValidation;

namespace StoreSystem.Application.Models.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.ClientId).NotEqual(Guid.Empty);
            RuleFor(x => x.OrderItems).NotNull();
        }
    }
}
