using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Models
{
    public partial class PackageService
    {
        [Key]
        [Column("PackageServiceID")]
        public int PackageServiceId { get; set; }
        [Column("PackageID")]
        public int? PackageId { get; set; }
        [Column("ServiceID")]
        public int? ServiceId { get; set; }

        [ForeignKey(nameof(PackageId))]
        [InverseProperty("PackageServices")]
        public virtual Package? Package { get; set; }
        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("PackageServices")]
        public virtual Service? Service { get; set; }
    }
}
