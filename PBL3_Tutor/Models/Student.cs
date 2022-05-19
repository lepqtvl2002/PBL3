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

        [Key]
        public long MaHS { get; set; }

        [StringLength(200)]
        public string TenHS { get; set; }

        public bool? GioiTinhHS { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string HocLuc { get; set; }

        [StringLength(200)]
        public string TruongDangHoc { get; set; }

        public long? MaMonHoc { get; set; }

        public int? Lop { get; set; }

        [StringLength(200)]
        public string ThongTinBoXung { get; set; }

        public bool? YeuCauTrinhDo { get; set; }

        public bool? YeuCauGioiTinh { get; set; }

        public long? SoTienChiTra { get; set; }
        public bool? XacNhan { get; set; }
        public int? SoBuoiHoc { get; set; }
        public string ThoiGianMongMuon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class> Classes { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
