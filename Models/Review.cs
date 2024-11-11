using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Models
{
    public partial class Review
    {
        [Key]
        [Column("ReviewID")]
        public int ReviewId { get; set; }
        [Column("ClientID")]
        public int? ClientId { get; set; }
        [Column("ServiceID")]
        public int? ServiceId { get; set; }
        public int? Rating { get; set; }
        public string? ReviewText { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ReviewDate { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Reviews")]
        public virtual Client? Client { get; set; }
        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("Reviews")]
        public virtual Service? Service { get; set; }
    }
}
