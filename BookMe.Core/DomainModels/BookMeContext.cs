using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookMe.Core.DomainModels
{
    public partial class BookMeContext : DbContext
    {
        public BookMeContext()
        {
        }

        public BookMeContext(DbContextOptions<BookMeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booker> Bookers { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelFacility> HotelFacilities { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomBooking> RoomBookings { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booker>(entity =>
            {
                entity.ToTable("Booker");

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(150);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.HasOne(d => d.Booker)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BookerId)
                    .HasConstraintName("FK_Booking_Booker");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Booking_Customer");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.ContactNumber).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("Facility");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.ImageUrl).HasMaxLength(250);

                entity.Property(e => e.Location).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Hotel_City");
            });

            modelBuilder.Entity<HotelFacility>(entity =>
            {
                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.HotelFacilities)
                    .HasForeignKey(d => d.FacilityId)
                    .HasConstraintName("FK_HotelFacilities_Facility");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelFacilities)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelFacilities_Hotel");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.Rating1)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Rating");

                entity.Property(e => e.Review).HasMaxLength(1000);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Rating_Customer");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Rating_Hotel");
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.ToTable("Rent");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK_Rent_RoomType");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Rooms_Hotel");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK_Rooms_RoomType");
            });

            modelBuilder.Entity<RoomBooking>(entity =>
            {
                entity.ToTable("RoomBooking");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_RoomBooking_Booking");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_RoomBooking_Rooms");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("RoomType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type).HasMaxLength(150);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.RoomTypes)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_RoomType_Hotel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
