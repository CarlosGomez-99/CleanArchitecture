using Microsoft.EntityFrameworkCore;
using StreamCasa.Entities;

namespace StreamCasa.Repository.EFCore
{
    public class StreamCasaDBContext : DbContext
    {
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersVideos> UsersVideos { get; set; }
        public DbSet<Videos> Videos { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=PLSSYSTEM;Initial Catalog=StreamDB;User=sa;password=cgomez99;TrustServerCertificate=True");
        //}
    }
}