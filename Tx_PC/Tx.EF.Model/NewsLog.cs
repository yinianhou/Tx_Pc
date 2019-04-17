namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsLog")]
    public partial class NewsLog
    {
        [Key]
        public int LogID { get; set; }

        [StringLength(350)]
        public string NewsTitle { get; set; }

        [StringLength(50)]
        public string IP { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateMid { get; set; }

        [StringLength(50)]
        public string DeleteMid { get; set; }
    }
}
