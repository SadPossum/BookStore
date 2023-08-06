namespace BookStore.Application.Orders.Create;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Entities;
using BookStore.Domain.Orders;
using MediatR;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int?>
{
    private readonly IOrderRepository orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository) => this.orderRepository = orderRepository;

    public async Task<int?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderDto = request.OrderDto;

        if (orderDto == null)
        {
            return null;
        }

        var order = new Order()
        {
            Id = orderDto.Id,
            OrderNumber = orderDto.OrderNumber,
            OrderDate = orderDto.OrderDate,
            Books = orderDto.BooksIds.Select(a => new Book()
            {
                Id = a,
                Title = "",
                Orders = new(),
            }
            ).ToList() ?? new List<Book>()
        };

        var orderId = await this.orderRepository.AddOrderAsync(order);

        return orderId;
    }
}
