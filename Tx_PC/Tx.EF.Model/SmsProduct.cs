namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SmsProduct")]
    public partial class SmsProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        public int? MarketId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public int? ProductNum { get; set; }

        public decimal? ProductSum { get; set; }

        [StringLength(50)]
        public string Format { get; set; }

        public byte? ProductKind { get; set; }

        public int? DisplayOrder { get; set; }

        public int? AttributeID { get; set; }

        public bool? IsShow { get; set; }

        public byte? XianFlag { get; set; }

        public int? Area { get; set; }

        public byte? IsXH { get; set; }
    }
}
