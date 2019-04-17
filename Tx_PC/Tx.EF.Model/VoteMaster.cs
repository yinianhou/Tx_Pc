namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VoteMaster")]
    public partial class VoteMaster
    {
        [Key]
        public int voteID { get; set; }

        [Required]
        [StringLength(100)]
        public string voteTitle { get; set; }

        public int? voteSum { get; set; }

        public bool? IsClose { get; set; }
    }
}
