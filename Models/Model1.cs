using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NetflixClone.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=MovieModel")
        {
        }

        public virtual DbSet<actor> actors { get; set; }
        public virtual DbSet<episode> episodes { get; set; }
        public virtual DbSet<genre> genres { get; set; }
        public virtual DbSet<list_watchlist> list_watchlist { get; set; }
        public virtual DbSet<movie> movies { get; set; }
        public virtual DbSet<review> reviews { get; set; }
        public virtual DbSet<season> seasons { get; set; }
        public virtual DbSet<series> series { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<watchlist> watchlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<actor>()
                .Property(e => e.birthday)
                .HasPrecision(0);

            modelBuilder.Entity<actor>()
                .Property(e => e.popularity)
                .HasPrecision(10, 2);

            modelBuilder.Entity<actor>()
                .HasMany(e => e.movies)
                .WithMany(e => e.actors)
                .Map(m => m.ToTable("actors_movies", "movieweb").MapLeftKey("actorID").MapRightKey("movieID"));

            modelBuilder.Entity<actor>()
                .HasMany(e => e.series)
                .WithMany(e => e.actors)
                .Map(m => m.ToTable("actors_series", "movieweb").MapLeftKey("actorID").MapRightKey("serieID"));

            modelBuilder.Entity<genre>()
                .HasMany(e => e.movies)
                .WithMany(e => e.genres)
                .Map(m => m.ToTable("genres_movies", "movieweb").MapLeftKey("genreID").MapRightKey("movieID"));

            modelBuilder.Entity<genre>()
                .HasMany(e => e.series)
                .WithMany(e => e.genres)
                .Map(m => m.ToTable("genres_series", "movieweb").MapLeftKey("genreID").MapRightKey("serieID"));

            modelBuilder.Entity<movie>()
                .HasMany(e => e.reviews)
                .WithOptional(e => e.movie)
                .WillCascadeOnDelete();

            modelBuilder.Entity<season>()
                .HasMany(e => e.episodes)
                .WithOptional(e => e.season)
                .WillCascadeOnDelete();

            modelBuilder.Entity<series>()
                .HasMany(e => e.reviews)
                .WithOptional(e => e.series)
                .WillCascadeOnDelete();

            modelBuilder.Entity<series>()
                .HasMany(e => e.seasons)
                .WithOptional(e => e.series)
                .WillCascadeOnDelete();

            modelBuilder.Entity<user>()
                .Property(e => e.birthday)
                .HasPrecision(0);

            modelBuilder.Entity<user>()
                .HasMany(e => e.reviews)
                .WithOptional(e => e.user)
                .WillCascadeOnDelete();

            modelBuilder.Entity<watchlist>()
                .HasMany(e => e.list_watchlist)
                .WithRequired(e => e.watchlist)
                .WillCascadeOnDelete(false);
        }
    }
}
