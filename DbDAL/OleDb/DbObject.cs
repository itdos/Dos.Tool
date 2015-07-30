using Hxj.IDBO;
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace Hxj.DbObjects.OleDb
{
    public class DbObject : IDbObject
    {
        private string _dbconnectStr;
        private OleDbConnection connect;

        public DbObject()
        {
            this.connect = new OleDbConnection();
        }

        public DbObject(string DbConnectStr)
        {
            this.connect = new OleDbConnection();
            this._dbconnectStr = DbConnectStr;
            this.connect.ConnectionString = DbConnectStr;
        }

        public DbObject(bool SSPI, string server, string User, string Pass)
        {
            this.connect = new OleDbConnection();
            this.connect = new OleDbConnection();
            this._dbconnectStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + server + ";Persist Security Info=False";
            this.connect.ConnectionString = this._dbconnectStr;
        }

        public bool DeleteTable(string DbName, string TableName)
        {
            try
            {
                string text1 = "DROP TABLE " + TableName + "";
                this.ExecuteSql(DbName, TableName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public OleDbDataReader ExecuteReader(string strSQL)
        {
            OleDbDataReader reader2;
            try
            {
                this.OpenDB();
                reader2 = new OleDbCommand(strSQL, this.connect).ExecuteReader();
            }
            catch (OleDbException exception)
            {
                throw new Exception(exception.Message);
            }
            return reader2;
        }

        public int ExecuteSql(string DbName, string SQLString)
        {
            this.OpenDB();
            OleDbCommand command = new OleDbCommand(SQLString, this.connect);
            command.CommandText = SQLString;
            return command.ExecuteNonQuery();
        }

        public DataTable GetColumnInfoList(string DbName, string TableName)
        {
            this.OpenDB();
            object[] restrictions = new object[4];
            restrictions[2] = TableName;
            DataTable oleDbSchemaTable = this.connect.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, restrictions);
            DataTable dt = this.Tab2Colum(oleDbSchemaTable);
            DataTable primarykeydt = this.GetKeyName(DbName, TableName);
            if (null != primarykeydt && primarykeydt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow[] drs = primarykeydt.Select("ColumnName='" + dr["ColumnName"].ToString() + "'");
                    if (null != drs && drs.Length > 0)
                    {
                        dr["isPK"] = "√";
                    }
                    else
                    {
                        dr["isPK"] = "";
                    }
                }
            }

            return dt;
        }

        public DataTable GetColumnInfoListSP(string DbName, string ViewName)
        {
            return null;
        }

        public DataTable GetColumnList(string DbName, string TableName)
        {
            this.OpenDB();
            object[] restrictions = new object[4];
            restrictions[2] = TableName;
            DataTable oleDbSchemaTable = this.connect.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, restrictions);
            return this.Tab2Colum(oleDbSchemaTable);
        }

        public DataTable GetDBList()
        {
            return null;
        }

        public DataTable GetKeyName(string DbName, string TableName)
        {
            try
            {
                this.OpenDB();
                DataTable oleDbSchemaTable = this.connect.GetOleDbSchemaTable(OleDbSchemaGuid.Key_Column_Usage, new object[4]);
                return this.Key2Colum(oleDbSchemaTable, TableName);
            }
            catch (Exception exception)
            {
                string message = exception.Message;
                return null;
            }
        }

        public string GetObjectInfo(string DbName, string objName)
        {
            return null;
        }

        public DataTable GetProcInfo(string DbName)
        {
            return null;
        }

        public DataTable GetProcs(string DbName)
        {
            return null;
        }

        public object GetSingle(string DbName, string SQLString)
        {
            try
            {
                this.OpenDB();
                object objA = new OleDbCommand(SQLString, this.connect).ExecuteScalar();
                if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                {
                    return null;
                }
                return objA;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetTabData(string DbName, string TableName, int TopNum)
        {
            StringBuilder builder = new StringBuilder();
            string s = "";
            if (TopNum > 0) { s = " top " + TopNum.ToString() + " "; }
            builder.Append("select" + s + " * from [" + TableName + "]");
            return this.Query("", builder.ToString()).Tables[0];
        }

        public DataTable GetTables(string DbName)
        {
            this.OpenDB();
            object[] restrictions = new object[4];
            restrictions[3] = "TABLE";
            DataTable oleDbSchemaTable = this.connect.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);
            return this.Tab2Tab(oleDbSchemaTable);
        }

        public DataTable GetTablesInfo(string DbName)
        {
            this.OpenDB();
            object[] restrictions = new object[4];
            restrictions[3] = "TABLE";
            DataTable oleDbSchemaTable = this.connect.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);
            return this.Tab2Tab(oleDbSchemaTable);
        }

        public DataTable GetTabViews(string DbName)
        {
            this.OpenDB();
            DataTable oleDbSchemaTable = this.connect.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            return this.Tab2Tab(oleDbSchemaTable);
        }

        public DataTable GetTabViewsInfo(string DbName)
        {
            this.OpenDB();
            DataTable oleDbSchemaTable = this.connect.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            return this.Tab2Tab(oleDbSchemaTable);
        }

        public string GetVersion()
        {
            return "";
        }

        public DataTable GetVIEWs(string DbName)
        {
            this.OpenDB();
            object[] restrictions = new object[4];
            restrictions[3] = "VIEW";
            DataTable oleDbSchemaTable = this.connect.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);
            return this.Tab2Tab(oleDbSchemaTable);
        }

        public DataTable GetVIEWsInfo(string DbName)
        {
            this.OpenDB();
            object[] restrictions = new object[4];
            restrictions[3] = "VIEW";
            DataTable oleDbSchemaTable = this.connect.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);
            return this.Tab2Tab(oleDbSchemaTable);
        }

        private DataTable Key2Colum(DataTable sTable, string TableName)
        {
            DataTable table = new DataTable();
            table.Columns.Add("colorder");
            table.Columns.Add("ColumnName");
            table.Columns.Add("TypeName");
            int num = 0;
            foreach (DataRow row in sTable.Rows)
            {
                if ((row[5].ToString() == TableName) && (row[2].ToString() == "PrimaryKey"))
                {
                    DataRow row2 = table.NewRow();
                    row2["colorder"] = row[9].ToString();
                    string str3 = row[6].ToString();
                    row2["ColumnName"] = str3;
                    foreach (DataRow row3 in this.GetColumnList(null, TableName).Select("ColumnName='" + str3 + "'"))
                    {
                        string str4 = row3["TypeName"].ToString();
                        row2["TypeName"] = str4;
                    }
                    table.Rows.Add(row2);
                    num++;
                }
            }
            return table;
        }

        public void OpenDB()
        {
            try
            {
                if (this.connect.ConnectionString == "")
                {
                    this.connect.ConnectionString = this._dbconnectStr;
                }
                if (this.connect.ConnectionString != this._dbconnectStr)
                {
                    this.connect.Close();
                    this.connect.ConnectionString = this._dbconnectStr;
                }
                if (this.connect.State == ConnectionState.Closed)
                {
                    this.connect.Open();
                }
            }
            catch
            {
            }
        }

        public DataSet Query(string DbName, string SQLString)
        {
            DataSet dataSet = new DataSet();
            try
            {
                this.OpenDB();
                new OleDbDataAdapter(SQLString, this.connect).Fill(dataSet, "ds");
            }
            catch (OleDbException exception)
            {
                throw new Exception(exception.Message);
            }
            return dataSet;
        }

        public bool RenameTable(string DbName, string OldName, string NewName)
        {
            return false;
        }

        private DataTable Tab2Colum(DataTable sTable)
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
            int num = 0;
            DataRow[] drs = sTable.Select("", "ORDINAL_POSITION asc");
            foreach (DataRow row in drs)
            {
                DataRow row2 = table.NewRow();
                row2["colorder"] = row[6].ToString();
                row2["ColumnName"] = row[3].ToString();
                string str = row[11].ToString();
                string str2 = row[11].ToString();
                if (str2 != null)
                {
                    if (str2 == "3" || str2 == "2")
                    {
                        str = "int";

                    }
                    else
                    {
                        if (str2 == "5")
                        {
                            goto Label_019B;
                        }
                        if (str2 == "6")
                        {
                            goto Label_01A4;
                        }
                        if (str2 == "7")
                        {
                            goto Label_01AD;
                        }
                        if (str2 == "11")
                        {
                            goto Label_01B6;
                        }
                        if (str2 == "130")
                        {
                            goto Label_01BF;
                        }
                        if (str2 == "131")
                        {
                            str = "float";
                        }
                        if (str2 == "4")
                        {
                            str = "single";
                        }
                    }
                }
                goto Label_01C6;
            Label_019B:
                str = "double";
                goto Label_01C6;
            Label_01A4:
                str = "money";
                goto Label_01C6;
            Label_01AD:
                str = "datetime";
                goto Label_01C6;
            Label_01B6:
                str = "bool";
                goto Label_01C6;
            Label_01BF:
                str = "varchar";
            Label_01C6:
                row2["TypeName"] = str;
                row2["Length"] = row[13].ToString();
                row2["Preci"] = row[15].ToString();
                row2["Scale"] = row[0x10].ToString();
                if (str2 == "3" &&  Convert.ToByte(row["COLUMN_FLAGS"]) == 90)
                    row2["IsIdentity"] = "√";
                else
                    row2["IsIdentity"] = "";
                row2["isPK"] = "";
                if (row[10].ToString().ToLower() == "true")
                {
                    row2["cisNull"] = "√";
                }
                else
                {
                    row2["cisNull"] = "";
                }
                row2["defaultVal"] = row[8].ToString();
                row2["deText"] = "";
                table.Rows.Add(row2);
                num++;
            }
            return table;
        }

        private DataTable Tab2Tab(DataTable sTable)
        {
            DataTable table = new DataTable();
            table.Columns.Add("name");
            table.Columns.Add("cuser");
            table.Columns.Add("type");
            table.Columns.Add("dates");
            foreach (DataRow row in sTable.Rows)
            {
                DataRow row2 = table.NewRow();
                row2["name"] = row[2].ToString();
                row2["cuser"] = "dbo";
                row2["type"] = row[3].ToString();
                row2["dates"] = row[6].ToString();
                table.Rows.Add(row2);
            }
            return table;
        }

        public string DbConnectStr
        {
            get
            {
                return this._dbconnectStr;
            }
            set
            {
                this._dbconnectStr = value;
            }
        }

        public string DbType
        {
            get
            {
                return "OleDb";
            }
        }
    }
}

