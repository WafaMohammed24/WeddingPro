using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wedding.Models
{
    [Index(nameof(Email), Name = "UQ__Admins__A9D105349A68AFEC", IsUnique = true)]
    public partial class Admin
    {
        [Key]
        [Column("AdminID")]
        public int AdminId { get; set; }
        [StringLength(100)]
        public string? FullName { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(255)]
        public string? PasswordHash { get; set; }
        [StringLength(50)]
        public string? Role { get; set; }
    }
}
