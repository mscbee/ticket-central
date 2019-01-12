﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketCentral.Models;

namespace TicketCentral.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20190111174024_userID_Status")]
    partial class userID_Status
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketCentral.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("AdminID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("TicketCentral.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactNumber")
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("HasSubscription");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("OwnerID");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TicketCentral.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("OrganiserEmail")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("VenueBookingID");

                    b.HasKey("EventID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("TicketCentral.Models.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID");

                    b.Property<int>("VenueBookingID");

                    b.HasKey("TicketID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("VenueBookingID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("TicketCentral.Models.Venue", b =>
                {
                    b.Property<int>("VenueID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VenueAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("VenueName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("VenuePostcode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("VenueID");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("TicketCentral.Models.VenueBooking", b =>
                {
                    b.Property<int>("VenueBookingID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate");

                    b.Property<string>("BookingManagerEmail")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("BookingManagerName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("EventID");

                    b.Property<int?>("EventID1");

                    b.Property<int>("VenueID");

                    b.HasKey("VenueBookingID");

                    b.HasIndex("EventID1");

                    b.HasIndex("VenueID");

                    b.ToTable("VenueBooking");
                });

            modelBuilder.Entity("TicketCentral.Models.Ticket", b =>
                {
                    b.HasOne("TicketCentral.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketCentral.Models.VenueBooking", "VenueBooking")
                        .WithMany()
                        .HasForeignKey("VenueBookingID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketCentral.Models.VenueBooking", b =>
                {
                    b.HasOne("TicketCentral.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventID1");

                    b.HasOne("TicketCentral.Models.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
