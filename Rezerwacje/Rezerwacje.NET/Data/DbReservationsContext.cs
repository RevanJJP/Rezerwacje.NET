using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Rezerwacje.NET.Model;

namespace Rezerwacje.NET.Data
{
    public partial class DbReservationsContext : DbContext
    {
        public DbReservationsContext()
        {
        }

        public DbReservationsContext(DbContextOptions<DbReservationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Room> Room { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning Update database path!
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Development\\Rezerwacje.NET\\Rezerwacje\\Rezerwacje.NET\\Database\\dbReservations.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.From).HasColumnType("date");

                entity.Property(e => e.To).HasColumnType("date");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.GuestId)
                    .HasConstraintName("FK_Reservation_ToGuest");

                entity.HasOne(d => d.RoomNumberNavigation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.RoomNumber)
                    .HasConstraintName("FK_Reservation_ToRoom");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomNumber)
                    .HasName("PK__Room__AE10E07B4932EC2C");

                entity.Property(e => e.RoomNumber).ValueGeneratedNever();

                entity.Property(e => e.PricePerNight).HasColumnType("smallmoney");

                entity.Property(e => e.Type).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
