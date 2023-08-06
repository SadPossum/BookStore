namespace BookStore.Domain.Orders;
using System;
using System.Collections.Generic;

public class OrderDto
{
    public int Id { get; private set; }
    public string OrderNumber { get; private set; }
    public DateTime OrderDate { get; private set; }
    public IEnumerable<int> BooksIds { get; private set; }

    public OrderDto(int id, string orderNumber, DateTime orderDate, IEnumerable<int> booksIds)
    {
        this.Id = id;
        this.OrderNumber = orderNumber;
        this.OrderDate = orderDate;
        this.BooksIds = booksIds;
    }
}
