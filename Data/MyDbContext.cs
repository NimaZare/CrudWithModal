using Microsoft.EntityFrameworkCore;

namespace CrudWithModal.Data;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{

    public DbSet<Models.Person> Person { get; set; } = default!;

}
