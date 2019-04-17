namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NewsSort_Bak1
    {
        [Key]
        [Column(Order = 0)]
        public int SortID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Title { get; set; }

        public bool? ViewFlag { get; set; }

        [StringLength(250)]
        public string Descripttion { get; set; }

        [StringLength(250)]
        public string HyperLink { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ParentID { get; set; }

        public int? ResourceID { get; set; }

        public int? StyleID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime CreateDate { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? IsHeadMune { get; set; }
    }
}
