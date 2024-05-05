namespace NetflixClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movieweb.movie")]
    public partial class movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public movie()
        {
            list_watchlist = new HashSet<list_watchlist>();
            reviews = new HashSet<review>();
            actors = new HashSet<actor>();
            genres = new HashSet<genre>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int movieID { get; set; }

        [StringLength(45)]
        public string movieName { get; set; }

        [StringLength(45)]
        public string originalMovieName { get; set; }

        [StringLength(45)]
        public string releaseDate { get; set; }

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

        public int? budget { get; set; }

        public int? revenue { get; set; }

        [StringLength(45)]
        public string posterPath { get; set; }

        [StringLength(45)]
        public string backdropPath { get; set; }

        [StringLength(45)]
        public string trailer { get; set; }

        public int? runtime { get; set; }

        [StringLength(45)]
        public string originalLanguage { get; set; }

        [StringLength(45)]
        public string tags { get; set; }

        [StringLength(45)]
        public string adult { get; set; }

        public int? genreID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<list_watchlist> list_watchlist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<review> reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<actor> actors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<genre> genres { get; set; }
    }
}
