namespace MovieProjectCo.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using MovieProjectCo.Models;
using MovieProjectCo.Services;
using MovieProjectCo.Operations;
using MovieProjectCo.Operations.Movies;



[ApiController]
[Route("movies")]
public class MovieController : ControllerBase 
{
    private readonly ILogger<MovieController> _logger;
    //private readonly IConfiguration _configuration;
    private readonly IMovieService _movieService;
    private readonly ValidateSaveMovie _validateSaveMovie;

    public MovieController(
        IMovieService movieService,
        ILogger<MovieController> logger,
        ValidateSaveMovie validateSaveMovie)
    {
        _movieService = movieService;
        _logger = logger;
        _validateSaveMovie = validateSaveMovie;
    }
    [HttpGet]
    public IActionResult Index(String ?q)
    {
        //_logger.LogInformation("q: " + q);
        List<Movie> movies = _movieService.GetAll();
        Console.WriteLine("Returning all customers...");
        _logger.LogInformation("Length of movies: " + movies.Count);
        return Ok(movies);
    }

    [HttpGet("{id}")] //display specific movies
    public IActionResult Show(int id)
    {
        Movie movie = _movieService.FindById(id);

        Validator validator = new ValidateGetMovie(movie); 
        validator.run();

        if(validator.HasErrors) {
            return NotFound(validator.Payload);
        } else {
            return Ok(movie);
        }
    }
    
    [HttpGet("{id}/ratings")]
    public IActionResult ViewRatings(String ?q)
    {
        //_logger.LogInformation("q: " + q);
        List<Movie> movies = _movieService.GetAll();
        Console.WriteLine("Returning all customers...");
        _logger.LogInformation("Length of movies: " + movies.Count);
        return Ok(movies);
    }
    [HttpPost]
    public IActionResult Create([FromBody]object payload)
    {
        try
        {
        Dictionary<string,object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());
        _validateSaveMovie.InitializeParameters(hash);
        _validateSaveMovie.run();

        if(_validateSaveMovie.HasErrors)
        {
            return UnprocessableEntity(_validateSaveMovie.Payload);
        }else {
            Movie temp = _movieService.Save(hash);
            return Ok(temp);
        }
        }
        catch(Exception e)
        {
            Dictionary<string, string> msg = new Dictionary<string, string>();
            msg["message"] = "Something went wrong";
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);

            return StatusCode(StatusCodes.Status500InternalServerError, msg);
        }
    }

    //-----------------------------PUT ---------------------------------------------
    [HttpPut("{id}")]
    public IActionResult Update([FromBody]object payload, int id)
    {
        try {
            Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

            hash["id"] = id;
            _validateSaveMovie.InitializeParameters(hash);
            _validateSaveMovie.run();

            if(_validateSaveMovie.HasErrors) {
                return UnprocessableEntity(_validateSaveMovie.Payload);
            } else {
                return Ok(_movieService.Save(hash));

            }
        } catch(Exception e) {
            Dictionary<string, string> msg = new Dictionary<string, string>();
            msg["message"] = "Something went wrong";
            throw(e);
            _logger.LogInformation(e.Message);
            _logger.LogInformation(e.StackTrace);
            return StatusCode(StatusCodes.Status500InternalServerError, msg);

        }
    }
    //-------------------DELETE-------------------------------------------
    [HttpDelete("{id}")]
    public IActionResult Delete([FromBody]object payload, int id)
    {

        Console.WriteLine("Deleting Movie....");
        try {
            Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

            hash["id"] = id;
            _validateSaveMovie.InitializeParameters(hash);
            _validateSaveMovie.run();

            if(_validateSaveMovie.HasErrors) {
                return UnprocessableEntity(_validateSaveMovie.Payload);
            } else {
                return Ok(_movieService.Save(hash));
            }
        } catch(Exception e) {
            Dictionary<string, string> msg = new Dictionary<string, string>();
            msg["message"] = "Something went wrong";

            _logger.LogInformation(e.Message);
            _logger.LogInformation(e.StackTrace);
            return StatusCode(StatusCodes.Status500InternalServerError, msg);

        }
    }
    /*
    [HttpGet]
    public JsonResult Get()
    {
        string query= @"Select * from dbo.movies";
        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("MSSqlConnection");
        SqlDataReader myReader;
        using(SqlConnection myCon=new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader); ;

                myReader.Close();
                myCon.Close();
            }
        }
        return new JsonResult(table);
    }
    */

}