using DB;
using DomainModels;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MyContext _context;

        public MovieRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Movie model)
        {
            await _context.Movie.AddAsync(model);
            return  _context.SaveChanges(); 
        }

        public Task<bool> Delete(Movie model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIds(int[] Ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movie>> Query()
        {
            var models = await _context.Movie.ToListAsync();
            return models;
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

        public Task<Movie> QueryByID(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> QueryByID(int Id, bool blnUseCache = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> QueryByIDs(int[] Ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> QueryPage(Expression<Func<Movie, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Movie model)
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
