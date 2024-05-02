namespace NetflixClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movieweb.reviews")]
    public partial class review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int reviewID { get; set; }

        public string content { get; set; }

        public float? rating { get; set; }

        [StringLength(45)]
        public string timestamp { get; set; }

        public int? movieID { get; set; }

        public int? serieID { get; set; }

        public int? userID { get; set; }

        public virtual movie movie { get; set; }

        public virtual series series { get; set; }

        public virtual user user { get; set; }
    }
}
