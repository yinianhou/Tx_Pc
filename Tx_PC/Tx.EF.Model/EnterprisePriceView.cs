namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EnterprisePriceView")]
    public partial class EnterprisePriceView
    {
        [StringLength(50)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(150)]
        public string EnterpriseName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Contact { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string Tel { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(150)]
        public string PlaceOfDelivery { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Specifications { get; set; }

        [StringLength(50)]
        public string SteelName { get; set; }

        [StringLength(150)]
        public string Price { get; set; }

        [StringLength(50)]
        public string Change { get; set; }

        public string Remarks { get; set; }

        public DateTime? CreateDate { get; set; }

        [Key]
        [Column(Order = 4)]
        public Guid ID { get; set; }

        public bool? Flag { get; set; }
    }
}
