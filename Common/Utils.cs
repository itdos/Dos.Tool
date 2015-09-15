using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Hxj.Tools.EntityDesign.Model;
using System.Data;

namespace Hxj.Tools.EntityDesign
{
    public class Utils
    {
        /// <summary>
        /// 数据库连接配置文件
        /// </summary>
        public static readonly string DatabaseconfigPath = Application.StartupPath + "/Config/databaseconfig.xml";


        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns></returns>
        public static List<Model.Connection> GetConnectionList()
        {
            List<Model.Connection> list = new List<Hxj.Tools.EntityDesign.Model.Connection>();
            XmlDocument doc = getXmlDocument();

            XmlNodeList xmlNodeList = doc.SelectNodes("servers/server");
            if (null != xmlNodeList && xmlNodeList.Count > 0)
            {
                foreach (XmlNode node in xmlNodeList)
                {
                    if (!node.HasChildNodes)
                        continue;

                    Model.Connection connection = new Hxj.Tools.EntityDesign.Model.Connection();

                    connection.ID = new Guid(node.Attributes["id"].Value);
                    connection.Name = node.Attributes["name"].Value;
                    connection.Database = node.Attributes["database"].Value;
                    connection.ConnectionString = node.FirstChild.InnerText;
                    connection.DbType = node.Attributes["dbtype"].Value;
                    list.Add(connection);

                }
            }
            return list;
        }


        static XmlDocument getXmlDocument()
        {
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(DatabaseconfigPath))
            {
                File.WriteAllText(DatabaseconfigPath, @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<servers>
</servers>
", Encoding.UTF8);
                //System.Threading.Thread.Sleep(2000);
            }


            doc.Load(DatabaseconfigPath);


            return doc;

        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteConnection(string id)
        {
            if (string.IsNullOrEmpty(id))
                return;

            XmlDocument doc = getXmlDocument();

            XmlNodeList xmlNodeList = doc.SelectNodes("servers/server");
            if (null != xmlNodeList && xmlNodeList.Count > 0)
            {
                foreach (XmlNode node in xmlNodeList)
                {
                    if (node.Attributes["id"].Value.Trim().ToLower().Equals(id.Trim().ToLower()))
                    {
                        node.ParentNode.RemoveChild(node);
                        break;
                    }
                }
            }

            doc.Save(DatabaseconfigPath);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="conection"></param>
        public static void AddConnection(Model.Connection conection)
        {
            XmlDocument doc = getXmlDocument();

            XmlNode root = doc.SelectSingleNode("servers");

            XmlElement xe = doc.CreateElement("server");

            xe.SetAttribute("id", conection.ID.ToString());
            xe.SetAttribute("name", conection.Name);
            xe.SetAttribute("database", conection.Database);
            xe.SetAttribute("dbtype", conection.DbType);

            XmlElement xe1 = doc.CreateElement("connectionstring");
            XmlCDataSection cdata = doc.CreateCDataSection(conection.ConnectionString);
            xe1.AppendChild(cdata);

            xe.AppendChild(xe1);

            root.AppendChild(xe);

            doc.Save(DatabaseconfigPath);
        }

        /// <summary>
        /// 获取一个连接配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Model.Connection GetConnectionModel(string id)
        {
            Model.Connection connModel = null;
            if (string.IsNullOrEmpty(id))
                return connModel;

            XmlDocument doc = new XmlDocument();
            doc.Load(DatabaseconfigPath);

            XmlNode xmlNode = doc.SelectSingleNode("servers/server[@id='" + id.ToString() + "']");
            if (null != xmlNode)
            {
                connModel = new Hxj.Tools.EntityDesign.Model.Connection();
                connModel.ID = new Guid(xmlNode.Attributes["id"].Value);
                connModel.Name = xmlNode.Attributes["name"].Value;
                connModel.Database = xmlNode.Attributes["database"].Value;
                connModel.ConnectionString = xmlNode.FirstChild.InnerText;
                connModel.DbType = xmlNode.Attributes["dbtype"].Value;
            }

            return connModel;
        }

        /// <summary>
        /// 系统配置路径
        /// </summary>
        public static string SysconfigPath = Application.StartupPath + "/Config/sysconfig.xml";


        /// <summary>
        /// 获取系统配置
        /// </summary>
        /// <returns></returns>
        public static Model.Sysconfig GetSysconfigModel()
        {
            Model.Sysconfig sysconfigModel = new Sysconfig();

            XmlDocument doc = new XmlDocument();
            doc.Load(SysconfigPath);
            XmlNode node = doc.SelectSingleNode("configs/config[@key='namespace']");
            if (null != node)
            {
                sysconfigModel.Namespace = node.FirstChild.InnerText;
            }
            node = doc.SelectSingleNode("configs/config[@key='batchdirectorypath']");
            if (null != node)
            {
                sysconfigModel.BatchDirectoryPath = node.FirstChild.InnerText;
            }

            return sysconfigModel;
        }


        /// <summary>
        /// 设置系统配置
        /// </summary>
        /// <returns></returns>
        public static void GetSysconfigModel(Model.Sysconfig sysconfigModel)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(SysconfigPath);
            XmlNode node = doc.SelectSingleNode("configs/config[@key='namespace']");
            if (null != node)
            {
                node.FirstChild.Value = sysconfigModel.Namespace;
            }
            node = doc.SelectSingleNode("configs/config[@key='batchdirectorypath']");
            if (null != node)
            {
                node.FirstChild.Value = sysconfigModel.BatchDirectoryPath;
            }

            doc.Save(SysconfigPath);
        }

        /// <summary>
        /// 写命名空间
        /// </summary>
        /// <param name="names"></param>
        public static void WriteNamespace(string names)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(SysconfigPath);
            XmlNode node = doc.SelectSingleNode("configs/config[@key='namespace']");
            node.FirstChild.Value = names;

            //XmlCDataSection cdata = doc.CreateCDataSection(names);
            //node.AppendChild(cdata);

            doc.Save(SysconfigPath);
        }


        /// <summary>
        /// 写批量路径
        /// </summary>
        /// <param name="names"></param>
        public static void WriteBatchDirectoryPath(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(SysconfigPath);
            XmlNode node = doc.SelectSingleNode("configs/config[@key='batchdirectorypath']");
            node.FirstChild.Value = path;

            //XmlCDataSection cdata = doc.CreateCDataSection(path);
            //node.AppendChild(cdata);

            doc.Save(SysconfigPath);
        }

        /// <summary>
        /// 读命名空间
        /// </summary>
        /// <returns></returns>
        public static string ReadNamespace()
        {
            return GetSysconfigModel().Namespace;
        }


        /// <summary>
        /// 读保存的批量导出路径
        /// </summary>
        /// <returns></returns>
        public static string ReadBatchDirectoryPath()
        {
            return GetSysconfigModel().BatchDirectoryPath;
        }


        /// <summary>
        /// 列信息装换
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<ColumnInfo> GetColumnInfos(DataTable dt)
        {
            List<ColumnInfo> list = new List<ColumnInfo>();
            if (dt == null)
            {
                return null;
            }
            foreach (DataRow row in dt.Rows)
            {
                string str = row["Colorder"].ToString();  //序号
                string str2 = row["ColumnName"].ToString();  //列名
                string str3 = row["TypeName"].ToString();  //类型
                string str4 = row["IsIdentity"].ToString();  //标识
                string str5 = row["IsPK"].ToString();  //主键
                string str6 = row["Length"].ToString();  //长度
                string str7 = row["Preci"].ToString();  //精度
                string str8 = row["Scale"].ToString();  //小数位
                string str9 = row["cisNull"].ToString(); //为空
                string str10 = row["DefaultVal"].ToString();  //默认值
                string str11 = row["DeText"].ToString();  //描述
                ColumnInfo item = new ColumnInfo();
                item.Colorder = str;
                item.ColumnName = str2;
                item.TypeName = str3;
                item.IsIdentity = str4 == "√";
                item.IsPK = str5 == "√";
                item.Length = str6;
                item.Preci = str7;
                item.Scale = str8;
                item.cisNull = (str9 == "√") || (string.Compare(str9, "Y", true) == 0);
                item.DefaultVal = str10;
                item.DeText = str11;
                item.ColumnNameRealName = item.ColumnName;
                list.Add(item);
            }
            return list;
        }

        public static DataTable GetColumnInfoDataTable(List<ColumnInfo> collist)
        {
            DataTable table = new DataTable();
            table.Columns.Add("colorder");
            table.Columns.Add("ColumnName");
            table.Columns.Add("TypeName");
            table.Columns.Add("Length");
            table.Columns.Add("Preci");
            table.Columns.Add("Scale");
            table.Columns.Add("IsIdentity");
            table.Columns.Add("isPK");
            table.Columns.Add("cisNull");
            table.Columns.Add("defaultVal");
            table.Columns.Add("deText");
            foreach (ColumnInfo info in collist)
            {
                DataRow row = table.NewRow();
                row["colorder"] = info.Colorder;
                row["ColumnName"] = info.ColumnName;
                row["TypeName"] = info.TypeName;
                row["Length"] = info.Length;
                row["Preci"] = info.Preci;
                row["Scale"] = info.Scale;
                row["IsIdentity"] = info.IsIdentity ? "√" : "";
                row["isPK"] = info.IsPK ? "√" : "";
                row["cisNull"] = info.cisNull ? "√" : "";
                row["defaultVal"] = info.DefaultVal;
                row["deText"] = info.DeText;
                table.Rows.Add(row);
            }
            return table;
        }

        private static System.Text.RegularExpressions.Regex regSpace = new System.Text.RegularExpressions.Regex(@"\s");

        /// <summary>
        /// 去掉空格
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceSpace(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            char firstChar = value[0];
            if (firstChar >= 48 && firstChar <= 57)
            {
                //value = "F" + value;
                value = "_" + value;
            }
            return regSpace.Replace(value.Trim(), " ");
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToUpperFirstword(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.Substring(0, 1).ToUpper() + value.Substring(1);

        }


    }
}
