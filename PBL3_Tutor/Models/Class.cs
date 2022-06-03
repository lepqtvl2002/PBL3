namespace PBL3_Tutor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Class")]
    public partial class Class
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            Registrations = new HashSet<Registration>();
        }
        [Display(Name ="Mã lớp học")]
        public long classId { get; set; }
        [Display(Name ="Mã học sinh")]
        public long studentId { get; set; }
        [Display(Name ="Phí nhận lớp")]
        public int? fee { get; set; }
        [Display(Name ="Trạng thái")]
        public bool? state { get; set; }

        public virtual Student Student { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
