namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SmsPrice2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PriceID { get; set; }

        public int? MarketID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(53)]
        public string LPrice { get; set; }

        [StringLength(53)]
        public string HPrice { get; set; }

        [StringLength(53)]
        public string APrice { get; set; }

        public DateTime? AddDate { get; set; }

        [StringLength(50)]
        public string Water { get; set; }

        [StringLength(50)]
        public string NewPrice { get; set; }

        [StringLength(50)]
        public string Storehouse { get; set; }

        [StringLength(50)]
        public string StrikeBargain { get; set; }

        [StringLength(50)]
        public string Stock { get; set; }

        [StringLength(50)]
        public string SpecialL { get; set; }

        [StringLength(50)]
        public string SpecialH { get; set; }

        public virtual SmsProduct3 SmsProduct3 { get; set; }
    }
}
