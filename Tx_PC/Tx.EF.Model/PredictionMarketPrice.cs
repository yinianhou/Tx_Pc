namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PredictionMarketPrice")]
    public partial class PredictionMarketPrice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(50)]
        public string MarketName { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal? HPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? LPrice { get; set; }

        [StringLength(150)]
        public string Change { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string MID { get; set; }
    }
}
