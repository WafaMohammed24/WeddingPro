using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Wedding.Models
{
    public partial class WeddingContext : DbContext
    {
        public WeddingContext()
        {
        }

        public WeddingContext(DbContextOptions<WeddingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Package> Packages { get; set; } = null!;
        public virtual DbSet<PackageService> PackageServices { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;
        public virtual DbSet<Wallet> Wallets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0S485TL\\MSSQLSERVER01;Database=Wedding;Trusted_Connection = yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Bookings__Client__3F466844");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Bookings__Servic__403A8C7D");
            });

            modelBuilder.Entity<PackageService>(entity =>
            {
                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageServices)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK__PackageSe__Packa__44FF419A");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.PackageServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__PackageSe__Servi__45F365D3");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Payments__Bookin__49C3F6B7");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Reviews__ClientI__4CA06362");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Reviews__Service__4D94879B");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK__Services__Vendor__3C69FB99");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Wallets__ClientI__5165187F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
