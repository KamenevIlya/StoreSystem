using System;
using FluentValidation;

namespace StoreSystem.Application.Models.Orders.Queries.GetOrdersByClientAndDate
{
    public class GetOrdersByClientAndDateValidator : AbstractValidator<GetOrdersByClientAndDateQuery>
    {
        public GetOrdersByClientAndDateValidator()
        {
            RuleFor(x => x.DateFrom).NotEqual(default(DateTime));
            RuleFor(x => x.DateTo).NotEqual(default(DateTime));
            RuleFor(x => x.ClientId).NotEqual(Guid.Empty);
        }
    }
}
