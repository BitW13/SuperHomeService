using Common.Entity.ShoppingPlannerService;
using Microsoft.EntityFrameworkCore;

namespace ShoppingPlannerService.Dal.Context
{
    public class ShoppingPlannerServiceContext: DbContext
    {
        public ShoppingPlannerServiceContext(DbContextOptions<ShoppingPlannerServiceContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<TypeOfPurchase> TypeOfPurchases { get; set; }

        public DbSet<ShoppingCategory> ShoppingCategories { get; set; }
    }
}
