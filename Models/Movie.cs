namespace MovieProjectCo.Models;

public class Movie
{
    public Int32 Id{get; set;}
    public string MovieTitle {get;  set;}
    public DateTime MovieYear {get; set;}
    public string Summary {get;  set;}
    public Boolean? IsTopTen {get;set;}

    
    public Movie() 
    {

    }
    public Movie(int id, string movieTitle, DateTime movieYear, string summary)
    {
        this.Id = id;
        this.MovieTitle = movieTitle;
        this.MovieYear = movieYear;
        this.Summary = summary;
    }

    public Movie( string movieTitle, DateTime movieYear, string summary)
    {
        this.MovieTitle = movieTitle;
        this.MovieYear = movieYear;
        this.Summary = summary;
    }    
    public Movie(int id, string movieTitle, DateTime movieYear, string summary, Boolean isTopTen)
    {
        this.Id = id;
        this.MovieTitle = movieTitle;
        this.MovieYear = movieYear;
        this.Summary = summary;
        this.IsTopTen = isTopTen;
    }
    

}