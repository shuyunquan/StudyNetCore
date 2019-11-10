using System;
using System.Threading.Tasks;
using ViewModels;

namespace IService
{
    public interface IMovieService
    {
        public Task<int> AddMovie(MovieViewModel movieViewModel);
    }
}
