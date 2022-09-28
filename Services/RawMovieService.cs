namespace MovieProjectCo.Services;

using System.Text.Json;
using System.Data.SqlClient;
using System.Data;

using MovieProjectCo.Models;
public class RawMovieService : IMovieService
{
    //Db table name
    private const string MoviesTable = "Movies";

    public List<Movie> GetAll()
    {
        List<Movie> movies = new List<Movie>();
        //Opens sql database
        SqlConnection connection = new SqlConnection(
            ApplicationManager.Instance.GetConnectionString()
        );
        connection.Open();

        String sql = "SELECT Id, MovieTitle, MovieYear, Summary, IsTopTen from Movies"  ;
        SqlCommand command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();

        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read()) {
            movies.Add(
                new Movie(
                    (int)reader["Id"],
                    (string)reader["MovieTitle"],
                    (DateTime)reader["MovieYear"],
                    (string)reader["Summary"]
                    //(Boolean)reader["IsTopTen"]
                )
            );
        }

        connection.Close();

        return movies;       
                        
    }
    //------------------ next method-------------------------------
    public Movie FindById(int id)
    {
        Movie movie = null;

        SqlConnection connection = new SqlConnection(
            ApplicationManager.Instance.GetConnectionString()
        );

        connection.Open();

        String sql = "SELECT Id, MovieTitle, MovieYear,Summary, IsTopTen from " + MoviesTable + " WHERE Id = @id";
        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@id", id);

        command.ExecuteNonQuery();

        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read()) {
            movie = new Movie(
                    (int)reader["Id"],
                    (string)reader["MovieTitle"],
                    (DateTime)reader["MovieYear"],
                    (string)reader["Summary"],
                    (Boolean)reader["IsTopTen"]
            );
        }

        return movie;
    }

    public Movie Save(Movie c)
    {
         SqlConnection connection = new SqlConnection(
            ApplicationManager.Instance.GetConnectionString()
        );

        connection.Open();

        String sql = @"INSERT INTO Movies (
                            MovieTitle,
                            MovieYear,
                            Summary,
                            IsTopTen)
                        VALUES
                        (@MovieTitle, @MovieYear, @Summary, 0)";

        if(c.Id != null) {
            // UPDATE
            sql = "UPDATE Movies SET MovieTitle=@MovieTitle, MovieYear=@MovieYear, Summary=@Summary WHERE Id=@Id";
        } 

        SqlCommand command = new SqlCommand(sql, connection);

        if(c.Id != null) {
            command.Parameters.AddWithValue("@Id", c.Id);
        }

        command.Parameters.AddWithValue("@MovieTitle", c.MovieTitle);
        command.Parameters.AddWithValue("@MovieYear", c.MovieYear);
        command.Parameters.AddWithValue("@Summary", c.Summary);
        //command.Parameters.AddWithValue("@IsTopTen", c.IsTopTen);

        command.ExecuteNonQuery();

        connection.Close();

        return c;
    }

    public Movie Save(Dictionary<string, object> hash)
    {
        Int32 id            = Int32.Parse(hash["id"].ToString());
        String movieTitle   = hash["movieTitle"].ToString();
        DateTime movieYear  = DateTime.Parse(hash["movieYear"].ToString());
        String summary      = hash["summary"].ToString();
        //Boolean isTopTen    = false;

        Movie temp = new Movie( id,movieTitle, movieYear, summary);

        return this.Save(temp);
    }
    
}
