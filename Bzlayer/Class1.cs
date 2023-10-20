using Entity;
using DataLayer;
namespace Bzlayer;
public class MovieBz
{
   public List<Movie> GetMovies()
   {
    DataAccess dataAccess=new DataAccess();
    //Movie movie=DataAccess.GetMovies()

    // you have to make reference for the data in the other layer by passing the dotnet add reference "../Entity"
    return dataAccess.GetMovies();


   }
}
