namespace BookStore.Persistence;

using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

internal class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books => this.Set<Book>();
    public DbSet<Order> Orders => this.Set<Order>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
}

