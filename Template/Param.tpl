using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ${ParamNameSpace}
{
    public class #if(${ParamClassName}!="")${ParamClassName}#else${TableName}Param#end : Param
    {
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} == "true")
		public ${Item.csType} ${Item.ColumnName} { get; set; }
#else
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public ${Item.csType} ${Item.ColumnName} { get; set; }
#end
#end

		//搜索参数
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} != "true")
#if(${Item.csType}=="DateTime")
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public ${Item.csType} Search${Item.ColumnName}Start { get; set; }
		
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public ${Item.csType} Search${Item.ColumnName}End { get; set; }
#else
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public ${Item.csType} Search${Item.ColumnName} { get; set; }
#end
#end
#end
    }
}