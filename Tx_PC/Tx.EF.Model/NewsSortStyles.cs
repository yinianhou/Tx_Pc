namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NewsSortStyles
    {
        [Key]
        public int StyleID { get; set; }

        [StringLength(50)]
        public string StyleName { get; set; }

        [StringLength(150)]
        public string StyleSkin { get; set; }
    }
}
