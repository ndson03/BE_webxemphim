namespace NetflixClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movieweb.watchlists")]
    public partial class watchlist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public watchlist()
        {
            list_watchlist = new HashSet<list_watchlist>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int watchlistID { get; set; }

        [StringLength(45)]
        public string watchlistName { get; set; }

        public int? userID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<list_watchlist> list_watchlist { get; set; }

        public virtual user user { get; set; }
    }
}
