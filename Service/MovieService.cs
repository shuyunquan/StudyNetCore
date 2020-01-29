using DomainModels;
using IRepository;
using IService;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public Task<int> Add(Movie model)
        {
            return _movieRepository.Add(model);
        }

        public Task<bool> DeleteById(int id)
        {
            return _movieRepository.DeleteById(id);
        }

        public async Task<List<Movie>> Query()
        {
            return await _movieRepository.Query();
        }

        public async Task<bool> Update(Movie model)
        {
            return await _movieRepository.Update(model);
        }

        public async Task<Movie> QueryByID(int Id)
        {
            return await _movieRepository.QueryByID(Id);
        }






        public Task<bool> Delete(Movie model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIds(int[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> Query(string strWhere)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> Query(Expression<Func<Movie, bool>> whereExpression)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> Query(Expression<Func<Movie, bool>> whereExpression, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> Query(Expression<Func<Movie, bool>> whereExpression, Expression<Func<Movie, object>> orderByExpression, bool isAsc = true)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> Query(string strWhere, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> Query(Expression<Func<Movie, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> Query(Expression<Func<Movie, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

   
        public Task<Movie> QueryByID(int Id, bool blnUseCache = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> QueryByIDs(object[] Ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> QueryPage(Expression<Func<Movie, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Movie entity, string strWhere)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Movie entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            throw new NotImplementedException();
        }
    }
}
