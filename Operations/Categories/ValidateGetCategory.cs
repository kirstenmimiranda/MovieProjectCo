namespace MovieProjectCo.Operations.Movie;

using MovieProjectCo.Models;
using MovieProjectCo.Operations;

public class ValidateGetCategory : Validator
{
    public Category Category {get; private set;}
    public ValidateGetCategory(Category c)
    {
        Category = c;
    }
    
    public override void run()
    {
        if(Category == null)
        {
            string msg = "Category not found";
            Messages.Add(msg);

            Dictionary<string, object> mHash = new Dictionary<string, object>();
            mHash["category"] = msg;

            MessageHashes.Add(mHash);

        }

    } 

}