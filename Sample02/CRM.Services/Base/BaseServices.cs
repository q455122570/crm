using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Services
{
    using System.Linq.Expressions;
    using IRepository;
    using IServices;
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {

        //1.0数据仓储的接口
        public IBaseRepository<TEntity> baseDal;
        
        #region 2.0查询
        /// <summary>
        /// 根据lambda表达式查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where)
        {
            return baseDal.QueryWhere(where);
        }
        /// <summary>
        /// 连表操作
        /// </summary>
        /// <param name="where"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> where, string[] tableNames)
        {
             return baseDal.QueryJoin(where, tableNames);
        }

        /// <summary>
        /// 排序，升序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> where,
Expression<Func<TEntity, TKey>> order)
        {
            return baseDal.QueryOrderBy(where, order);
        }
        /// <summary>
        /// 排序，降序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<TEntity> QueryOrderByDescending<TKey>(Expression<Func<TEntity, bool>> where,
Expression<Func<TEntity, TKey>> order)
        {
            return baseDal.QueryOrderByDescending(where, order);
        }

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
        public List<TEntity> QueryByPage<Tkey>(int pageindex, int pagesize, out int rowcount,
            Expression<Func<TEntity, Tkey>> order, Expression<Func<TEntity, bool>> where)
        {
            return baseDal.QueryByPage(pageindex, pagesize,out rowcount,order,where);
        }
        #endregion

        #region 3.0编辑相关方法

        public void Edit(TEntity model, string[] propertys)
        {
             baseDal.Edit(model, propertys);
        }

        #endregion

        #region 4.0删除相关方法

        public void Delete(TEntity model, bool isadded)
        {
            baseDal.Delete(model, isadded);
        }

        #endregion

        #region 5.0新增相关方法

        public void add(TEntity model)
        {
            baseDal.add(model);
        }

        #endregion

        #region 6.0统一提交
        public int SaveChanges()
        {
          return  baseDal.SaveChanges();
        }
        #endregion
        public List<TResult> RunProc<TResult>(string sql, params object[] pamrs)
        {

            return baseDal.RunProc<TResult>(sql, pamrs);
        }
    }
}
