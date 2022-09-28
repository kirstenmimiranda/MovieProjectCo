namespace MovieProjectCo.Models;

public class MovieCategoryDisplay
{
    public int Id{get; set;}
    public string MovieTitle {get; set;}
    public DateTime MovieYear {get;set; }
    public string Summary {get;set;}
    public string CategoryName {get;set;}

    public MovieCategoryDisplay() 
    {

    }
    public MovieCategoryDisplay(int id, string categoryName ,string movieTitle, DateTime movieYear, string summary)
    {
        this.Id = id;
        this.MovieTitle = movieTitle;
        this.MovieYear =  movieYear;
        this.Summary = summary ;
        this.CategoryName = categoryName;
    }
    
}