namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsVisitHistory")]
    public partial class NewsVisitHistory
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string VisitIP { get; set; }

        public DateTime? VisitDate { get; set; }

        [StringLength(200)]
        public string VisitPage { get; set; }
    }
}
