namespace PBL3_Tutor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        public long staffId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Tên nhân viên")]
        public string name { get; set; }
        [Display(Name ="Giới tính")]
        public bool gender { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Email")]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="Số điện thoại")]
        public string phonenumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Địa chỉ")]
        public string address { get; set; }

        public virtual Account Account { get; set; }
    }
}
