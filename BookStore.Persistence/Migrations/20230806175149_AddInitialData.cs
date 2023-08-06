#nullable disable

namespace BookStore.Persistence.Migrations;
using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddInitialData : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Insert data into the Books table
        migrationBuilder.InsertData(
            table: "Books",
            columns: new[] { "Title", "ReleaseDate" },
            values: new object[,]
            {
        { "Book 1", new DateTime(2023, 1, 1) },
        { "Book 2", new DateTime(2023, 2, 1) },
        { "Book 3", new DateTime(2023, 3, 1) },
                // Add more books here as needed
            });

        // Insert data into the Orders table
        migrationBuilder.InsertData(
            table: "Orders",
            columns: new[] { "OrderNumber", "OrderDate" },
            values: new object[,]
            {
        { "ORD001", new DateTime(2023, 1, 15) },
        { "ORD002", new DateTime(2023, 2, 10) },
        { "ORD003", new DateTime(2023, 3, 20) },
                // Add more orders here as needed
            });

        // Insert data into the junction table (BookOrder)
        migrationBuilder.InsertData(
            table: "BookOrder",
            columns: new[] { "BooksId", "OrdersId" },
            values: new object[,]
            {
        { 1, 1 }, // Book 1 is associated with Order 1
        { 2, 2 }, // Book 2 is associated with Order 2
        { 3, 2 }, // Book 3 is also associated with Order 2
        { 2, 3 }, // Book 2 is associated with Order 3 as well
                  // Add more entries here as needed
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Method intentionally left empty.
    }
}
