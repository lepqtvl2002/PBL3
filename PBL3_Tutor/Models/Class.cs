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
        [Key]
        public long MaLop { get; set; }

        public long? MaHocSinh { get; set; }

        public int? PhiNhanLop { get; set; }

        [StringLength(200)]
        public string YeuCau { get; set; }

        public bool? TinhTrang { get; set; }

        public virtual Student Student { get; set; }
    }
}
