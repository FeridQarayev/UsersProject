using Microsoft.EntityFrameworkCore;
using Project3.Models;

namespace Project3.DAL
{
    public class DataDbContext:DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("User");
        }
    }
}
