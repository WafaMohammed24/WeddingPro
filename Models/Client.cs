using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Models
{
    [Index(nameof(Email), Name = "UQ__Clients__A9D1053445A16607", IsUnique = true)]
    public partial class Client
    {
        public Client()
        {
            Bookings = new HashSet<Booking>();
            Reviews = new HashSet<Review>();
            Wallets = new HashSet<Wallet>();
        }

        [Key]
        [Column("ClientID")]
        public int ClientId { get; set; }
        [StringLength(100)]
        public string FullName { get; set; } = null!;
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        [StringLength(255)]
        public string? Address { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(255)]
        public string PasswordHash { get; set; } = null!;

        [InverseProperty(nameof(Booking.Client))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(Review.Client))]
        public virtual ICollection<Review> Reviews { get; set; }
        [InverseProperty(nameof(Wallet.Client))]
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
