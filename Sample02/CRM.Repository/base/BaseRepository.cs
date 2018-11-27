using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq.Expressions;
    using IRepository;
    using System.Runtime.Remoting.Messaging;


    /// <summary>
    /// 统一父类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity:class 
    {
        //1.0实例化EF上下文容器
        //多个服务会产生多个EF对象，每次都要用对应EF容器操作，麻烦且性能低
        //BaseDBContext db = new BaseDBContext();
        //改进1.1，线程缓存。
        BaseDBContext db
        {
            get {
                //没有则创建
                object obj = CallContext.GetData("BaseDBContext");
                if (obj == null)
                {
                    obj = new BaseDBContext();
                }
                CallContext.SetData("BaseDBContext",obj);

                return obj as BaseDBContext;
                }
        } 

        DbSet<TEntity> _dbset;
        public BaseRepository() {
            _dbset = db.Set<TEntity>();
        }

        #region 2.0查询
        /// <summary>
        /// 根据lambda表达式查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where) {
            return _dbset.Where(where).ToList();
        }
        /// <summary>
        /// 连表操作
        /// </summary>
        /// <param name="where"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> where, string[] tableNames) {

            if (tableNames == null || tableNames.Any() == false)
            {
                throw new Exception("连表操作的表名称必须有值");
            }
            DbQuery<TEntity> query=_dbset;
            foreach(var tablename in tableNames)
            {
                query =query.Include(tablename);
            }
            return query.Where(where).ToList();
        }

        /// <summary>
        /// 排序，升序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> where,
Expression<Func<TEntity,TKey>>order) 
        { 
            return _dbset.Where(where).OrderBy(order).ToList();
        }
        /// <summary>
        /// 排序，降序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<TEntity> QueryOrderByDescending<TKey>(Expression<Func<TEntity, bool>> where,
Expression<Func<TEntity, TKey>> order)
        {
            return _dbset.Where(where).OrderByDescending(order).ToList();
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
            int skipCount = (pageindex - 1) * pagesize;
            rowcount = _dbset.Count(where);
            return _dbset.Where(where).OrderByDescending(order).Skip(skipCount).Take(pagesize).ToList();
        }
        #endregion

        #region 3.0编辑相关方法

        public void Edit(TEntity model,string[] propertys) {
            if (model==null) {
                throw new Exception("实体不能为空"); 
            }
            if (propertys.Any() == false)
            {
                throw new Exception("要修改的属性不能为空");
            }
            // 将model追加到EF容器
            System.Data.Entity.Infrastructure.DbEntityEntry Entry = db.Entry(model);
            Entry.State = System.Data.EntityState.Unchanged;
            foreach(var item in propertys)
            {
                Entry.Property(item).IsModified = true;
            }
            //关闭EF对实体的合法性验证参数
            db.Configuration.ValidateOnSaveEnabled = false;
        }

        #endregion

        #region 4.0删除相关方法

        public void Delete(TEntity model,bool isadded) { 
        //(!isadded)表示当前model没有追加到容器中
            if (!isadded)
            {
                _dbset.Attach(model);
            }
            _dbset.Remove(model);
        }

        #endregion

        #region 5.0新增相关方法

        public void add(TEntity model)
        {
            _dbset.Add(model);

        }

        #endregion

        #region 6.0统一提交
        public int SaveChanges()
        {
            return db.SaveChanges();
        }
        #endregion

        #region 调用存储过程

        public List<TResult> RunProc<TResult>(string sql,params object[] pamrs)
        {

            return db.Database.SqlQuery<TResult>(sql, pamrs).ToList();
        }
        #endregion
    }
}
