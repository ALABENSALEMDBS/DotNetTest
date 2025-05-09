﻿// <auto-generated />
using System;
using AM.infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.infrastructure.Migrations
{
    [DbContext(typeof(AMContext))]
    partial class AMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AM.ApplicationCore.domain.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveArrival")
                        .HasColumnType("Date");

                    b.Property<int>("EstimatedDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("Date");

                    b.Property<string>("Pilot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaneFK")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.HasIndex("PlaneFK");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Passenger", b =>
                {
                    b.Property<string>("PassportNumber")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("Date");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelNumber")
                        .HasColumnType("int");

                    b.HasKey("PassportNumber");

                    b.ToTable("Passengers");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaneId"));

                    b.Property<string>("Aireline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("PlaneCapacity");

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("Date");

                    b.Property<int>("PlaneType")
                        .HasColumnType("int");

                    b.HasKey("PlaneId");

                    b.ToTable("MyPlane", (string)null);
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.ReservationTicket", b =>
                {
                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("Date");

                    b.Property<int>("ticket_FK")
                        .HasColumnType("int");

                    b.Property<string>("passenger_FK")
                        .HasColumnType("nvarchar(7)");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.HasKey("DateReservation", "ticket_FK", "passenger_FK");

                    b.HasIndex("passenger_FK");

                    b.HasIndex("ticket_FK");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Classe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.Property<int>("FlightsFlightId")
                        .HasColumnType("int");

                    b.Property<string>("PassengersPassportNumber")
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("FlightsFlightId", "PassengersPassportNumber");

                    b.HasIndex("PassengersPassportNumber");

                    b.ToTable("FlightPass", (string)null);
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Staff", b =>
                {
                    b.HasBaseType("AM.ApplicationCore.domain.Passenger");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("Date");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.ToTable("Staffs", (string)null);
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Traveller", b =>
                {
                    b.HasBaseType("AM.ApplicationCore.domain.Passenger");

                    b.Property<string>("HealthInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Travellers", (string)null);
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Flight", b =>
                {
                    b.HasOne("AM.ApplicationCore.domain.Plane", "Plane")
                        .WithMany("Flights")
                        .HasForeignKey("PlaneFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Passenger", b =>
                {
                    b.OwnsOne("AM.ApplicationCore.domain.FullName", "FullName", b1 =>
                        {
                            b1.Property<string>("PassengerPassportNumber")
                                .HasColumnType("nvarchar(7)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)")
                                .HasColumnName("PassFirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PassLastName");

                            b1.HasKey("PassengerPassportNumber");

                            b1.ToTable("Passengers");

                            b1.WithOwner()
                                .HasForeignKey("PassengerPassportNumber");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.ReservationTicket", b =>
                {
                    b.HasOne("AM.ApplicationCore.domain.Passenger", "Passenger")
                        .WithMany("reservations")
                        .HasForeignKey("passenger_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.ApplicationCore.domain.Ticket", "Ticket")
                        .WithMany("reservations")
                        .HasForeignKey("ticket_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.HasOne("AM.ApplicationCore.domain.Flight", null)
                        .WithMany()
                        .HasForeignKey("FlightsFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.ApplicationCore.domain.Passenger", null)
                        .WithMany()
                        .HasForeignKey("PassengersPassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Staff", b =>
                {
                    b.HasOne("AM.ApplicationCore.domain.Passenger", null)
                        .WithOne()
                        .HasForeignKey("AM.ApplicationCore.domain.Staff", "PassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Traveller", b =>
                {
                    b.HasOne("AM.ApplicationCore.domain.Passenger", null)
                        .WithOne()
                        .HasForeignKey("AM.ApplicationCore.domain.Traveller", "PassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Passenger", b =>
                {
                    b.Navigation("reservations");
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Plane", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("AM.ApplicationCore.domain.Ticket", b =>
                {
                    b.Navigation("reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
