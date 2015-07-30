using System;
using System.Collections.Generic;
using System.Text;

namespace Hxj.Tools.EntityDesign.Model
{
    public class Connection
    {
        private Guid id;
        public Guid ID { get { return id; } set { id = value; } }

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private string database;
        public string Database { get { return database; } set { database = value; } }

        private string dbType;
        public string DbType { get { return dbType; } set { dbType = value; } }

        private string connectionString;
        public string ConnectionString { get { return connectionString; } set { connectionString = value; } }
    }
}
