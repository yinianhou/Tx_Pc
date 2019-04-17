namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SmsProduct3
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SmsProduct3()
        {
            SmsPrice2 = new HashSet<SmsPrice2>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        public int? MarketId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public int? ProductNum { get; set; }

        public decimal? ProductSum { get; set; }

        [StringLength(50)]
        public string Format { get; set; }

        public byte? ProductKind { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? IsShow { get; set; }

        public byte? XianFlag { get; set; }

        public int? Area { get; set; }

        public byte? IsXH { get; set; }

        public virtual SmsMarket2 SmsMarket2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SmsPrice2> SmsPrice2 { get; set; }
    }
}
