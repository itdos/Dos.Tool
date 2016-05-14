using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Dos.ORM;
using System.Data.Common;
using DAL;
using DAL.Base;
using Model;
using Model.Param;
using DataCache;

namespace ${BusinessNameSpace}
{
    public class #if(${BusinessClassName}!="")${BusinessClassName}#else${TableName}Logic#end
    {
        /// <summary>
        /// 获取数据。此数据会持续增长，所以不建议一次性缓存。建议单个Model实体缓存。
        /// </summary>
        public BaseResult GetList(#if(${ParamClassName}!="")${ParamClassName}#else${TableName}Param#end param)
        {
            var where = new Where<#if(${ModelClassName}!="")${ModelClassName}#else${TableName}#end>();
            #region 模糊搜索条件
			
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} != "true")
#if(${Item.csType}=="string")
			if (!string.IsNullOrWhiteSpace(param.Search${Item.ColumnName}))
            {
                where.And(d => d.${Item.ColumnName}.Like(param.Search${Item.ColumnName}));
            }
#end
#if(${Item.csType}=="int")
			if (param.Search${Item.ColumnName} != 0)
            {
                where.And(d => d.${Item.ColumnName} == param.Search${Item.ColumnName});
            }
#end
#if(${Item.csType}=="DateTime")
			if (param.Search${Item.ColumnName}Start > DateTime.MinValue)
            {
                where.And(d => d.${Item.ColumnName} > param.Search${Item.ColumnName}Start);
            }
            if (param.Search${Item.ColumnName}End > DateTime.MinValue)
            {
                where.And(d => d.${Item.ColumnName} < param.Search${Item.ColumnName}End);
            }
#end
#end
#end
            #endregion

            #region 是否分页
            var dateCount = 0;
            if (param._PageIndex != null && param._PageSize != null)
            {
                //取总数，以计算共多少页。自行考虑将总数缓存。
                dateCount = #if(${RepositoryClassName}!="")${RepositoryClassName}#else${TableName}Repository#end.Count(where);//.SetCacheTimeOut(10)
            }
            #endregion
            var list = #if(${RepositoryClassName}!="")${RepositoryClassName}#else${TableName}Repository.Query(where, d => d.${pkName}, "desc", null, param._PageSize, param._PageIndex);

            return new BaseResult(true, list, "", dateCount);
        }
        public BaseResult GetModel(#if(${ParamClassName}!="")${ParamClassName}#else${TableName}Param#end param)
        {
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} == "true")
#if(${Item.csType}=="int")
            if (param.${Item.ColumnName} == 0)
            {
                return new BaseResult(false, null, Msg.ParamError);
            }
#else
			if (param.${Item.ColumnName} == null)
            {
                return new BaseResult(false, null, Msg.ParamError);
            }
#end
			//取缓存
            var model = #if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}Cache#end.GetModel(param.${Item.ColumnName});
            if (model == null)
            {
                //如果缓存不存在，则从数据库获取
                model = #if(${RepositoryClassName}!="")${RepositoryClassName}#else${TableName}Repository#end.First(d => d.${Item.ColumnName} == param.${Item.ColumnName});
                #if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}Cache#end.SetModel(model);
            }
            return new BaseResult(true, model);
#end
#end
#end
        }
        /// <summary>
        /// 新增数据。
        /// </summary>
        public BaseResult Add(#if(${ParamClassName}!="")${ParamClassName}#else${TableName}Param#end param)
        {
			//此处根据需要自行修改数据判断
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} != "true")
#if(${Item.csType}=="int")
			if (param.Search${Item.ColumnName} == 0)
            {
                return new BaseResult(false, null, Msg.ParamError);
            }
#end
#if(${Item.csType}=="string")
			if (string.IsNullOrWhiteSpace(param.${Item.ColumnName}))
            {
                return new BaseResult(false, null, Msg.ParamError);
            }
#end
#end
#end
            var model = new #if(${ModelClassName}!="")${ModelClassName}#else${TableName}#end
            {
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} != "true")
#if(${Item.Column_id} != ${TableColumns.Rows.Count})
				${Item.ColumnName} = param.${Item.ColumnName},
#else
				${Item.ColumnName} = param.${Item.ColumnName}
#end
#end
#end
            };
            var count = #if(${RepositoryClassName}!="")${RepositoryClassName}#else${TableName}Repository#end.Insert(model);
            //设置缓存
            #if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}Cache#end.SetModel(model);
            return new BaseResult(count > 0, count, count > 0 ? "" : Msg.Line0);
        }
        /// <summary>
        /// 删除数据。必须传入Id
        /// </summary>
        public BaseResult Del(#if(${ParamClassName}!="")${ParamClassName}#else${TableName}Param#end param)
        {
            if (param.${pkName} == null)
            {
                return new BaseResult(false, null, Msg.ParamError);
            }
            var count = #if(${RepositoryClassName}!="")${RepositoryClassName}#else${TableName}Repository#end.Delete(param.${pkName});
            //更新缓存
            #if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}Cache#end.DelModel(param.${pkName});
            return new BaseResult(count > 0, count, count > 0 ? "" : Msg.Line0);
        }
        /// <summary>
        /// 修改数据。必须传入Id
        /// </summary>
        public BaseResult Upt(#if(${ParamClassName}!="")${ParamClassName}#else${TableName}Param#end param)
        {
            if (param.${pkName} == null)
            {
                return new BaseResult(false, null, Msg.ParamError);
            }
            var model = new #if(${ModelClassName}!="")${ModelClassName}#else${TableName}#end();
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} != "true")
				if (param.${Item.ColumnName} != null)
					model.${Item.ColumnName} = param.${Item.ColumnName};
#end
#end
            var count = #if(${RepositoryClassName}!="")${RepositoryClassName}#else${TableName}Repository#end.Update(model, d => d.${pkName} == param.${pkName});
            //更新缓存
            #if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}Cache#end.DelModel(param.${pkName});
            return new BaseResult(true);
        }
    }
}
