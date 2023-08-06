namespace BookStore.Domain.Orders;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Domain.Entities;

public interface IOrderRepository
{
    Task<(IEnumerable<Order> Entries, int Count, int TotalCount)> GetOrdersAsync(
        string? numberSearch,
        DateTime? orderDateSearch = null);

    Task<int> AddOrderAsync(Order order);
}
