namespace PBL3_Tutor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        public long adminId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Tên Admin")]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Email")]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="Số điện thoại")]
        public string phonenumber { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        public virtual Account Account { get; set; }
    }
}
