using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DataCache.Base;

namespace DataCache
{
    public class #if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}Cache#end : CacheBase
    {
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} == "true")
		public static #if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}#end GetModel(${Item.csType} ${Item.ColumnName})
        {
            var result = Get<#if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}#end>("Get#if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}#end" + ${Item.ColumnName});
            return result;
        }
		
        public static bool SetModel(#if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}#end model)
        {
            return Set("Ge#if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}#end" + model.${Item.ColumnName}, model);
        }
		
        public static bool DelModel(${Item.csType} ${Item.ColumnName})
        {
            return Remove("Get#if(${CacheModelClassName}!="")${CacheModelClassName}#else${TableName}#end" + ${Item.ColumnName});
        }
#end
#end
    }
}
