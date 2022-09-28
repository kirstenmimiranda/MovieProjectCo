using MovieProjectCo.Models;
using MovieProjectCo.Data;
using MovieProjectCo.Operations.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace MovieProjectCo.Services;

public class EFMovieService : IMovieService
{
    //data from database
    private readonly DataContext _dataContext;

    public EFMovieService(DataContext dataContext)
    {
        _dataContext = dataContext;
    } 
    /*
    public Movie Save(string movieTitle, DateTime movieYear, string summary)
    {
        Movie m = new Movie() {
            MovieTitle = movieTitle,
            MovieYear = movieYear,
            Summary = summary
        };

        _dataContext.Movies.Add(m);
        _dataContext.SaveChanges();


        return m;
    } */
    public Movie FindById(int id)
    {
        // Perform Eager Loading
        Movie temp = _dataContext.Movies.SingleOrDefault(c => c.Id == id);

        return temp;
    }
    

    public List<Movie> GetAll()
    {
        List<Movie> movies = _dataContext.Movies.ToList();

        return movies;
    }
    
    public Movie Save(Movie m)
    {
        if(m.Id == null || m.Id == 0) {
            _dataContext.Movies.Add(m);
        }else{
            Movie temp = this.FindById(m.Id);
            temp.MovieTitle = m.MovieTitle;
            temp.MovieYear = m.MovieYear;
            temp.Summary = m.Summary;
        }
        
        _dataContext.SaveChanges();
        return m;
    }
    public Movie Save(Dictionary<string, object> hash)
    {
        var builder = new BuildMovieFromHash(hash);
        builder.run();

        return Save(builder.Movie);
    }
}

