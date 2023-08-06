#nullable disable

namespace BookStore.Persistence.Migrations;
using System;
using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Books",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            table.PrimaryKey("PK_Books", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Orders",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            table.PrimaryKey("PK_Orders", x => x.Id));

        migrationBuilder.CreateTable(
            name: "BookOrder",
            columns: table => new
            {
                BooksId = table.Column<int>(type: "int", nullable: false),
                OrdersId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BookOrder", x => new { x.BooksId, x.OrdersId });
                table.ForeignKey(
                    name: "FK_BookOrder_Books_BooksId",
                    column: x => x.BooksId,
                    principalTable: "Books",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_BookOrder_Orders_OrdersId",
                    column: x => x.OrdersId,
                    principalTable: "Orders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_BookOrder_OrdersId",
            table: "BookOrder",
            column: "OrdersId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "BookOrder");

        migrationBuilder.DropTable(
            name: "Books");

        migrationBuilder.DropTable(
            name: "Orders");
    }
}
