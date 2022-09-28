namespace MovieProjectCo.Filters;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieProjectCo.Services;

public class MovieFilter : Attribute, IActionFilter
{
    private readonly IMovieService _movieService;

    public MovieFilter(IMovieService movieService) 
    {
        _movieService = movieService;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("MovieFilter: Invoking OnActionExecuted()...");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Int32 movieCount = _movieService.GetAll().Count;
        Console.WriteLine("Number of movies in database: " + movieCount);
        Console.WriteLine("MovieFilter: Invoking OnActionExecuting()...");
    }
}