namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OnlineAnswer")]
    public partial class OnlineAnswer
    {
        [Key]
        public int AnswerID { get; set; }

        public int? QuestionsID { get; set; }

        [Column(TypeName = "text")]
        public string MessageText { get; set; }

        public DateTime? PostTime { get; set; }

        [StringLength(200)]
        public string author { get; set; }
    }
}
