namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsArticleText")]
    public partial class NewsArticleText
    {
        [Key]
        public int ArticleTextID { get; set; }

        [StringLength(150)]
        public string SubTitle { get; set; }

        public int? ArticleID { get; set; }

        public int? DisplayOrder { get; set; }

        [Column(TypeName = "text")]
        public string ArticleText { get; set; }
    }
}
