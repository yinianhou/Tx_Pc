namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SmsMarket")]
    public partial class SmsMarket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MarketId { get; set; }

        [StringLength(50)]
        public string MarketName { get; set; }

        public byte? MarketType { get; set; }

        public byte? FlatType { get; set; }

        public int? DisplayOrder { get; set; }

        public int? GroupID { get; set; }

        public bool? ShowFlag { get; set; }
    }
}
