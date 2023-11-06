using HotelListing.API.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext: IdentityDbContext<ApiUser>
    {
        public HotelListingDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id=1,
                    Name="Ramada",
                    Address="Tel Aviv",
                    CountryId=1,
                    Rating=4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Hilton",
                    Address = "Ramat gan",
                    CountryId = 2,
                    Rating = 3.5
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Sheraton",
                    Address = "Tel Aviv",
                    CountryId = 3,
                    Rating = 4
                }
                );
        }
    }
}
