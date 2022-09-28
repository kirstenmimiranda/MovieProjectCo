namespace MovieProjectCo.Models;

public class Rating
{
    public int Id{get; set;}
    public int MovieId {get;  set;}
    public int UserId {get;  set;}
    public int RatingNum {get;set;}
    public string Review {get;set;}
    public Rating() 
    {

    }
    public Rating(int id, int movieId, int UserId, int ratingNum, string review)
    {
        this.Id = Id;
        this.MovieId = movieId;
        this.UserId = UserId;
        this.RatingNum = ratingNum;
        this.Review = review;
    }
}