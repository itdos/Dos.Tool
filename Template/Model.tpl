using System;
using System.Data;
using System.Data.Common;
using Dos.ORM;
using Dos.ORM.Common;

namespace ${ModelNameSpace}
{
    /// <summary>
    /// 实体类#if(${ModelClassName}!="")${ModelClassName}#else${TableName}#end 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("${TableName}")]
    [Serializable]
    public partial class #if(${ModelClassName}!="")${ModelClassName}#else${TableName}#end: Entity
    {
        #region Model
#foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} == "true")
		private ${Item.csType} _${Item.ColumnName}; 
#else
		private ${Item.csType}#if(${Item.csType}=="int" && ${Item.NullAble}=="true")?#elseif(${Item.csType}=="decimal" && ${Item.NullAble}=="true")?#elseif(${Item.csType}=="DateTime"  && ${Item.NullAble}=="true")?#elseif(${Item.csType}=="bool" && ${Item.NullAble}=="true")?#end _${Item.ColumnName};
#end
#end
        #foreach($Item in $TableColumns.Rows)
#if(${Item.PrimaryKey} == "true")
		/// <summary>
		/// ${Item.ColumnDesc}
		/// </summary>
		public ${Item.csType} ${Item.ColumnName}
		{
			get{ return _${Item.ColumnName}; }
			set
			{
				this.OnPropertyValueChange(_.${Item.ColumnName},_${Item.ColumnName},value);
				this._${Item.ColumnName}=value;
			}
		}
#else
		/// <summary>
		/// ${Item.ColumnDesc}
		/// </summary>
		public ${Item.csType}#if(${Item.csType}=="int" && ${Item.NullAble}=="true")?#elseif(${Item.csType}=="decimal" && ${Item.NullAble}=="true")?#elseif(${Item.csType}=="DateTime" && ${Item.NullAble}=="true")?#elseif(${Item.csType}=="bool" && ${Item.NullAble}=="true")?#end ${Item.ColumnName}
		{
			get{ return _${Item.ColumnName}; }
			set
			{
				this.OnPropertyValueChange(_.${Item.ColumnName},_${Item.ColumnName},value);
				this._${Item.ColumnName}=value;
			}
		}
#end
#end
        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的标识列
        /// </summary>
        public override Field GetIdentityField()
        {
            return _.${pkName};
        }
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
				_.${pkName}};
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
#foreach($Item in $TableColumns.Rows)
#if(${Item.Column_id} != ${TableColumns.Rows.Count})
				_.${Item.ColumnName},
#else
				_.${Item.ColumnName}};
#end
#end
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
			return new object[] {
#foreach($Item in $TableColumns.Rows)
#if(${Item.Column_id} != ${TableColumns.Rows.Count})
				this._${Item.ColumnName},
#else
				this._${Item.ColumnName}};
#end
#end
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
			public readonly static Field All = new Field("*","${TableName}");
#foreach($Item in $TableColumns.Rows)
			/// <summary>
			/// ${Item.ColumnDesc}
			/// </summary>
			public readonly static Field ${Item.ColumnName} = new Field("${Item.ColumnName}","${TableName}","${Item.ColumnDesc}");
	#end
		#endregion


		}
	}
}

