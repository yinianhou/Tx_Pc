namespace Tx.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SmsMarket2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SmsMarket2()
        {
            SmsProduct3 = new HashSet<SmsProduct3>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MarketId { get; set; }

        [StringLength(50)]
        public string MarketName { get; set; }

        public byte? MarketType { get; set; }

        public byte? FlatType { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? ShowFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SmsProduct3> SmsProduct3 { get; set; }
    }
}
