using ElectronicStorage.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicStorage.Persistence
{
    public class ElectronicStorageContext : DbContext
    {
        public ElectronicStorageContext(DbContextOptions<ElectronicStorageContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ElectronicStorage.db");
        }
    }
}