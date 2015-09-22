namespace Hxj.DbObjects.SQL2005
{
    using Hxj.IDBO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public class DbObject : IDbObject
    {
        private string _dbconnectStr;
        private SqlConnection connect;
        private bool isdbosp = false;

        public DbObject()
        {
            this.connect = new SqlConnection();
            this.IsDboSp();
        }

        public DbObject(string DbConnectStr)
        {
            this.connect = new SqlConnection();
            this._dbconnectStr = DbConnectStr;
            this.connect.ConnectionString = DbConnectStr;
        }

        public DbObject(bool SSPI, string Ip, string User, string Pass)
        {
            this.connect = new SqlConnection();
            if (SSPI)
            {
                this._dbconnectStr = "Integrated Security=SSPI;Data Source=" + Ip + ";Initial Catalog=master";
            }
            else if (Pass == "")
            {
                this._dbconnectStr = "user id=" + User + ";initial catalog=master;data source=" + Ip + ";Connect Timeout=30";
            }
            else
            {
                this._dbconnectStr = "user id=" + User + ";password=" + Pass + ";initial catalog=master;data source=" + Ip + ";Connect Timeout=30";
            }
            this.connect.ConnectionString = this._dbconnectStr;
        }

        private SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
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

        public DataTable CreateColumnTable()
        {
            DataTable table = new DataTable();
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "colorder";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ColumnName";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "TypeName";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Length";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Preci";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Scale";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "IsIdentity";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "isPK";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "cisNull";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "defaultVal";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "deText";
            table.Columns.Add(column);
            return table;
        }

        public bool DeleteTable(string DbName, string TableName)
        {
            try
            {
                SqlCommand command = this.OpenDB(DbName);
                command.CommandText = "DROP TABLE [" + TableName + "]";
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int ExecuteSql(string DbName, string SQLString)
        {
            SqlCommand command = this.OpenDB(DbName);
            command.CommandText = SQLString;
            return command.ExecuteNonQuery();
        }

        public DataTable GetColumnInfoList(string DbName, string TableName)
        {
            if (this.isdbosp)
            {
                return this.GetColumnInfoListSP(DbName, TableName);
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT distinct * from (select ");
            builder.Append("colorder=C.column_id,");
            builder.Append("ColumnName=C.name,");

            builder.Append("deText=ISNULL(PFD.[value],N''),");
            builder.Append("TypeName=T.name, ");
            builder.Append("Length=C.max_length, ");
            builder.Append("Preci=C.precision, ");
            builder.Append("Scale=C.scale, ");
            builder.Append("IsIdentity=CASE WHEN C.is_identity=1 THEN N'√'ELSE N'' END,");
            builder.Append("isPK=ISNULL(IDX.PrimaryKey,N''),");
            builder.Append("Computed=CASE WHEN C.is_computed=1 THEN N'√'ELSE N'' END, ");
            builder.Append("IndexName=ISNULL(IDX.IndexName,N''), ");
            builder.Append("IndexSort=ISNULL(IDX.Sort,N''), ");
            builder.Append("Create_Date=O.Create_Date, ");
            builder.Append("Modify_Date=O.Modify_date, ");
            builder.Append("cisNull=CASE WHEN C.is_nullable=1 THEN N'√'ELSE N'' END, ");
            builder.Append("defaultVal=ISNULL(D.definition,N'') ");
            
            builder.Append("FROM sys.columns C ");
            builder.Append("INNER JOIN sys.objects O ");
            builder.Append("ON C.[object_id]=O.[object_id] ");
            builder.Append("AND (O.type='U' or O.type='V') ");
            builder.Append("AND O.is_ms_shipped=0 ");
            builder.Append("INNER JOIN sys.types T ");
            builder.Append("ON C.user_type_id=T.user_type_id ");
            builder.Append("LEFT JOIN sys.default_constraints D ");
            builder.Append("ON C.[object_id]=D.parent_object_id ");
            builder.Append("AND C.column_id=D.parent_column_id ");
            builder.Append("AND C.default_object_id=D.[object_id] ");
            builder.Append("LEFT JOIN sys.extended_properties PFD ");
            builder.Append("ON PFD.class=1  ");
            builder.Append("AND C.[object_id]=PFD.major_id  ");
            builder.Append("AND C.column_id=PFD.minor_id ");
            builder.Append("LEFT JOIN sys.extended_properties PTB ");
            builder.Append("ON PTB.class=1 ");
            builder.Append("AND PTB.minor_id=0  ");
            builder.Append("AND C.[object_id]=PTB.major_id ");
            builder.Append("LEFT JOIN ");
            builder.Append("( ");
            builder.Append("SELECT  ");
            builder.Append("IDXC.[object_id], ");
            builder.Append("IDXC.column_id, ");
            builder.Append("Sort=CASE INDEXKEY_PROPERTY(IDXC.[object_id],IDXC.index_id,IDXC.index_column_id,'IsDescending') ");
            builder.Append("WHEN 1 THEN 'DESC' WHEN 0 THEN 'ASC' ELSE '' END, ");
            builder.Append("PrimaryKey=CASE WHEN IDX.is_primary_key=1 THEN N'√'ELSE N'' END, ");
            builder.Append("IndexName=IDX.Name ");
            builder.Append("FROM sys.indexes IDX ");
            builder.Append("INNER JOIN sys.index_columns IDXC ");
            builder.Append("ON IDX.[object_id]=IDXC.[object_id] ");
            builder.Append("AND IDX.index_id=IDXC.index_id ");
            builder.Append("LEFT JOIN sys.key_constraints KC ");
            builder.Append("ON IDX.[object_id]=KC.[parent_object_id] ");
            builder.Append("AND IDX.index_id=KC.unique_index_id ");
            builder.Append("INNER JOIN  ");
            builder.Append("( ");
            builder.Append("SELECT [object_id], Column_id, index_id=MIN(index_id) ");
            builder.Append("FROM sys.index_columns ");
            builder.Append("GROUP BY [object_id], Column_id ");
            builder.Append(") IDXCUQ ");
            builder.Append("ON IDXC.[object_id]=IDXCUQ.[object_id] ");
            builder.Append("AND IDXC.Column_id=IDXCUQ.Column_id ");
            builder.Append("AND IDXC.index_id=IDXCUQ.index_id ");
            builder.Append(") IDX ");
            builder.Append("ON C.[object_id]=IDX.[object_id] ");
            builder.Append("AND C.column_id=IDX.column_id  ");
            builder.Append("WHERE O.name=N'" + TableName + "' ) as t ");
            builder.Append("ORDER BY colorder,ColumnName  ");
            return this.Query(DbName, builder.ToString()).Tables[0];
        }

        public DataTable GetColumnInfoListSP(string DbName, string TableName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@table_name", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_owner", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_qualifier", SqlDbType.NVarChar, 0x180), new SqlParameter("@column_name", SqlDbType.VarChar, 100) };
            parameters[0].Value = TableName;
            parameters[1].Value = null;
            parameters[2].Value = null;
            parameters[3].Value = null;
            DataSet set = this.RunProcedure(DbName, "sp_columns", parameters, "ds");
            if (set.Tables.Count <= 0)
            {
                return null;
            }
            DataTable table = set.Tables[0];
            int count = table.Rows.Count;
            DataTable table2 = this.CreateColumnTable();
            for (int i = 0; i < count; i++)
            {
                DataRow row = table2.NewRow();
                row["colorder"] = table.Rows[i]["ORDINAL_POSITION"];
                row["ColumnName"] = table.Rows[i]["COLUMN_NAME"];
                string str = table.Rows[i]["TYPE_NAME"].ToString().Trim();
                row["TypeName"] = (str == "int identity") ? "int" : str;
                row["Length"] = table.Rows[i]["LENGTH"];
                row["Preci"] = table.Rows[i]["PRECISION"];
                row["Scale"] = table.Rows[i]["SCALE"];
                row["IsIdentity"] = (str == "int identity") ? "√" : "";
                row["isPK"] = "";
                row["cisNull"] = (table.Rows[i]["NULLABLE"].ToString().Trim() == "1") ? "√" : "";
                row["defaultVal"] = table.Rows[i]["COLUMN_DEF"];
                row["deText"] = table.Rows[i]["REMARKS"];
                table2.Rows.Add(row);
            }
            return table2;
        }

        public DataTable GetColumnList(string DbName, string TableName)
        {
            try
            {
                if (this.isdbosp)
                {
                    return this.GetColumnListSP(DbName, TableName);
                }
                StringBuilder builder = new StringBuilder();
                builder.Append("Select ");
                builder.Append("a.colorder as colorder,");
                builder.Append("a.name as ColumnName,");
                builder.Append("b.name as TypeName ");
                builder.Append(" from syscolumns a, systypes b, sysobjects c ");
                builder.Append(" where a.xtype = b.xusertype ");
                builder.Append("and a.id = c.id ");
                builder.Append("and c.name ='" + TableName + "'");
                builder.Append(" order by a.colorder");
                return this.Query(DbName, builder.ToString()).Tables[0];
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetColumnListSP(string DbName, string TableName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@table_name", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_owner", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_qualifier", SqlDbType.NVarChar, 0x180), new SqlParameter("@column_name", SqlDbType.VarChar, 100) };
            parameters[0].Value = TableName;
            parameters[1].Value = null;
            parameters[2].Value = null;
            parameters[3].Value = null;
            DataSet set = this.RunProcedure(DbName, "sp_columns", parameters, "ds");
            if (set.Tables.Count <= 0)
            {
                return null;
            }
            DataTable table = set.Tables[0];
            int count = table.Rows.Count;
            DataTable table2 = this.CreateColumnTable();
            for (int i = 0; i < count; i++)
            {
                DataRow row = table2.NewRow();
                row["colorder"] = table.Rows[i]["ORDINAL_POSITION"];
                row["ColumnName"] = table.Rows[i]["COLUMN_NAME"];
                string str = table.Rows[i]["TYPE_NAME"].ToString().Trim();
                row["TypeName"] = (str == "int identity") ? "int" : str;
                row["Length"] = table.Rows[i]["LENGTH"];
                row["Preci"] = table.Rows[i]["PRECISION"];
                row["Scale"] = table.Rows[i]["SCALE"];
                row["IsIdentity"] = (str == "int identity") ? "√" : "";
                row["isPK"] = "";
                row["cisNull"] = (table.Rows[i]["NULLABLE"].ToString().Trim() == "1") ? "√" : "";
                row["defaultVal"] = table.Rows[i]["COLUMN_DEF"];
                row["deText"] = table.Rows[i]["REMARKS"];
                table2.Rows.Add(row);
            }
            return table2;
        }

        public DataTable GetDBList()
        {
            string sQLString = "select name,user_name() cuser,'DB' type,crdate dates from sysdatabases";
            return this.Query("master", sQLString).Tables[0];
        }

        public DataTable GetKeyName(string DbName, string TableName)
        {
            DataTable table = this.CreateColumnTable();
            foreach (DataRow row in this.GetColumnInfoList(DbName, TableName).Select(" isPK='√' or IsIdentity='√' "))
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
            builder.Append("select b.text ");
            builder.Append("from sysobjects a, syscomments b  ");
            builder.Append("where a.xtype='p' and a.id = b.id  ");
            builder.Append(" and a.name= '" + objName + "'");
            return this.GetSingle(DbName, builder.ToString()).ToString();
        }

        public DataTable GetProcInfo(string DbName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select sysobjects.[name] name,sysusers.name cuser,");
            builder.Append("sysobjects.xtype type,sysobjects.crdate dates ");
            builder.Append("from sysobjects,sysusers ");
            builder.Append("where sysusers.uid=sysobjects.uid ");
            builder.Append("and sysobjects.xtype='P' ");
            builder.Append("order by sysobjects.id");
            return this.Query(DbName, builder.ToString()).Tables[0];
        }

        public DataTable GetProcs(string DbName)
        {
            string sQLString = "select [name] from sysobjects where xtype='P'and [name]<>'dtproperties' order by [name]";
            return this.Query(DbName, sQLString).Tables[0];
        }

        public object GetSingle(string DbName, string SQLString)
        {
            try
            {
                SqlCommand command = this.OpenDB(DbName);
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

        public DataTable GetTabData(string DbName, string TableName, int TopNum)
        {
            StringBuilder builder = new StringBuilder();
            string s = "";
            if (TopNum > 0) { s = " top " + TopNum.ToString() + " "; }
            builder.Append("select" + s + " * from [" + TableName + "]");
            return this.Query(DbName, builder.ToString()).Tables[0];
        }

        public DataTable GetTables(string DbName)
        {
            if (this.isdbosp)
            {
                return this.GetTablesSP(DbName);
            }
            string sQLString = "select [name] from sysobjects where xtype='U'and [name]<>'dtproperties' order by [name]";
            return this.Query(DbName, sQLString).Tables[0];
        }

        public DataTable GetTablesInfo(string DbName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select sysobjects.[name] name,sysusers.name cuser,");
            builder.Append("sysobjects.xtype type,sysobjects.crdate dates ");
            builder.Append("from sysobjects,sysusers ");
            builder.Append("where sysusers.uid=sysobjects.uid ");
            builder.Append("and sysobjects.xtype='U' ");
            builder.Append("and  sysobjects.[name]<>'dtproperties' ");
            builder.Append("order by sysobjects.id");
            return this.Query(DbName, builder.ToString()).Tables[0];
        }

        public DataTable GetTablesSP(string DbName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@table_name", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_owner", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_qualifier", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_type", SqlDbType.VarChar, 100) };
            parameters[0].Value = null;
            parameters[1].Value = null;
            parameters[2].Value = null;
            parameters[3].Value = "'TABLE'";
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

        public DataTable GetTabViews(string DbName)
        {
            if (this.isdbosp)
            {
                return this.GetTabViewsSP(DbName);
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("select [name],sysobjects.xtype type from sysobjects ");
            builder.Append("where (xtype='U' or xtype='V' or xtype='P') ");
            builder.Append("and [name]<>'dtproperties' and [name]<>'syssegments' and [name]<>'sysconstraints' ");
            builder.Append("order by xtype,[name]");
            return this.Query(DbName, builder.ToString()).Tables[0];
        }

        public DataTable GetTabViewsInfo(string DbName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select sysobjects.[name] name,sysusers.name cuser,");
            builder.Append("sysobjects.xtype type,sysobjects.crdate dates ");
            builder.Append("from sysobjects,sysusers ");
            builder.Append("where sysusers.uid=sysobjects.uid ");
            builder.Append("and (sysobjects.xtype='U' or sysobjects.xtype='V' or sysobjects.xtype='P') ");
            builder.Append("and sysobjects.[name]<>'dtproperties' and sysobjects.[name]<>'syssegments' and sysobjects.[name]<>'sysconstraints'  ");
            builder.Append("order by sysobjects.id");
            return this.Query(DbName, builder.ToString()).Tables[0];
        }

        public DataTable GetTabViewsSP(string DbName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@table_name", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_owner", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_qualifier", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_type", SqlDbType.VarChar, 100) };
            parameters[0].Value = null;
            parameters[1].Value = null;
            parameters[2].Value = null;
            parameters[3].Value = "'TABLE','VIEW'";
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
            if (this.isdbosp)
            {
                return this.GetVIEWsSP(DbName);
            }
            string sQLString = "select [name] from sysobjects where xtype='V' and [name]<>'syssegments' and [name]<>'sysconstraints' order by [name]";
            return this.Query(DbName, sQLString).Tables[0];
        }

        public DataTable GetVIEWsInfo(string DbName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select sysobjects.[name] name,sysusers.name cuser,");
            builder.Append("sysobjects.xtype type,sysobjects.crdate dates ");
            builder.Append("from sysobjects,sysusers ");
            builder.Append("where sysusers.uid=sysobjects.uid ");
            builder.Append("and sysobjects.xtype='V' ");
            builder.Append("and sysobjects.[name]<>'syssegments' and sysobjects.[name]<>'sysconstraints'  ");
            builder.Append("order by sysobjects.id");
            return this.Query(DbName, builder.ToString()).Tables[0];
        }

        public DataTable GetVIEWsSP(string DbName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@table_name", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_owner", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_qualifier", SqlDbType.NVarChar, 0x180), new SqlParameter("@table_type", SqlDbType.VarChar, 100) };
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
            return this.isdbosp;
        }

        private SqlCommand OpenDB(string DbName)
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
                SqlCommand command = new SqlCommand();
                command.Connection = this.connect;
                if (this.connect.State == ConnectionState.Closed)
                {
                    this.connect.Open();
                }
                command.CommandText = "use [" + DbName + "]";
                command.ExecuteNonQuery();
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
                new SqlDataAdapter(SQLString, this.connect).Fill(dataSet, "ds");
            }
            catch (SqlException exception)
            {
                throw new Exception(exception.Message + "\n" + SQLString);
            }
            return dataSet;
        }

        public bool RenameTable(string DbName, string OldName, string NewName)
        {
            try
            {
                SqlCommand command = this.OpenDB(DbName);
                command.CommandText = "EXEC sp_rename '" + OldName + "', '" + NewName + "'";
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
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = this.BuildQueryCommand(this.connect, storedProcName, parameters);
            adapter.Fill(dataSet, tableName);
            return dataSet;
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
                return "SQL2005";
            }
        }
    }
}

