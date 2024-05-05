namespace NetflixClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movieweb.actors")]
    public partial class actor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public actor()
        {
            movies = new HashSet<movie>();
            series = new HashSet<series>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int actorID { get; set; }

        [StringLength(45)]
        public string actorName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? birthday { get; set; }

        [StringLength(10)]
        public string gender { get; set; }

        [StringLength(45)]
        public string placeOfBirth { get; set; }

        public string biography { get; set; }

        [StringLength(45)]
        public string knownForDepartment { get; set; }

        public decimal? popularity { get; set; }

        [StringLength(45)]
        public string profilePath { get; set; }

        [StringLength(10)]
        public string imdbID { get; set; }

        [StringLength(45)]
        public string originalName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movie> movies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<series> series { get; set; }
    }
}
