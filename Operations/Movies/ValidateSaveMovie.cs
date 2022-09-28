namespace MovieProjectCo.Operations.Movies;

using MovieProjectCo.Models;
using MovieProjectCo.Services;
using System.Text.Json;

public class ValidateSaveMovie : Validator
{
    public Int32 Id { get; set; }
    public string MovieTitle {get;  set;}
    public DateTime MovieYear {get; set;}
    public string Summary {get;  set;}

    private readonly IMovieService _movieService;

    public void InitializeParameters(Dictionary<string, object> hash)
    {
        if(hash.GetValueOrDefault("id") != null) {
            this.Id = Int32.Parse(hash["id"].ToString());
        }

        if(hash.GetValueOrDefault("movieTitle") != null) {
            this.MovieTitle = hash["movieTitle"].ToString();
        }

        if(hash.GetValueOrDefault("movieYear") != null) {
            this.MovieYear = DateTime.Parse(hash["movieYear"].ToString());
        }

        if(hash.GetValueOrDefault("summary") != null) {
            this.Summary  = hash["summary"].ToString();
        }
    }

    public ValidateSaveMovie(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public ValidateSaveMovie(Dictionary<string, object> hash, IMovieService movieService)
    {
        _movieService = movieService;

        if(hash.GetValueOrDefault("id") != null) {
            this.Id = JsonSerializer.Deserialize<int>((JsonElement)hash["id"]);
        }
        if(hash.GetValueOrDefault("movieTitle") != null) {
            this.MovieTitle = hash["movieTitle"].ToString();
        }

        if(hash.GetValueOrDefault("movieYear") != null) {
            this.MovieYear = DateTime.Parse(hash["movieYear"].ToString());
        }

        if(hash.GetValueOrDefault("summary") != null) {
            this.Summary  = hash["summary"].ToString();
        }
    }

    public override void run()
    {
        Console.WriteLine("movie ID: " + this.Id);
        Console.WriteLine("MovieTitle: " + this.MovieTitle);
        Console.WriteLine("MovieYear: " + this.MovieYear);
        Console.WriteLine("Summary: " + this.Summary);

        if(this.MovieTitle == null || this.MovieTitle.Equals("")) {
            String msg = "Movie Title is required";
            this.AddError(msg, "movieTitle");
        }

        if(this.MovieYear == null || this.MovieYear.Equals("")) {
            String msg = "Movie Year is required";
            this.AddError(msg, "movieYear");
        }

        if(this.Summary == null || this.Summary.Equals("")) {
            String msg = "Summary is required";
            this.AddError(msg, "summary");
        } 
        /*
        else if(this.Id == null || this.Id == 0) {
            if(_movieService.Exists(this.RefNumber)) {
                String msg = "Ref number is already taken";
                this.AddError(msg, "refNumber");
            }
        }  else {
            // Validating refNumber for update
            /*
            if(!_movieService.Exists(this.Id)) {
                String msg = "Customer not found";
                this.AddError(msg, "id");
            } else {
                if(_movieService.Exists(this.RefNumber, this.Id)) {
                    String msg = "Ref number is already taken";
                    this.AddError(msg, "refNumber");
                }
            } 
        }*/
    }
}