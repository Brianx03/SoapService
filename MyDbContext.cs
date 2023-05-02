using SoapService.Models;
using System.Data.Entity;

namespace SoapService
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MyDbContext() : base("name=MyDbContext")
        {
        }
    }
}