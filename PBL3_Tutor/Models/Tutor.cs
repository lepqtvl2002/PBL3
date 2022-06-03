namespace PBL3_Tutor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tutor")]
    public partial class Tutor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tutor()
        {
            Registrations = new HashSet<Registration>();
        }
        [Display(Name ="Mã gia sư")]
        public long tutorId { get; set; }

        [StringLength(200)]
        [Display(Name ="Tên gia sư")]
        public string name { get; set; }
        [Display(Name ="Giới tính")]
        public bool? gender { get; set; }

        [StringLength(200)]
        [Display(Name ="Địa chỉ")]
        public string address { get; set; }

        [StringLength(10)]
        [Display(Name ="Số điện thoại")]
        public string phonenumber { get; set; }

        [StringLength(100)]
        [Display(Name ="Email")]
        public string email { get; set; }

        [StringLength(4)]
        [Display(Name ="Năm sinh")]
        public string yearOfBirth { get; set; }

        [StringLength(200)]
        [Display(Name ="Trình độ học vấn")]
        public string education { get; set; }

        [StringLength(200)]
        [Display(Name ="Trường học")]
        public string university { get; set; }

        [StringLength(200)]
        [Display(Name ="Kinh nghiệm")]
        public string experience { get; set; }

        [StringLength(200)]
        [Display(Name ="Môn dạy")]
        public string subject { get; set; }

        [StringLength(200)]
        [Display(Name ="Lớp/Cấp học giảng dạy")]
        public string grade { get; set; }

        [Display(Name ="Ảnh")]
        public string photo { get; set; }

        [Display(Name ="Ảnh đại diện")]
        public string avata { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
