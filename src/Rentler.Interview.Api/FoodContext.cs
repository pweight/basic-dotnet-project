using Microsoft.EntityFrameworkCore;

namespace Rentler.Interview.Api
{
    public class FoodContext : DbContext
  {

      public FoodContext()
      {

      }

      public FoodContext(DbContextOptions<FoodContext> options)
        : base(options)
      {

      }

      public DbSet<Food> Foods { get; set; }
  }
}