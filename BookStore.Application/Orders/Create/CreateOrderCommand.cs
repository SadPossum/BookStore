namespace BookStore.Application.Orders.Create;

using BookStore.Domain.Orders;
using MediatR;

public class CreateOrderCommand : IRequest<int?>
{
    public OrderDto? OrderDto { get; set; }
}
