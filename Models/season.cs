namespace NetflixClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movieweb.seasons")]
    public partial class season
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public season()
        {
            episodes = new HashSet<episode>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int seasonID { get; set; }

        [StringLength(100)]
        public string seasonName { get; set; }

        public int? seasonNumber { get; set; }

        public string overview { get; set; }

        [StringLength(45)]
        public string posterPath { get; set; }

        [StringLength(45)]
        public string trailer { get; set; }

        public float? voteAverage { get; set; }

        public int? voteCount { get; set; }

        public int? serieID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<episode> episodes { get; set; }

        public virtual series series { get; set; }
    }
}
