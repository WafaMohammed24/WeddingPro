using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Models
{
    public partial class Notification
    {
        [Key]
        [Column("NotificationID")]
        public int NotificationId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        public string? Message { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NotificationDate { get; set; }
        [StringLength(50)]
        public string? Status { get; set; }
    }
}
