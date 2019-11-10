using DomainModels;
using System;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IMovieRepository
    {
        public Task<int> AddMovie(Movie movieViewModel);

    }
}
