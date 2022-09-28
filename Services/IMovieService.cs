namespace MovieProjectCo.Services;

using MovieProjectCo.Models;
public interface IMovieService
{
    public Movie Save(Movie c);
    public Movie Save(Dictionary<string, object> hash);
    public List<Movie> GetAll();
    public Movie FindById(int id);
    //public bool Exists(int id);
    //public User Register(string movieTitle, DateTime movieYear, string summary);

}