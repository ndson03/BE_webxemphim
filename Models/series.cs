namespace NetflixClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movieweb.series")]
    public partial class series
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public series()
        {
            episodes = new HashSet<episode>();
            list_watchlist = new HashSet<list_watchlist>();
            reviews = new HashSet<review>();
            seasons = new HashSet<season>();
            actors = new HashSet<actor>();
            genres = new HashSet<genre>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int serieID { get; set; }

        [StringLength(45)]
        public string serieName { get; set; }

        [StringLength(45)]
        public string originalSerieName { get; set; }

        [StringLength(45)]
        public string firstAirDate { get; set; }

        [StringLength(45)]
        public string lastAirDate { get; set; }

        [StringLength(45)]
        public string status { get; set; }

        [StringLength(100)]
        public string tagline { get; set; }

        public string overview { get; set; }

        [StringLength(100)]
        public string homepage { get; set; }

        [StringLength(45)]
        public string popularity { get; set; }

        public float? voteAverage { get; set; }

        public int? voteCount { get; set; }

        [StringLength(45)]
        public string posterPath { get; set; }

        [StringLength(45)]
        public string backdropPath { get; set; }

        [StringLength(45)]
        public string trailer { get; set; }

        public int? numberOfSeasons { get; set; }

        public int? numberOfEpisodes { get; set; }

        [StringLength(45)]
        public string runtime { get; set; }

        [StringLength(45)]
        public string originalLanguage { get; set; }

        [StringLength(45)]
        public string type { get; set; }

        [StringLength(45)]
        public string tags { get; set; }

        [StringLength(45)]
        public string adult { get; set; }

        [StringLength(45)]
        public string genreID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<episode> episodes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<list_watchlist> list_watchlist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<review> reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<season> seasons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<actor> actors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<genre> genres { get; set; }
    }
}
