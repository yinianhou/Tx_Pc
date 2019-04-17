namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VoteIPList")]
    public partial class VoteIPList
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string IP { get; set; }

        public int? VoteID { get; set; }
    }
}
