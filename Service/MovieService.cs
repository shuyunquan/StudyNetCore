using DomainModels;
using IRepository;
using IService;
using System;
using System.Threading.Tasks;
using ViewModels;

namespace Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<int> AddMovie(MovieViewModel movieViewModel)
        {
            Movie movie = new Movie {
                Title = movieViewModel.Info
            };
            return await _movieRepository.AddMovie(movie);
        }
    }
}
