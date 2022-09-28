namespace MovieProjectCo.Services;

using MovieProjectCo.Models;
using Microsoft.Data.SqlClient;
public interface IMovieCategoryService
{
    //public Movie Save(Movie c);
    //public Movie Save(Dictionary<string, object> hash);
    public List<MovieCategoryDisplay> GetAll();
    public List<MovieCategory> GetAllCategory();

    public List<MovieCategoryDisplay> GetMovieCategories(int id);
   // public MovieCategory FindById(int id);
    //public bool Exists(int id);

}