using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Services = new HashSet<Service>();
        }

        [Key]
        [Column("VendorID")]
        public int VendorId { get; set; }
        [StringLength(100)]
        public string VendorName { get; set; } = null!;
        [StringLength(255)]
        public string? ContactInfo { get; set; }
        [StringLength(50)]
        public string? ServiceType { get; set; }
        public string? Description { get; set; }

        [InverseProperty(nameof(Service.Vendor))]
        public virtual ICollection<Service> Services { get; set; }
    }
}
