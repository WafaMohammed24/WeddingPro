using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Models
{
    public partial class Payment
    {
        [Key]
        [Column("PaymentID")]
        public int PaymentId { get; set; }
        [Column("BookingID")]
        public int? BookingId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? PaymentDate { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Amount { get; set; }
        [StringLength(50)]
        public string? PaymentMethod { get; set; }
        [StringLength(50)]
        public string? PaymentStatus { get; set; }

        [ForeignKey(nameof(BookingId))]
        [InverseProperty("Payments")]
        public virtual Booking? Booking { get; set; }
    }
}
