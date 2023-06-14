﻿using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(actorMovie => new
            {
                actorMovie.ActorId,
                actorMovie.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(movie =>  movie.Movie).WithMany(actorMovie => 
            actorMovie.Actor_Movies).HasForeignKey(movie => movie.MovieId);


            modelBuilder.Entity<Actor_Movie>().HasOne(movie => movie.Actor).WithMany(actorMovie =>
            actorMovie.Actor_Movies).HasForeignKey(movie => movie.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor_Movie> Actor_Movies { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
    }
}
