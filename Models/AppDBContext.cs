using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    // d
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            // this.Roles
            // Identity
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach(var entityType in modelBuilder.Model.GetEntityTypes()){
                var tableName = entityType.GetTableName();
                if(tableName.StartsWith("AspNet")){
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }
        // public DbSet<Article> articles { get; set; }
        public DbSet<App.Models.Contact.Contact> Contacts{get;set;}
    }
}