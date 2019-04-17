namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PredictionProduct")]
    public partial class PredictionProduct
    {
        public Guid ID { get; set; }

        public Guid? MarketID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsShow { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
