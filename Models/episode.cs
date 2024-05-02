namespace NetflixClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movieweb.episodes")]
    public partial class episode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int episodeID { get; set; }

        [StringLength(45)]
        public string episodeName { get; set; }

        public int? episodeNumber { get; set; }

        public string overview { get; set; }

        [StringLength(45)]
        public string posterPath { get; set; }

        [StringLength(45)]
        public string trailer { get; set; }

        public float? voteAverage { get; set; }

        public int? voteCount { get; set; }

        public int? runtime { get; set; }

        public int? seasonID { get; set; }

        public int? serieID { get; set; }

        public virtual season season { get; set; }

        public virtual series series { get; set; }
    }
}
