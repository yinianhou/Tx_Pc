namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PredictionPrice")]
    public partial class PredictionPrice
    {
        public long ID { get; set; }

        public Guid? ProductID { get; set; }

        [Column(TypeName = "money")]
        public decimal? LPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? HPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? APrice { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string MID { get; set; }

        [StringLength(150)]
        public string Change { get; set; }
    }
}
