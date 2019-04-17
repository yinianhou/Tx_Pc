namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GetProductPriceFromMarketID
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productid { get; set; }

        public int? marketid { get; set; }

        [StringLength(53)]
        public string HPrice { get; set; }

        [StringLength(53)]
        public string LPrice { get; set; }

        [StringLength(53)]
        public string APrice { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public DateTime? AddDate { get; set; }

        [StringLength(50)]
        public string Expr1 { get; set; }

        [StringLength(50)]
        public string MarketName { get; set; }
    }
}
