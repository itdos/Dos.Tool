using System;
using Dos.ORM;

namespace @Model.NameSpace
{
    /// <summary>
    /// 实体类@(Model.ClassName)。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class @Model.ClassName
    {
@foreach(var item in Model.Columns)
{
		@:/// <summary>
		@:/// @(item.DeText)
		@:/// </summary>
		@:public @item.TypeName @item.ColumnName { get; set; }
}
	}
}