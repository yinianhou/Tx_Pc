namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PredictionMarket")]
    public partial class PredictionMarket
    {
        public Guid ID { get; set; }

        [StringLength(50)]
        public string MarketName { get; set; }

        public int? MarketType { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? ShowFlag { get; set; }
    }
}
