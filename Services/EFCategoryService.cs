using MovieProjectCo.Models;
using System.Collections.Generic;
using MovieProjectCo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace MovieProjectCo.Services;

public class EFCategoryService : ICategoryService
{
    private readonly DataContext _dataContext;

    public EFCategoryService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public List<Category> GetAll()
    {
        List<Category> categories = _dataContext.Categories.ToList();

        return categories;
    }
    public Category FindById(int id)
    {
        // Perform Eager Loading
       // Category temp = _dataContext.Categories.Include(c => c.Movies).SingleOrDefault(c => c.Id == id);
       Category temp = _dataContext.Categories.SingleOrDefault(c => c.Id == id);

        return temp;
    }

}

