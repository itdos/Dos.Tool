using System;
using System.Data;

namespace Hxj.IDBO
{
    public interface IDbObject
    {
        /// <summary>
        /// 删除数据表
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <param name="TableName">表名</param>
        /// <returns>删除成功否</returns>
        bool DeleteTable(string DbName, string TableName);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <param name="SQLString">数据表名</param>
        /// <returns>返回影响记录数</returns>
        int ExecuteSql(string DbName, string SQLString);
        /// <summary>
        /// 返回数据表字段列(字段)信息表
        ///  返回表字段结构:
        ///     colorder,ColumnName,TypeName,Length,Preci,Scale,
        ///     IsIdentity('√'),isPK('√'),cisNull('√'),defaultVal,deText
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <param name="TableName">数据表名</param>
        /// <returns>信息表</returns>
        DataTable GetColumnInfoList(string DbName, string TableName);
        /// <summary>
        /// 返回数据列表(简要)
        ///   返回结构:
        ///     colorder,ColumnName,TypeName
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <param name="TableName">数据表名</param>
        /// <returns></returns>
        DataTable GetColumnList(string DbName, string TableName);
        /// <summary>
        /// 返回数据库列表
        ///     返回表结构: name,cuser(所有者),type(对象类型=DB),dates(创建时间)
        /// </summary>
        /// <returns></returns>
        DataTable GetDBList();
        /// <summary>
        /// 返回有标识的主键
        ///   返回表结构:
        ///     colorder,ColumnName,TypeName,Length,Preci,Scale,
        ///     IsIdentity('√'),isPK('√'),cisNull('√'),defaultVal,deText 
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <param name="TableName">数据表名</param>
        /// <returns></returns>
        DataTable GetKeyName(string DbName, string TableName);
        /// <summary>
        /// 返回对象SQL脚本。如存储过程、默认值等
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <param name="objName">对象名</param>
        /// <returns></returns>
        string GetObjectInfo(string DbName, string objName);
        /// <summary>
        /// 返回存储过程列表
        ///   返回表结构：name,cuser(所有人),type(对象类型=P),dates(创建时间)
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <returns></returns>
        DataTable GetProcInfo(string DbName);
        /// <summary>
        /// 返回存储过程名称列表
        ///  返回表结构：name
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <returns></returns>
        DataTable GetProcs(string DbName);
        /// <summary>
        /// 返回一个值
        /// </summary>
        /// <param name="DbName"></param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        object GetSingle(string DbName, string SQLString);
        /// <summary>
        /// 返回数据表所有(原始)记录
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <param name="TableName">表名</param>
        /// <param name="TopNum">返回前N条记录，为0表示所有</param>
        /// <returns></returns>
        DataTable GetTabData(string DbName, string TableName, int TopNum);
        /// <summary>
        /// 返回所有用户数据表
        ///   返回表结构：name
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <returns></returns>
        DataTable GetTables(string DbName);
        /// <summary>
        /// 返回用户数据表详细信息
        ///   返回表结构：name,cuser(所有者),type(对象类型=U),dates(创建时间)
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <returns></returns>
        DataTable GetTablesInfo(string DbName);
        /// <summary>
        /// 返回数据表、视图、存储过程等对象信息列表
        ///   返回表结构：
        ///    [name],type（对象类型）
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <returns></returns>
        DataTable GetTabViews(string DbName);
        /// <summary>
        /// 返回数据表、视图、存储过程等对象详细信息列表
        ///   返回表结构：
        ///     name,cuser(所有者),type(对象类型),dates(创建时间)
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <returns></returns>
        DataTable GetTabViewsInfo(string DbName);
        /// <summary>
        /// 返回数据服务器版本
        /// </summary>
        /// <returns></returns>
        string GetVersion();
        /// <summary>
        /// 返回数据视图名称列表
        ///    返回表结构：name
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <returns></returns>
        DataTable GetVIEWs(string DbName);
        /// <summary>
        /// 返回数据视图详细列表
        ///   返回表结构：
        ///     name,cuser(所有者),type(对象类型),dates(创建时间)
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <returns></returns>
        DataTable GetVIEWsInfo(string DbName);
        /// <summary>
        /// 返回查询结果
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        DataSet Query(string DbName, string SQLString);
        /// <summary>
        /// 重命名对象
        /// </summary>
        /// <param name="DbName">数据库名</param>
        /// <param name="OldName">原名</param>
        /// <param name="NewName">新名</param>
        /// <returns>成功否</returns>
        bool RenameTable(string DbName, string OldName, string NewName);
        /// <summary>
        /// 获取或设置数据连接字符串
        /// </summary>
        string DbConnectStr { get; set; }
        /// <summary>
        /// 获取数据库类型(SQL2000,SQL2005,Oracle,OleDb)
        /// </summary>
        string DbType { get; }
    }
}

