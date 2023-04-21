using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _560FinalProject
{
    public interface IMovieOperations
    {
        /// <summary>
        /// Retrieves all Movies in the database.
        /// </summary>
        IReadOnlyList<Movie> RetrieveAllMovies();

        /// <summary>
        /// Fetches the Movie with the given ID if it exists.
        /// </summary>
        Movie FetchMovie(int movieid);

        /// <summary>
        /// Gets the Movie(s) with the given parameters if it exists.
        /// 
        /// If you dont have values for some parameters, insert these instead. ||
        /// MovieID -> 0 ||
        /// DirectorID -> 0 ||
        /// Title -> " " ||
        /// Duration -> 0 ||
        /// ReleaseYear -> 0 ||
        /// Gross -> 0 ||
        /// Rating -> 0 ||
        /// </summary>
        IReadOnlyList<Movie> GetMovie(int movieID, int directorID, string title, int duration, int releaseYear, double gross, double rating);

        /// <summary>
        /// Creates a new Movie in the repository.
        /// 
        /// If you dont have values for some parameters, insert these instead. ||
        /// MovieID -> 0 ||
        /// DirectorID -> 0 ||
        /// Title -> " " ||
        /// Duration -> 0 ||
        /// ReleaseYear -> 0 ||
        /// Gross -> 0 ||
        /// Rating -> 0 ||
        /// </summary>
        Movie CreateMovie(int movieID, int directorID, string title, int duration, int releaseYear, double gross, double rating);

        /// <summary>
        /// Removes the Movie with the given ID if it exists.
        /// </summary>
        Movie RemoveMovie(int movieid);
    }
}
