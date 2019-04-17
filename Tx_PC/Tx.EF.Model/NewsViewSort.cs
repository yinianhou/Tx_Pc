namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsViewSort")]
    public partial class NewsViewSort
    {
        [Key]
        public int ViewID { get; set; }

        public int? RoleID { get; set; }

        public int? SortID { get; set; }
    }
}
