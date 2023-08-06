namespace BookStore.Application.Orders.Get;
using System;
using System.Collections.Generic;
using BookStore.Domain.Orders;
using MediatR;

public class GetOrdersQuery : IRequest<(IEnumerable<OrderDto> Entries, int Count, int TotalCount)>
{
    public string? OrderNumber { get; set; }
    public DateTime? OrderDate { get; set; }
}
