namespace MovieProjectCo.Operations.Movies;

using MovieProjectCo.Models;

public class BuildMovieFromHash
{
    public Dictionary<string, object> Hash { get; set; }
    public Movie Movie  {get; set; }
    public BuildMovieFromHash(Dictionary<string, object> hash)
    {
        Hash = hash;
        Movie = new Movie();
    }

    public void run()
    {
        if(Hash.GetValueOrDefault("id") != null) {
            Movie.Id = Int32.Parse(Hash["id"].ToString());
        }
        if(Hash.GetValueOrDefault("movieTitle") != null) {
            Movie.MovieTitle = Hash["movieTitle"].ToString();
        }

        if(Hash.GetValueOrDefault("movieYear") != null) {
            Movie.MovieYear = DateTime.Parse(Hash["movieYear"].ToString());
        }

        if(Hash.GetValueOrDefault("summary") != null) {
            Movie.Summary = Hash["summary"].ToString();
        }
    }
}