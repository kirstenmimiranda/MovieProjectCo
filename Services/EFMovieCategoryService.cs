using MovieProjectCo.Models;
using System.Collections.Generic;
using MovieProjectCo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace MovieProjectCo.Services;

public class EFMovieCategoryService : IMovieCategoryService
{
    private readonly DataContext _dataContext;

    public EFMovieCategoryService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public List<MovieCategory> GetAllCategory()
    {
        List<MovieCategory> movieCategories = _dataContext.MovieCategories.ToList();

        return movieCategories;
    }
    public List<MovieCategoryDisplay> GetAll()
    {
        List<MovieCategoryDisplay> movieCategoryDisplay = new List<MovieCategoryDisplay>();

        return movieCategoryDisplay;
    }
    public List<MovieCategoryDisplay> GetMovieCategories(int id)
    {
        List<MovieCategoryDisplay> movieCategoryDisplay = new List<MovieCategoryDisplay>();

        return movieCategoryDisplay;
    }
    

}

