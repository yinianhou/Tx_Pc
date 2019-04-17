namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GetMarketNamePriceTimeFromGroupID")]
    public partial class GetMarketNamePriceTimeFromGroupID
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MarketId { get; set; }

        [StringLength(50)]
        public string MarketName { get; set; }

        public DateTime? AddDate { get; set; }

        public int? GroupID { get; set; }
    }
}
