namespace NetflixClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movieweb.list_watchlist")]
    public partial class list_watchlist
    {

        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int watchlistID { get; set; }


        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? movieID { get; set; }


        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? serieID { get; set; }
        
        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int listID { get; set; }

        public virtual movie movie { get; set; }

        public virtual series series { get; set; }

        public virtual watchlist watchlist { get; set; }
    }
}
