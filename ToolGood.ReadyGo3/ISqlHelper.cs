﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolGood.ReadyGo3.Gadget.Caches;
using ToolGood.ReadyGo3.Gadget.Events;
using ToolGood.ReadyGo3.Gadget.Internals;
using ToolGood.ReadyGo3.Gadget.TableManager;
using ToolGood.ReadyGo3.PetaPoco;

namespace ToolGood.ReadyGo3
{
    public interface ISqlHelper
    {
        /// <summary>
        /// 是否释放
        /// </summary>
        bool _IsDisposed { get; }
        /// <summary>
        /// SQL设置
        /// </summary>
        SqlRecord _Sql { get; }
        /// <summary>
        /// 数据库配置
        /// </summary>
        SqlConfig _Config { get; }
        /// <summary>
        /// SQL操作事件
        /// </summary>
        SqlEvents _Events { get; }
        /// <summary>
        /// 
        /// </summary>
        SqlTableHelper _TableHelper { get; }
        /// <summary>
        /// 表名设置
        /// </summary>
        TableNameManager _TableNameManager { get; }

        /// <summary>
        /// 执行SQL 查询,返回数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL 语句</param>
        /// <param name="args">SQL 参数</param>
        /// <returns></returns>
        int Count<T>(string sql = "", params object[] args);
        /// <summary>
        /// 执行SQL 查询,返回数量
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        int Count(string sql, params object[] args);
         
        //
        // 摘要:
        //     删除
        //
        // 参数:
        //   poco:
        //     对象
        int Delete<T>(T poco) where T : class;
        //
        // 摘要:
        //     删除
        //
        // 参数:
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        int Delete<T>(string sql, params object[] args);
        
        //
        // 摘要:
        //     删除
        //
        // 参数:
        //   primaryKey:
        //     主键
        //
        // 类型参数:
        //   T:
        int DeleteById<T>(object primaryKey);
         
        //
        // 摘要:
        //     释放
        void Dispose();
        //
        // 摘要:
        //     执行 SQL 语句，并返回受影响的行数
        //
        // 参数:
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 返回结果:
        //     返回受影响的行数
        int Execute(string sql, params object[] args);
         
        //
        // 摘要:
        //     执行SQL 查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行。
        //
        // 参数:
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        //
        // 返回结果:
        //     返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        T ExecuteScalar<T>(string sql = "", params object[] args);
        
        //
        // 摘要:
        //     执行SQL 查询,判断是否存在，返回bool类型
        //
        // 参数:
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        bool Exists<T>(string sql, params object[] args);
        //
        // 摘要:
        //     执行SQL 查询,判断是否存在，返回bool类型
        //
        // 参数:
        //   primaryKey:
        //     主键值
        //
        // 类型参数:
        //   T:
        bool Exists<T>(object primaryKey);
        
        //
        // 摘要:
        //     获取第一个类型，若数量为0，则抛出异常
        //
        // 参数:
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        T First<T>(string sql = "", params object[] args);
       
        //
        // 摘要:
        //     获取第一个类型
        //
        // 参数:
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        T FirstOrDefault<T>(string sql = "", params object[] args);
       
        //
        // 摘要:
        //     插入，支持主键自动获取。
        //
        // 参数:
        //   poco:
        //     对象
        object Insert<T>(T poco) where T : class;
         
        //
        // 摘要:
        //     插入集合，不返回主键
        //
        // 参数:
        //   list:
        //
        // 类型参数:
        //   T:
        void InsertList<T>(List<T> list) where T : class;
        
        //
        // 摘要:
        //     生成序列化的Guid
        Guid NewGuid();
        //
        // 摘要:
        //     执行SQL 查询,返回Page类型
        //
        // 参数:
        //   page:
        //     页数
        //
        //   itemsPerPage:
        //     每页数量
        //
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        Page<T> Page<T>(long page, long itemsPerPage, string sql = "", params object[] args);
      
        //
        // 摘要:
        //     保存
        //
        // 参数:
        //   poco:
        void Save(object poco);
 
        //
        // 摘要:
        //     执行SQL 查询,返回集合
        //
        // 参数:
        //   offset:
        //     跳过
        //
        //   limit:
        //     获取个数
        //
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        List<T> Select<T>(long limit, long offset, string sql = "", params object[] args);
        //
        // 摘要:
        //     执行SQL 查询,返回集合
        //
        // 参数:
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        List<T> Select<T>(string sql = "", params object[] args);
        //
        // 摘要:
        //     执行SQL 查询,返回集合
        //
        // 参数:
        //   limit:
        //     获取个数
        //
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        List<T> Select<T>(long limit, string sql = "", params object[] args);
       
         
        //
        // 摘要:
        //     获取唯一一个类型，若数量不为1，则抛出异常
        //
        // 参数:
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        T Single<T>(string sql = "", params object[] args);
       
        //
        // 摘要:
        //     获取唯一一个类型，若数量不为1，则抛出异常
        //
        // 参数:
        //   primaryKey:
        //     主键名
        //
        // 类型参数:
        //   T:
        T SingleById<T>(object primaryKey);
       
        //
        // 摘要:
        //     获取唯一一个类型，若数量大于1，则抛出异常
        //
        // 参数:
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        T SingleOrDefault<T>(string sql = "", params object[] args);
        
        //
        // 摘要:
        //     获取唯一一个类型，若数量大于1，则抛出异常
        //
        // 参数:
        //   primaryKey:
        //     主键名
        //
        // 类型参数:
        //   T:
        T SingleOrDefaultById<T>(object primaryKey);
      
        //
        // 摘要:
        //     更新
        //
        // 参数:
        //   poco:
        //     对象
        int Update<T>(T poco) where T : class;
        //
        // 摘要:
        //     更新
        //
        // 参数:
        //   sql:
        //     SQL 语句
        //
        //   args:
        //     SQL 参数
        //
        // 类型参数:
        //   T:
        int Update<T>(string sql, params object[] args);
        
        //
        // 摘要:
        //     使用缓存
        //
        // 参数:
        //   second:
        //
        //   cacheTag:
        //
        //   cacheService:
        SqlHelper UseChache(int second, string cacheTag = null, ICacheService cacheService = null);
        //
        // 摘要:
        //     使用事务
        Transaction UseTransaction();
        ////
        //// 摘要:
        ////     动态Sql拼接，
        ////
        //// 参数:
        ////   where:
        ////
        ////   args:
        ////
        //// 类型参数:
        ////   T:
        //WhereHelper<T> Where<T>(string where, params object[] args) where T : class, new();
        ////
        //// 摘要:
        ////     动态Sql拼接，
        ////
        //// 参数:
        ////   where:
        ////
        //// 类型参数:
        ////   T:
        //WhereHelper<T> Where<T>(string where) where T : class, new();
        ////
        //// 摘要:
        ////     动态Sql拼接
        ////
        //// 类型参数:
        ////   T:
        //WhereHelper<T> Where<T>() where T : class, new();
        ////
        //// 摘要:
        ////     动态Sql拼接
        ////
        //// 参数:
        ////   where:
        //WhereHelper<T> Where<T>(Expression<Func<T, bool>> where) where T : class, new();

    }
}
