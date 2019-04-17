namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Price_Code
    {
        [Required]
        [StringLength(10)]
        public string NorCode { get; set; }

        [StringLength(50)]
        public string NewPrice { get; set; }

        [StringLength(50)]
        public string PreClose { get; set; }

        public DateTime? AddDate { get; set; }

        public int ID { get; set; }
    }
}
