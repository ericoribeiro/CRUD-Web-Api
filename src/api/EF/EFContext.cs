using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.EF
{
    public class EFContext : DbContext
    {
        public DbSet<User> Users {get;set;}

        public EFContext()
        {
            
        }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder){
            if(!builder.IsConfigured){
                builder.UseSqlServer("Server=DESKTOP-AAKV0VP;Database=api-crud;Integrated Security=True");
            }
        }
    }
}