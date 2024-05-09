namespace NetflixClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movieweb.users")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            reviews = new HashSet<review>();
            watchlists = new HashSet<watchlist>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int userID { get; set; }

        public string userName { get; set; }

        [Required]
        public byte[] password { get; set; }

        [StringLength(45)]
        public string fullName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? birthday { get; set; }

        public int? gender { get; set; }

        [StringLength(45)]
        public string profileImage { get; set; }

        [Required]
        public byte[] email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<review> reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<watchlist> watchlists { get; set; }
    }
}
