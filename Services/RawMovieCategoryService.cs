namespace MovieProjectCo.Services;

using System.Text.Json;
using System.Data.SqlClient;
using System.Data;

using MovieProjectCo.Models;
public class RawMovieCategoryService : IMovieCategoryService
{
    //Db table name
    private const string MovieCategoriesTable = "MovieCategories";
    private const string CategoriesTable = "Categories";
    private const string MoviesTable = "Movies";

    public List<MovieCategoryDisplay> GetAll()
    {
        //List<MovieCategory> movieCategories = new List<MovieCategory>();
        List<MovieCategoryDisplay> movieCategoryDisplays = new List<MovieCategoryDisplay>();
        //Opens sql database
        SqlConnection connection = new SqlConnection(
            ApplicationManager.Instance.GetConnectionString()
        );
        connection.Open();

        /*String sqla = @"SELECT mc.Id, mc.MovieId, mc.CategoryId, m.MovieTitle, m.Movieyear,m.Summary, c.CategoryName 
                        FROM" + MoviesTable + @" m 
                        JOIN " + MovieCategoriesTable + @" mc 
                        ON m.id = mc.MovieId
                        JOIN" + CategoriesTable + @" c
                        ON mc.Categoryid = c.id";  */
        String sqla = "SELECT mc.Id, mc.MovieId, mc.CategoryId, m.MovieTitle, m.Movieyear,m.Summary, c.CategoryName FROM " + MoviesTable + " m JOIN " + MovieCategoriesTable + @" mc ON m.id = mc.MovieId JOIN " + CategoriesTable + @" c ON mc.Categoryid = c.id";
        Console.WriteLine(sqla);
        SqlCommand command = new SqlCommand(sqla, connection);
        command.ExecuteNonQuery();
        

        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read()) {
            movieCategoryDisplays.Add(
                new MovieCategoryDisplay(
                    (int)reader["Id"],
                    (string)reader["CategoryName"],
                    (string)reader["MovieTitle"],
                    (DateTime)reader["MovieYear"],
                    (string)reader["Summary"]
                )
            );
        }
        connection.Close();

        return (movieCategoryDisplays); 
             
                        
    }
    public List<MovieCategory> GetAllCategory()
    {
        List<MovieCategory> movieCategories = new List<MovieCategory>();
        //Opens sql database
        SqlConnection connection = new SqlConnection(
            ApplicationManager.Instance.GetConnectionString()
        );
        connection.Open();

        String sql = "SELECT Id, MovieId, CategoryId FROM moviecategories" ;

        SqlCommand command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();

        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read()) {
            movieCategories.Add(
                new MovieCategory(
                    (int)reader["Id"],
                    (int)reader["MovieId"],
                    (int)reader["CategoryId"]
                )
            );
        }
        connection.Close();

        return (movieCategories); 
    }
    public List<MovieCategoryDisplay> GetMovieCategories(int id)
    {
        int Id = id;
        //List<MovieCategory> movieCategories = new List<MovieCategory>();
        List<MovieCategoryDisplay> movieCategoryDisplays = new List<MovieCategoryDisplay>();
        //Opens sql database
        SqlConnection connection = new SqlConnection(
            ApplicationManager.Instance.GetConnectionString()
        );
        connection.Open();

        /*String sqla = @"SELECT mc.Id, mc.MovieId, mc.CategoryId, m.MovieTitle, m.Movieyear,m.Summary, c.CategoryName 
                        FROM" + MoviesTable + @" m 
                        JOIN " + MovieCategoriesTable + @" mc 
                        ON m.id = mc.MovieId
                        JOIN" + CategoriesTable + @" c
                        ON mc.Categoryid = c.id";  */
        String sql = "SELECT mc.Id, mc.MovieId, mc.CategoryId, m.MovieTitle, m.Movieyear,m.Summary, c.CategoryName FROM " + MoviesTable + " m JOIN " + MovieCategoriesTable + @" mc ON m.id = mc.MovieId JOIN " + CategoriesTable + @" c ON mc.Categoryid = c.id where mc.categoryid = " + Id ;
        Console.WriteLine(sql);
        SqlCommand command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
        

        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read()) {
            movieCategoryDisplays.Add(
                new MovieCategoryDisplay(
                    (int)reader["Id"],
                    (string)reader["CategoryName"],
                    (string)reader["MovieTitle"],
                    (DateTime)reader["MovieYear"],
                    (string)reader["Summary"]
                )
            );
        }
        connection.Close();

        return (movieCategoryDisplays); 
             
                        
    }
    
}
