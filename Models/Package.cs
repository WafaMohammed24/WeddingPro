using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Models
{
    public partial class Package
    {
        public Package()
        {
            PackageServices = new HashSet<PackageService>();
        }

        [Key]
        [Column("PackageID")]
        public int PackageId { get; set; }
        [StringLength(100)]
        public string? PackageName { get; set; }
        public string? PackageDescription { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? TotalPrice { get; set; }

        [InverseProperty(nameof(PackageService.Package))]
        public virtual ICollection<PackageService> PackageServices { get; set; }
    }
}
