namespace BookStore.Persistence.Repositories;

using BookStore.Domain.Entities;
using BookStore.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

internal class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext context;
    private readonly ILogger<OrderRepository> logger;

    public OrderRepository(ApplicationDbContext context, ILogger<OrderRepository> logger)
    {
        this.context = context;
        this.logger = logger;
    }

    public async Task<(IEnumerable<Order> Entries, int Count, int TotalCount)> GetOrdersAsync(
        string? numberSearch,
        DateTime? orderDateSearch = null)
    {
        this.logger.LogDebug($"Retrieving list of {nameof(Order)} items");

        var query = this.context.Orders.Include(a => a.Books)
            .AsQueryable();
        var totalCount = await this.context.Orders.CountAsync();

        if (numberSearch != null)
        {
            query = query.Where(a => a.OrderNumber == numberSearch);
        }

        if (orderDateSearch != null)
        {
            query = query.Where(a => a.OrderDate == orderDateSearch);
        }

        var count = await query.CountAsync();

        IEnumerable<Order> entries = await query.ToListAsync();
        return (entries, count, totalCount);
    }

    public async Task<int> AddOrderAsync(Order order)
    {
        this.logger.LogDebug($"Adding {nameof(order)}");
        await this.context.Orders.AddAsync(order);
        await this.context.SaveChangesAsync();
        return order.Id;
    }
}
