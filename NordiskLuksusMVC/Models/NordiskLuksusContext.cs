using Microsoft.EntityFrameworkCore;

namespace NordiskLuksusMVC.Models{

    public class NordiskLuksusContext:DbContext{
        public NordiskLuksusContext(DbContextOptions<NordiskLuksusContext> options):base(options){}

        public DbSet<Product> Product {get; set;}

        public DbSet<CustomerOrder> CustomerOrder {get; set;}
    }
}