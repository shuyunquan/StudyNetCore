using DomainModels;
using IRepository;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class MovieRepository : IMovieRepository
    {
        public Task<int> AddMovie(Movie movieViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
