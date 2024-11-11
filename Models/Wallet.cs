using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Models
{
    public partial class Wallet
    {
        [Key]
        [Column("WalletID")]
        public int WalletId { get; set; }
        [Column("ClientID")]
        public int? ClientId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Balance { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastUpdated { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Wallets")]
        public virtual Client? Client { get; set; }
    }
}
