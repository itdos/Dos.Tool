using System;
using System.Runtime.Serialization;
using Dos.ORM;

namespace @Model.NameSpace
{
    /// <summary>
    /// 实体类@(Model.ClassName)。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("@Model.TableName")]
    [Serializable]
	[DataContract]
    public partial class @Model.ClassName : Entity
    {
        #region Model
@foreach(var item in Model.Columns)
{
		@:private @item.TypeName _@item.ColumnName;
}

@foreach(var item in Model.Columns)
{
		@:/// <summary>
		@:/// @(item.DeText)
		@:/// </summary>
		@:[Field("@item.ColumnNameRealName")]
		@:[DataMember]
		@:public @item.TypeName @item.ColumnName
		@:{
			@:get{ return _@item.ColumnName; }
			@:set
			@:{
				@:this.OnPropertyValueChange("@item.ColumnName");
				@:this._@item.ColumnName = value;
			@:}
		@:}
}
		#endregion

		#region Method
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
@foreach(var item in Model.PrimaryKeyColumns)
{
				@:_.@item.ColumnName,
}
			};
        }
@if(Model.IdentityColumn != null)
{
		@:/// <summary>
        @:/// 获取实体中的标识列
        @:/// </summary>
        @:public override Field GetIdentityField()
        @:{
            @:return _.@Model.IdentityColumn.ColumnName;
        @:}
}
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
@foreach(var item in Model.Columns)
{
				@:_.@item.ColumnName,
}
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
@foreach(var item in Model.Columns)
{
				@:this._@item.ColumnName,
}
			};
        }
        /// <summary>
        /// 是否是v1.10.5.6及以上版本实体。
        /// </summary>
        /// <returns></returns>
        public override bool V1_10_5_6_Plus()
        {
            return true;
        }
        #endregion

		#region _Field
        /// <summary>
        /// 字段信息
        /// </summary>
        public class _
        {
			/// <summary>
			/// * 
			/// </summary>
			public readonly static Field All = new Field("*", "@Model.TableName");
@foreach(var item in Model.Columns)
{
            @:/// <summary>
			@:/// @item.DeText
			@:/// </summary>
			@:public readonly static Field @item.ColumnName = new Field("@item.ColumnNameRealName", "@Model.TableName", "@item.DeText");
}
        }
        #endregion
	}
}