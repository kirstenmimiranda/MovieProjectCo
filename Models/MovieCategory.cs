namespace MovieProjectCo.Models;

public class MovieCategory
{
    public int Id{get; set;}
    public int MovieId {get;  set;}
    public int CategoryId {get; set;}
    public MovieCategory() 
    {

    }
    public MovieCategory(int id, int movieId, int categoryId)
    {
        this.Id = id;
        this.MovieId = movieId;
        this.CategoryId = categoryId;
    }
    
}