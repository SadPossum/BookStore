namespace BookStore.Persistence;

using BookStore.Domain.Books;
using BookStore.Domain.Orders;
using BookStore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Класс с методами расширения для более удобного внедрения зависимостей
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration
                .GetConnectionString("DefaultConnection")));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}





