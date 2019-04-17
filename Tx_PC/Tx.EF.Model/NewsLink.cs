namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsLink")]
    public partial class NewsLink
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string LinkName { get; set; }

        [StringLength(500)]
        public string LinkAddress { get; set; }

        [StringLength(500)]
        public string LinkIcon { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
