namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NewsArticles_old1
    {
        [Key]
        public int ArticleID { get; set; }

        public int? SortID { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(150)]
        public string Source { get; set; }

        [StringLength(20)]
        public string Author { get; set; }

        [StringLength(20)]
        public string Editor { get; set; }

        public bool? ViewFlag { get; set; }

        [StringLength(50)]
        public string Keyword { get; set; }

        public bool? TopNews { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? Hitrate { get; set; }
    }
}
