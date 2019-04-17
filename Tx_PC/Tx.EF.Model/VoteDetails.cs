namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VoteDetails
    {
        public int voteID { get; set; }

        public int voteDetailsID { get; set; }

        [Required]
        [StringLength(200)]
        public string voteItem { get; set; }

        public int? voteNum { get; set; }
    }
}
