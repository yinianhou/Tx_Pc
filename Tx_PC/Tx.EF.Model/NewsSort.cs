namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsSort")]
    public partial class NewsSort
    {
        [Key]
        public int SortID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public bool? ViewFlag { get; set; }

        [StringLength(250)]
        public string Descripttion { get; set; }

        [StringLength(250)]
        public string HyperLink { get; set; }

        public int ParentID { get; set; }

        public int? ResourceID { get; set; }

        public int? StyleID { get; set; }

        public DateTime CreateDate { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? IsHeadMune { get; set; }
    }
}
