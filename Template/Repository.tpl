using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common;
using DAL.Base;

namespace ${RepositoryNameSpace}
{
    /// <summary>
    /// 数据库处理层
    /// </summary>
    public class #if(${RepositoryClassName}!="")${RepositoryClassName}#else${TableName}Repository#end : Repository<#if(${ModelClassName}!="")${ModelClassName}#else${TableName}#end>
    {
        /// <summary>
        /// 
        /// </summary>
        public #if(${RepositoryClassName}!="")${RepositoryClassName}#else${TableName}Repository#end()
        {
            
        }
    }
}
