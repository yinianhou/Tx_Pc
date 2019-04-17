namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enterprise")]
    public partial class Enterprise
    {
        public Guid EnterpriseID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(150)]
        public string EnterpriseName { get; set; }

        [Required]
        [StringLength(50)]
        public string Contact { get; set; }

        [Required]
        [StringLength(20)]
        public string Tel { get; set; }

        [Required]
        [StringLength(150)]
        public string PlaceOfDelivery { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(250)]
        public string TempBak0 { get; set; }

        [StringLength(2500)]
        public string TempBak1 { get; set; }

        public DateTime? TempBak2 { get; set; }

        public DateTime? TempBak3 { get; set; }

        public bool? TempBak4 { get; set; }

        public bool? TempBak5 { get; set; }

        public int? TempBak6 { get; set; }

        public int? TempBak7 { get; set; }

        [Column(TypeName = "money")]
        public decimal? TempBak8 { get; set; }

        [Column(TypeName = "money")]
        public decimal? TempBak9 { get; set; }
    }
}
