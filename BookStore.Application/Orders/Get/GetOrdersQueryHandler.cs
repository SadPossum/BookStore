namespace BookStore.Application.Orders.Get;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Orders;
using MediatR;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, (IEnumerable<OrderDto> Entries, int Count, int TotalCount)>
{
    private readonly IOrderRepository orderRepository;

    public GetOrdersQueryHandler(IOrderRepository orderRepository) => this.orderRepository = orderRepository;

    public async Task<(IEnumerable<OrderDto> Entries, int Count, int TotalCount)> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var (entries, count, totalCount) = await this.orderRepository.GetOrdersAsync(request.OrderNumber, request.OrderDate);
        return (
            entries.Select(a => new OrderDto(a.Id,
                a.OrderNumber,
                a.OrderDate,
                a.Books.Select(a => a.Id)
            )),
            count,
            totalCount
        );
    }
}
