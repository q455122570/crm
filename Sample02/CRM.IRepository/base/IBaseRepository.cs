using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.IRepository
{
    
    using System.Linq.Expressions;

    public interface  IBaseRepository<TEntity> where TEntity:class 
    {
        #region 2.0查询
        /// <summary>
        /// 根据lambda表达式查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where);
        
        /// <summary>
        /// 连表操作
        /// </summary>
        /// <param name="where"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
          List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> where, string[] tableNames);
      

        /// <summary>
        /// 排序，升序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
          List<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> where,
Expression<Func<TEntity, TKey>> order);
        
        /// <summary>
        /// 排序，降序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
         List<TEntity> QueryOrderByDescending<TKey>(Expression<Func<TEntity, bool>> where,
Expression<Func<TEntity, TKey>> order);
      

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">页容量</param>
        /// <param name="rowcount">数据条数</param>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        List<TEntity> QueryByPage<Tkey>(int pageindex, int pagesize, out int rowcount,
            Expression<Func<TEntity, Tkey>> order, Expression<Func<TEntity, bool>> where);
   
        #endregion

        #region 3.0编辑相关方法

          void Edit(TEntity model, string[] propertys);
      
        #endregion

        #region 4.0删除相关方法

        void Delete(TEntity model, bool isadded);
    

        #endregion

        #region 5.0新增相关方法

        void add(TEntity model);
     
        #endregion

        #region 6.0统一提交
        int SaveChanges();
       
        #endregion
        List<TResult> RunProc<TResult>(string sql, params object[] pamrs);
    }
}
