using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext: DbContext
    {
        public HotelListingDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id= 1,
                    Name="jamaica",
                    ShortName="JM"
                },
                new Country
                {
                    Id = 2,
                    Name = "Bahamas",
                    ShortName = "BS"
                },
                new Country
                {
                    Id = 3,
                    Name = "Cayman Island",
                    ShortName = "CI"
                }
                );
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
