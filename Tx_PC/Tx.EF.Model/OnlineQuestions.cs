namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OnlineQuestions
    {
        [Key]
        public int QuestionsID { get; set; }

        [StringLength(100)]
        public string QuestionsTitle { get; set; }

        public DateTime? PostTime { get; set; }

        public bool? IsShow { get; set; }

        public bool? AnswerFlag { get; set; }
    }
}
