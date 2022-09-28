namespace MovieProjectCo.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using MovieProjectCo.Models;
using MovieProjectCo.Services;
using MovieProjectCo.Operations.Movie;
using MovieProjectCo.Operations;


[ApiController]
[Route("moviecategories")]
public class MovieCategoryController : ControllerBase 
{
    private readonly ILogger<MovieCategoryController> _logger;
    //private readonly IConfiguration _configuration;
    private readonly IMovieCategoryService _movieCategoryService;
    //private readonly ValidateSaveMovie _validateSaveMovie;
     public MovieCategoryController(
        IMovieCategoryService movieCategoryService,
        ILogger<MovieCategoryController> logger)
        //ValidateSaveMovie validateSaveMovie)
    {
        _movieCategoryService = movieCategoryService;
        _logger = logger;
        //_validateSaveMovie = validateSaveMovie;
    }
    [HttpGet]
    public IActionResult Index(String ?q)
    {
        _logger.LogInformation("q: " + q);
        List<MovieCategoryDisplay> movieCategoryDisplays = _movieCategoryService.GetAll();
        //List<MovieCategory> movieCategoryDisplays = _movieCategoryService.GetAll();

        _logger.LogInformation("Length of moviescategories: " + movieCategoryDisplays.Count);
        _logger.LogInformation("Displays movie categories pls");
        return Ok(movieCategoryDisplays);
    }
    [HttpGet("categories")]
    public IActionResult ShowCategories(String ?q)
    {
        _logger.LogInformation("q: " + q);
        List<MovieCategory> movieCategoryies = _movieCategoryService.GetAllCategory();

        _logger.LogInformation("Length of categories: " + movieCategoryies.Count);
        _logger.LogInformation("Displays categories only pls");
        return Ok(movieCategoryies);
    }
    
    [HttpGet("{id}")]
    public IActionResult DisplayPerCategory(int id)
    {
        int categoryId = id;
        List<MovieCategoryDisplay> movieCategoryDisplays = _movieCategoryService.GetMovieCategories(categoryId);

        _logger.LogInformation("Length of movie per category: " + movieCategoryDisplays.Count);
        return Ok(movieCategoryDisplays);
    } 

}