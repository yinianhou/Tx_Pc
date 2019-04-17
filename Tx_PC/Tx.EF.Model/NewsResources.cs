namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NewsResources
    {
        [Key]
        public int ResourceID { get; set; }

        [StringLength(50)]
        public string RescourceName { get; set; }

        [StringLength(50)]
        public string RescourceType { get; set; }

        public int? RescourceSize { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? UserID { get; set; }

        [StringLength(150)]
        public string ResourcePath { get; set; }
    }
}
