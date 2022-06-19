namespace PBL3_Tutor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Classes = new HashSet<Class>();
        }
        [Display(Name ="Mã học sinh")]
        public long studentId { get; set; }

        [StringLength(200)]
        [Display(Name ="Tên học sinh")]
        public string name { get; set; }
        [Display(Name ="Giới tính")]
        public bool? gender { get; set; }

        [StringLength(200)]
        [Display(Name ="Địa chỉ")]
        public string address { get; set; }

        [StringLength(200)]
        [Display(Name ="Môn học")]
        public string subject { get; set; }

        [StringLength(10)]
        [Display(Name ="Số điện thoại")]
        public string phonenumber { get; set; }

        [StringLength(10)]
        [Display(Name ="Lớp/Cấp học")]
        public string grade { get; set; }

        [StringLength(20)]
        [Display(Name ="Học lực")]
        public string academicAbility { get; set; }

        [StringLength(200)]
        [Display(Name ="Trường đang theo học")]
        public string school { get; set; }
        [Display(Name ="Yêu cầu")]
        public string requirement { get; set; }
        [Display(Name ="Thông tin bổ sung")]
        public string note { get; set; }
        [Display(Name ="Thời gian có thể học")]
        public string freeTime { get; set; }
        [Display(Name ="Số tiền chi trả")]
        public int? paymentAmount { get; set; }
        [Display(Name ="Xác nhận tạo lớp")]
        public bool? isConfirm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class> Classes { get; set; }
    }
}
