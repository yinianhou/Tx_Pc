namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsSortType")]
    public partial class NewsSortType
    {
        [Key]
        public int TypeID { get; set; }

        [StringLength(50)]
        public string TypeName { get; set; }
    }
}
