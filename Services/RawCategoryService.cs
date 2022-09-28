namespace MovieProjectCo.Services;

using System.Text.Json;
using System.Data.SqlClient;
using System.Data;

using MovieProjectCo.Models;
public class RawCategoryService : ICategoryService
{
    //Db table names
    private const string MovieCategoriesTable = "MovieCategories";
    private const string CategoriesTable = "Categories";
    private const string MoviesTable = "Movies";

    public List<Category> GetAll()
    {
        List<Category> categories = new List<Category>();
        //Opens sql database
        SqlConnection connection = new SqlConnection(
            ApplicationManager.Instance.GetConnectionString()
        );
        connection.Open();

        String sql = "SELECT Id, CategoryName FROM" + CategoriesTable;
        SqlCommand command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();

        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read()) {
            categories.Add(
                new Category(
                    (int)reader["Id"],
                    (string)reader["CategoryName"]
                )
            );
        }

        connection.Close();

        return categories;       
                        
    }
    public Category FindById(int id)
    {
        Category category = null;
        MovieCategoryDisplay displays = null;

        SqlConnection connection = new SqlConnection(
            ApplicationManager.Instance.GetConnectionString()
        );

        connection.Open();

        String sql = "SELECT mc.Id, mc.MovieId, mc.CategoryId, m.MovieTitle, m.Movieyear,m.Summary, c.CategoryName FROM " + MoviesTable + " m JOIN " + MovieCategoriesTable + @" mc ON m.id = mc.MovieId JOIN " + CategoriesTable + @" c ON mc.Categoryid = c.id where mc.CategoryId = @id";


        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@id", id);

        command.ExecuteNonQuery();

        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read()) {
            displays = new MovieCategoryDisplay(
                (int)reader["Id"],
                (string)reader["CategoryName"],
                (string)reader["MovieTitle"],
                (DateTime)reader["MovieYear"],
                (string)reader["Summary"]
            );
        }

        return category;
    }

    
    
}
