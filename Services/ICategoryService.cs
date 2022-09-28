namespace MovieProjectCo.Services;
using MovieProjectCo.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
public interface ICategoryService
{
    //public Movie Save(Movie c);
    //public Movie Save(Dictionary<string, object> hash);
    public List<Category> GetAll();
    public Category FindById(int id);
    //public bool Exists(int id);


}