namespace PBL3_Tutor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registration")]
    public partial class Registration
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Mã gia sư")]
        public long tutorId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Mã lớp")]
        public long classId { get; set; }

        [StringLength(50)]
        [Display(Name ="Trạng thái")]
        public string state { get; set; }

        public virtual Class Class { get; set; }

        public virtual Tutor Tutor { get; set; }
    }
}
