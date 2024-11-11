using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
        }

        [Key]
        [Column("BookingID")]
        public int BookingId { get; set; }
        [Column("ClientID")]
        public int? ClientId { get; set; }
        [Column("ServiceID")]
        public int? ServiceId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BookingDate { get; set; }
        [StringLength(50)]
        public string? Status { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? TotalAmount { get; set; }
        [StringLength(50)]
        public string? PaymentStatus { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Bookings")]
        public virtual Client? Client { get; set; }
        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("Bookings")]
        public virtual Service? Service { get; set; }
        [InverseProperty(nameof(Payment.Booking))]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
