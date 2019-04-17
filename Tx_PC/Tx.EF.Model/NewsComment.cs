namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsComment")]
    public partial class NewsComment
    {
        [Key]
        public int CommentID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string CommentContent { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? ViewFlag { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public int? ArticleID { get; set; }

        [StringLength(50)]
        public string IP { get; set; }
    }
}
