using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Models
{
    public partial class Service
    {
        public Service()
        {
            Bookings = new HashSet<Booking>();
            PackageServices = new HashSet<PackageService>();
            Reviews = new HashSet<Review>();
        }

        [Key]
        [Column("ServiceID")]
        public int ServiceId { get; set; }
        [Column("VendorID")]
        public int? VendorId { get; set; }
        [StringLength(100)]
        public string? ServiceName { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Price { get; set; }
        [StringLength(50)]
        public string? AvailabilityDays { get; set; }
        public string? ServiceDescription { get; set; }
        [StringLength(255)]
        public string? ImagePath { get; set; }

        [ForeignKey(nameof(VendorId))]
        [InverseProperty("Services")]
        public virtual Vendor? Vendor { get; set; }
        [InverseProperty(nameof(Booking.Service))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(PackageService.Service))]
        public virtual ICollection<PackageService> PackageServices { get; set; }
        [InverseProperty(nameof(Review.Service))]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
