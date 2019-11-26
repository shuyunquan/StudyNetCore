using DomainModels;
using System;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IMovieRepository:IBaseRepository<Movie>
    {
        public Task<int> AddMovie(Movie movieViewModel);

    }
}
