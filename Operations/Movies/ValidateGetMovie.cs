namespace MovieProjectCo.Operations.Movies;

using MovieProjectCo.Models;
using MovieProjectCo.Operations;

public class ValidateGetMovie : Validator
{
    public Movie Movie {get; private set;}
    public ValidateGetMovie(Movie m)
    {
        Movie = m;
    }
    
    public override void run()
    {
        if(Movie == null)
        {
            string msg = "Movie not found";
            Messages.Add(msg);

            Dictionary<string, object> mHash = new Dictionary<string, object>();
            mHash["movie"] = msg;

            MessageHashes.Add(mHash);

        }

    } 

}