namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XHMarketGroup")]
    public partial class XHMarketGroup
    {
        [Key]
        public int GroupID { get; set; }

        [StringLength(50)]
        public string GroupName { get; set; }

        public DateTime? AddDate { get; set; }

        public int? Flag { get; set; }
    }
}
