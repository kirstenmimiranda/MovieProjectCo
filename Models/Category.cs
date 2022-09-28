namespace MovieProjectCo.Models;

public class Category
{
    public int Id{get; set;}
    public string CategoryName {get;  set;}

    //public ICollection<Movie> Movies { get; set; }
    public Category() 
    {

    }
    public Category(int Id, string categoryName)
    {
        this.Id = Id;
        this.CategoryName = categoryName;
    }

    

}