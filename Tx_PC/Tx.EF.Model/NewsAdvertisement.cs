namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsAdvertisement")]
    public partial class NewsAdvertisement
    {
        [Key]
        public int AdvertisementID { get; set; }

        [StringLength(100)]
        public string AdvertisementTitle { get; set; }

        public int? DisplayOrder { get; set; }

        public int? ResourceID { get; set; }

        [StringLength(200)]
        public string HyperLink { get; set; }

        [StringLength(50)]
        public string ToolTip { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
