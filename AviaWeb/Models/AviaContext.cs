using Microsoft.EntityFrameworkCore;

namespace AviaWeb.Models
{
    public class AviaContext : DbContext
    {
        public AviaContext(DbContextOptions<AviaContext> options)
        : base(options)
        {
            Database.EnsureCreated();   
        }
        public DbSet<Document> Documents { get; set; } = default!;
        public DbSet<Passenger> Passengers { get; set; }=default!;
        public DbSet<AirTicket> AirTickets { get; set; }=default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Passenger>()
                       .HasMany(a => a.AirTickets)
                       .WithOne(p => p.Passenger)
                       .HasForeignKey(p => p.PassengerId);

            modelBuilder.Entity<Passenger>()
                        .HasMany(p => p.Documents)
                        .WithOne(d => d.Passenger)
                        .HasForeignKey(d => d.PassengerId);

            Passenger pass1 = new Passenger { Id = 1, LastName = "LN1", FirstName = "FN1", Patronical = "PAT1" };
            Passenger pass2 = new Passenger { Id = 2, LastName = "LN2", FirstName = "FN2", Patronical = "PAT2" };
            Passenger pass3 = new Passenger { Id = 3, LastName = "LN3", FirstName = "FN3", Patronical = "PAT3" };
            Passenger pass4 = new Passenger { Id = 4, LastName = "LN4", FirstName = "FN4", Patronical = "PAT4" };

            modelBuilder.Entity<Passenger>().HasData(pass1, pass2, pass3, pass4);

            AirTicket ticket1 = new AirTicket
            {
                Id = 1,
                Departure = "Moscow",
                Arrival = "SaintPetersburg",
                DateOfConclusion = new DateTime(2023, 9, 20, 10, 15, 0),
                DepartureDate = new DateTime(2023, 9, 25, 14, 35, 0),
                ArrivalDate = new DateTime(2023, 9, 26, 13, 15, 0),
                Company = "AeroFlight",
                PassengerId = 1
            };

            AirTicket ticket2 = new AirTicket
            {
                Id = 2,
                Departure = "Samara",
                Arrival = "Moscow",
                DateOfConclusion = new DateTime(2023, 9, 22, 16, 35, 0),
                DepartureDate = new DateTime(2023, 9, 26, 18, 54, 0),
                ArrivalDate = new DateTime(2023, 9, 27, 00, 55, 0),
                Company = "TopAirlines",
                PassengerId = 1
            };

            AirTicket ticket3 = new AirTicket
            {
                Id = 3,
                Departure = "Tumen",
                Arrival = "Ekaterinburg",
                DateOfConclusion = new DateTime(2023, 9, 26, 19, 54, 0),
                DepartureDate = new DateTime(2023, 9, 27, 10, 54, 0),
                ArrivalDate = new DateTime(2023, 9, 28, 11, 54, 0),
                Company = "AeroFlight",
                PassengerId = 2
            };

            AirTicket ticket4 = new AirTicket
            {
                Id = 4,
                Departure = "Tumen",
                Arrival = "Ekaterinburg",
                DateOfConclusion = new DateTime(2023, 9, 27, 15, 35, 0),
                DepartureDate = new DateTime(2023, 9, 29, 16, 35, 0),
                ArrivalDate = new DateTime(2023, 9, 30, 18, 35, 0),
                Company = "TopAirlines",
                PassengerId = 3
            };

            AirTicket ticket5 = new AirTicket
            {
                Id = 5,
                Departure = "Kurgan",
                Arrival = "Moscow",
                DateOfConclusion = new DateTime(2023, 9, 27, 17, 35, 0),
                DepartureDate = new DateTime(2023, 9, 30, 18, 35, 0),
                ArrivalDate = new DateTime(2023, 10, 1, 18, 35, 0),
                Company = "SevenAirlines",
                PassengerId = 4
            };

            modelBuilder.Entity<AirTicket>().HasData(ticket1, ticket2, ticket3, ticket4, ticket5);

            Document document1 = new Document { Id = 1, Type = "Passport1", PassengerId = pass1.Id};
            Document document2 = new Document { Id = 2, Type = "Passport2", PassengerId = pass1.Id };
            Document document3 = new Document { Id = 3, Type = "Passport3", PassengerId = pass2.Id };
            Document document4 = new Document { Id = 4, Type = "Passport4", PassengerId = pass3.Id };
            Document document5 = new Document { Id = 5, Type = "Passport5", PassengerId = pass3.Id };
            Document document6 = new Document { Id = 6, Type = "Passport6", PassengerId = pass3.Id };


            modelBuilder.Entity<Document>().HasData(document1, document2, document3, document4, document5, document6);
        }
    }
}

