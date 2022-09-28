namespace MovieProjectCo.Data;
using Microsoft.EntityFrameworkCore;
using MovieProjectCo.Models;

public class DataContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories {get; set;}
    public DbSet<Rating> Ratings {get; set;}
    public DbSet<MovieCategory> MovieCategories {get; set;}
    public DbSet<User> Users {get;set;}


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
         
    } 

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {

    }
}