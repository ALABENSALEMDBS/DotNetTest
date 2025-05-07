using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;
using AM.infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AM.infrastructure
{
    public class AMContext : DbContext
    {
        //(1)============> DbSet
        public DbSet<Flight> Flights { get; set; }
        public DbSet <Passenger> Passengers { get; set; }
        public DbSet<Plane> planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        public DbSet<Ticket> Ticket { get; set; }

        public DbSet<ReservationTicket> Reservations { get; set; }

        //(2)============> Chaine de connexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=BDDSE5;Integrated Security=true; MultipleActiveResultSets = true"); 
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //*************** 1er methode avec class de configuration **********************
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());


            //************* 2er methode  sans class de configuration ***********************
            //   modelBuilder.Entity<Plane>().HasKey(a => a.PlaneId);
            //   modelBuilder.Entity<Plane>().ToTable("MyPlane")
            //       .Property(capa => capa.Capacity).HasColumnName("PlaneCapacity");


            // **********   renommé table associative ******************
            modelBuilder.Entity<Flight>().HasMany(f => f.Passengers).WithMany(p => p.Flights).UsingEntity(t=>t.ToTable("FlightPass"));

            // Q II 5. b.   clé etranger
            modelBuilder.Entity<Plane>().HasMany(p=>p.Flights).WithOne(f=>f.Plane).HasForeignKey(fk=>fk.PlaneFK).OnDelete(DeleteBehavior.Cascade);
           
            modelBuilder.ApplyConfiguration(new FullNameConfiguration());

            //************* config  heritage table par heararchi
           // modelBuilder.Entity<Passenger>().HasDiscriminator<int>("PassengerType").HasValue<Passenger>(0).HasValue<Traveller>(1).HasValue<Staff>(2);

            //config TPT: table par type  ==> separer staff et traveller de passenger 
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");


            //********** config clé primaire composé
            modelBuilder.Entity<ReservationTicket>().HasKey(k => new { k.DateReservation,k.ticket_FK,k.passenger_FK });
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
        }



    }
}
