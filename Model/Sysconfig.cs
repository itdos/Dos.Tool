/*************************************************************************
 * 
 * Filename :Sysconfig
 * 
 * steven hu   2010/7/9 23:19:32
 *  
 * http://www.cnblogs.com/huxj
 *   
 * 
 * Change History:
 * 
 * 
**************************************************************************/



using System;
using System.Collections.Generic;
using System.Text;

namespace Hxj.Tools.EntityDesign.Model
{
    public class Sysconfig
    {
        private string _namespace = "Dos.Model";


        /// <summary>
        /// 记住的命名空间
        /// </summary>
        public string Namespace
        {
            get
            {
                return _namespace;
            }
            set
            {
                _namespace = value;
            }
        }


        private string batchDirectoryPath;


        /// <summary>
        /// 记住的批量生成的路径
        /// </summary>
        public string BatchDirectoryPath
        {
            get
            {
                return batchDirectoryPath;
            }
            set
            {
                batchDirectoryPath = value;
            }
        }
    }
}
