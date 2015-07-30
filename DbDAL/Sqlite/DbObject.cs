namespace Hxj.DbObjects.SQLite
{

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SQLite;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using Hxj.Tools.EntityDesign.Model;
    using Hxj.IDBO;

    public class DbObject : IDbObject
    {
        private string _dbconnectStr;
        //private INIFile cfgfile;
        private string cmcfgfile;
        private SQLiteConnection connect;
        private bool isdbosp = false;

        public DbObject()
        {
            //this.cmcfgfile = Application.StartupPath + @"\cmcfg.ini";
            this.connect = new SQLiteConnection();
            this.IsDboSp();
        }

        public DbObject(string DbConnectStr)
        {
            //this.cmcfgfile = Application.StartupPath + @"\cmcfg.ini";
            this.connect = new SQLiteConnection();
            this._dbconnectStr = DbConnectStr;
            this.connect.ConnectionString = DbConnectStr;
        }

        public DbObject(bool SSPI, string Ip, string User, string Pass)
        {
            //this.cmcfgfile = Application.StartupPath + @"\cmcfg.ini";
            this.connect = new SQLiteConnection();
            this.connect = new SQLiteConnection();
            if (SSPI)
            {
                this._dbconnectStr = string.Format("Data Source={0}; Password={1}", Ip, Pass);
            }
            else
            {
                this._dbconnectStr = string.Format("Data Source={0};Password={1}", Ip, Pass);
            }
            this.connect.ConnectionString = this._dbconnectStr;
        }

        private SQLiteCommand BuildQueryCommand(SQLiteConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SQLiteCommand command = new SQLiteCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SQLiteParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    if (((parameter.Direction == ParameterDirection.InputOutput) || (parameter.Direction == ParameterDirection.Input)) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }

        private int CompareStrByOrder(string x, string y)
        {
            if (x == "")
            {
                if (y == "")
                {
                    return 0;
                }
                return -1;
            }
            if (y == "")
            {
                return 1;
            }
            return x.CompareTo(y);
        }

        public DataTable CreateColumnTable()
        {
            DataTable table = new DataTable();
            DataColumn column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "colorder";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ColumnName";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "TypeName";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Length";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Preci";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Scale";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "IsIdentity";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "isPK";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "cisNull";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "defaultVal";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "deText";
            table.Columns.Add(column);
            return table;
        }

        public bool DeleteTable(string DbName, string TableName)
        {
            try
            {
                SQLiteCommand command = this.OpenDB(DbName);
                command.CommandText = "DROP TABLE " + TableName;
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public SQLiteDataReader ExecuteReader(string DbName, string strSQL)
        {
            SQLiteDataReader reader2;
            try
            {
                this.OpenDB(DbName);
                reader2 = new SQLiteCommand(strSQL, this.connect).ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SQLiteException exception)
            {
                throw exception;
            }
            return reader2;
        }

        public int ExecuteSql(string DbName, string SQLString)
        {
            SQLiteCommand command = this.OpenDB(DbName);
            command.CommandText = SQLString;
            return command.ExecuteNonQuery();
        }

        public DataTable GetColumnInfoList(string DbName, string TableName)
        {
            DataTable table = CreateColumnTable();
            this.OpenDB(DbName);
            DataRow[] columns = connect.GetSchema("COLUMNS").Select("TABLE_NAME='" + TableName + "'");

            foreach (DataRow dr in columns)
            {
                DataRow newrow = table.NewRow();

                newrow["colorder"] = dr["ORDINAL_POSITION"];
                newrow["ColumnName"] = dr["COLUMN_NAME"];
                newrow["Length"] = dr["CHARACTER_MAXIMUM_LENGTH"];
                newrow["Preci"] = dr["NUMERIC_PRECISION"];
                newrow["Scale"] = dr["NUMERIC_SCALE"];
                newrow["isPK"] = dr["PRIMARY_KEY"].ToString().ToLower() == "true" ? "√" : "";
                newrow["cisNull"] = dr["IS_NULLABLE"].ToString().ToLower() == "true" ? "√" : "";
                newrow["defaultVal"] = dr["COLUMN_DEFAULT"];

                newrow["TypeName"] = dr["DATA_TYPE"];
                if (newrow["isPK"].ToString() == "√" && string.Compare(newrow["TypeName"].ToString(), "integer", true) == 0)
                    newrow["IsIdentity"] = "√";

                table.Rows.Add(newrow);

            }



            return table;
        }

        public DataTable GetColumnInfoListSP(string DbName, string TableName)
        {
            return null;
        }

        public DataTable GetColumnList(string DbName, string TableName)
        {
            return this.GetColumnInfoList(DbName, TableName);
        }

        public DataTable GetColumnListSP(string DbName, string TableName)
        {
            return this.GetColumnInfoList(DbName, TableName);
        }

        public DataTable GetDBList()
        {
            return null;
        }

        public DataTable GetKeyName(string DbName, string TableName)
        {
            DataTable table = this.CreateColumnTable();
            DataRow[] columnsKeys = this.GetColumnInfoList(DbName, TableName).Select(" isPK='√' or IsIdentity='√' ");
            foreach (DataRow row in columnsKeys)
            {
                DataRow row2 = table.NewRow();
                row2["colorder"] = row["colorder"];
                row2["ColumnName"] = row["ColumnName"];
                row2["TypeName"] = row["TypeName"];
                row2["Length"] = row["Length"];
                row2["Preci"] = row["Preci"];
                row2["Scale"] = row["Scale"];
                row2["IsIdentity"] = row["IsIdentity"];
                row2["isPK"] = row["isPK"];
                row2["cisNull"] = row["cisNull"];
                row2["defaultVal"] = row["defaultVal"];
                row2["deText"] = row["deText"];
                table.Rows.Add(row2);
            }
            return table;
        }

        public string GetObjectInfo(string DbName, string objName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select sql ");
            builder.Append("from sqlite_master   ");
            builder.Append("where name= '" + objName + "'");
            return this.GetSingle(DbName, builder.ToString()).ToString();
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
                SQLiteCommand command = this.OpenDB(DbName);
                command.CommandText = SQLString;
                object objA = command.ExecuteScalar();
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

        public DataTable GetTabData(string DbName, string TableName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from " + TableName);
            return this.Query(DbName, builder.ToString()).Tables[0];
        }

        public DataTable GetTabData(string DbName, string TableName, int TopNum)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from [" + TableName + "]");
            if (TopNum > 0) builder.Append(" limit " + TopNum.ToString());
            return this.Query(DbName, builder.ToString()).Tables[0];
        }

        public DataTable GetTabDataBySQL(string DbName, string strSQL)
        {
            return this.Query(DbName, strSQL).Tables[0];
        }

        public DataTable GetTables(string DbName)
        {
            string strSQL = "select name from sqlite_master where type='table'  AND name NOT LIKE 'sqlite_%' order by name";

            return Query(DbName, strSQL).Tables[0];


        }

        //public string GetTableScript(string DbName, string TableName)
        //{
        //    string str = "";
        //    string strSQL = "SHOW CREATE TABLE " + TableName;
        //    SQLiteDataReader reader = this.ExecuteReader(DbName, strSQL);
        //    while (reader.Read())
        //    {
        //        str = reader.GetString(1);
        //    }
        //    reader.Close();
        //    return str;
        //}

        public DataTable GetTablesInfo(string DbName)
        {
            string strSQL = "select * from sqlite_master where type='table' order by name  AND name NOT LIKE 'sqlite_%'";
            return Query(DbName, strSQL).Tables[0];

        }

        public DataTable GetTablesSP(string DbName)
        {
            return GetTables(DbName);
            //SQLiteParameter[] parameters = new SQLiteParameter[] { new SQLiteParameter("@table_name", System.Data.DbType.String, 0x180), new SQLiteParameter("@table_owner", System.Data.DbType.String, 0x180), new SQLiteParameter("@table_qualifier", System.Data.DbType.String, 0x180), new SQLiteParameter("@table_type", System.Data.DbType.String, 100) };
            //parameters[0].Value = null;
            //parameters[1].Value = null;
            //parameters[2].Value = null;
            //parameters[3].Value = "'TABLE'";
            //DataSet set = this.RunProcedure(DbName, "sp_tables", parameters, "ds");
            //if (set.Tables.Count > 0)
            //{
            //    DataTable table = set.Tables[0];
            //    table.Columns["TABLE_QUALIFIER"].ColumnName = "db";
            //    table.Columns["TABLE_OWNER"].ColumnName = "cuser";
            //    table.Columns["TABLE_NAME"].ColumnName = "name";
            //    table.Columns["TABLE_TYPE"].ColumnName = "type";
            //    table.Columns["REMARKS"].ColumnName = "remarks";
            //    return table;
            //}
            //return null;
        }

        public DataTable GetTabViews(string DbName)
        {
            string sQLString = "select name from sqlite_master WHERE type IN ('table','view') AND name NOT LIKE 'sqlite_%' order by name";
            DataTable table = this.Query(DbName, sQLString).Tables[0];
            table.Columns[0].ColumnName = "name";
            return table;
        }

        public DataTable GetTabViewsInfo(string DbName)
        {
            string strSQL = "select * from sqlite_master WHERE type IN ('table','view') AND name NOT LIKE 'sqlite_%' order by name";
            return this.Query(DbName, strSQL).Tables[0];

        }

        public DataTable GetTabViewsSP(string DbName)
        {
            return null;
        }

        public string GetVersion()
        {
            try
            {
                string sQLString = "execute master..sp_msgetversion ";
                return this.Query("master", sQLString).Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }

        public DataTable GetVIEWs(string DbName)
        {
            string strSQL = "select [name] from sqlite_master WHERE type='view' AND name NOT LIKE 'sqlite_%' order by name";
            return this.Query(DbName, strSQL).Tables[0];
        }

        public DataTable GetVIEWsInfo(string DbName)
        {
            string strSQL = "select * from sqlite_master WHERE type='view' AND name NOT LIKE 'sqlite_%' order by name";
            return this.Query(DbName, strSQL).Tables[0];
        }

        public DataTable GetVIEWsSP(string DbName)
        {
            SQLiteParameter[] parameters = new SQLiteParameter[] { new SQLiteParameter("@table_name", System.Data.DbType.String, 0x180), new SQLiteParameter("@table_owner", System.Data.DbType.String, 0x180), new SQLiteParameter("@table_qualifier", System.Data.DbType.String, 0x180), new SQLiteParameter("@table_type", System.Data.DbType.String, 100) };
            parameters[0].Value = null;
            parameters[1].Value = null;
            parameters[2].Value = null;
            parameters[3].Value = "'VIEW'";
            DataSet set = this.RunProcedure(DbName, "sp_tables", parameters, "ds");
            if (set.Tables.Count > 0)
            {
                DataTable table = set.Tables[0];
                table.Columns["TABLE_QUALIFIER"].ColumnName = "db";
                table.Columns["TABLE_OWNER"].ColumnName = "cuser";
                table.Columns["TABLE_NAME"].ColumnName = "name";
                table.Columns["TABLE_TYPE"].ColumnName = "type";
                table.Columns["REMARKS"].ColumnName = "remarks";
                return table;
            }
            return null;
        }

        private bool IsDboSp()
        {
            return false;
        }

        private SQLiteCommand OpenDB(string DbName)
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
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = (this.connect);
                if (this.connect.State == ConnectionState.Closed)
                {
                    this.connect.Open();
                }
                return command;
            }
            catch (Exception exception)
            {
                string message = exception.Message;
                return null;
            }
        }

        public DataSet Query(string DbName, string SQLString)
        {
            DataSet dataSet = new DataSet();
            try
            {
                this.OpenDB(DbName);
                new SQLiteDataAdapter(SQLString, this.connect).Fill(dataSet, "ds");
            }
            catch (SQLiteException exception)
            {
                throw new Exception(exception.Message);
            }
            return dataSet;
        }

        public bool RenameTable(string DbName, string OldName, string NewName)
        {
            try
            {
                SQLiteCommand command = this.OpenDB(DbName);
                command.CommandText = "RENAME TABLE " + OldName + " TO " + NewName;
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataSet RunProcedure(string DbName, string storedProcName, IDataParameter[] parameters, string tableName)
        {
            this.OpenDB(DbName);
            DataSet dataSet = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            adapter.SelectCommand = (this.BuildQueryCommand(this.connect, storedProcName, parameters));
            adapter.Fill(dataSet, tableName);
            return dataSet;
        }

        private void TypeNameProcess(string strName, out string TypeName, out string Length, out string Preci, out string Scale)
        {
            TypeName = strName;
            int index = strName.IndexOf("(");
            Length = "";
            Preci = "";
            Scale = "";
            if (index > 0)
            {
                TypeName = strName.Substring(0, index);
                switch (TypeName.Trim().ToUpper())
                {
                    case "TINYINT":
                    case "SMALLINT":
                    case "MEDIUMINT":
                    case "INT":
                    case "INTEGER":
                    case "BIGINT":
                    case "TIMESTAMP":
                    case "CHAR":
                    case "VARCHAR":
                        {
                            int num2 = strName.IndexOf(")");
                            Length = strName.Substring(index + 1, (num2 - index) - 1);
                            return;
                        }
                    case "FLOAT":
                    case "DOUBLE":
                    case "REAL":
                    case "DECIMAL":
                    case "DEC":
                    case "NUMERIC":
                        {
                            int num3 = strName.IndexOf(")");
                            string str = strName.Substring(index + 1, (num3 - index) - 1);
                            int length = str.IndexOf(",");
                            Length = str.Substring(0, length);
                            Scale = str.Substring(length + 1);
                            return;
                        }
                    case "ENUM":
                    case "SET":
                        return;
                }
            }
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
                return "SQLite";
            }
        }
    }
}

