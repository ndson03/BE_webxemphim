namespace NetflixClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Services.Description;
 
        public class MediaListViewModel
        {
            public List<movie> Movies { get; set; }
            public List<series> Series { get; set; }
        }
}
