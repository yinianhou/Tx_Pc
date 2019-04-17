namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsFavorite")]
    public partial class NewsFavorite
    {
        [Key]
        public int FavoriteID { get; set; }

        public int? UserID { get; set; }

        public int? ArticleID { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
