using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MovieProjectCo.Models;
using MovieProjectCo.Services;
using MovieProjectCo.Operations.Movie;
using MovieProjectCo.Operations;


namespace MovieProjectCo.Controllers;

[ApiController]
[Route("categories")]
public class CategoryController : ControllerBase 
{
    private readonly ILogger<CategoryController> _logger;
    //private readonly IConfiguration _configuration;
     private readonly ICategoryService _categoryService;

     private readonly IMovieService _movieService;
    public CategoryController(
        ICategoryService categoryService,
        ILogger<CategoryController> logger)
    {
        _categoryService = categoryService;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index(String ?q)
    {
        _logger.LogInformation("q: " + q);
        List<Category> categories = _categoryService.GetAll();

        _logger.LogInformation("Length of categories: " + categories.Count);
        return Ok(categories);
    }
    [HttpGet("{id}/movies")] //display movies under a category
    public IActionResult Movies(int id)
    {
        Category category = _categoryService.FindById(id);
        //List<Movie> movies = category.Movies.ToList();
        List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
        /*
        foreach(Movie movie in movies)
        {
            Dictionary<string, object> item = new Dictionary<string, object>();
            item["id"] = category.Id;
            item["movieTitle"] = movie.MovieTitle;

            items.Add(item);
        } */

        return Ok(items);
    }



        //Validator validator = new ValidateGetCategory(category); 
        //validator.run();
        /*
        if(validator.HasErrors) {
            return NotFound(validator.Payload);
        } else {
            return Ok(category);
        } */
    

}