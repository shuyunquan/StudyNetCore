using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IBaseRepository<T> where T:class
    { 
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> QueryByID(int Id);

        Task<T> QueryByID(int Id, bool blnUseCache = false);
        Task<List<T>> QueryByIDs(int[] Ids);
        Task<int> Add(T model);
        Task<bool> DeleteById(int Id);
        Task<bool> DeleteByIds(int[] Ids);
        Task<bool> Update(T model);
        Task<bool> Update(T entity, string strWhere);
        Task<bool> Update(T entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "");

        Task<List<T>> Query();
        Task<List<T>> Query(string strWhere);
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression);
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, string strOrderByFileds);
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true);
        Task<List<T>> Query(string strWhere, string strOrderByFileds);
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intTop, string strOrderByFileds);
        Task<List<T>> Query(string strWhere, int intTop, string strOrderByFileds);
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds);
        Task<List<T>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds);
        Task<List<T>> QueryPage(Expression<Func<T, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null);
    
    }
}
