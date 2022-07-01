using Common.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IDatabaseConfig _databaseConfig;
        public DapperRepository(IDatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        private SqlConnection Context
        {
            get
            {
                var cn = new SqlConnection(_databaseConfig.ConnectionString);
                cn.Open();
                return cn;
            }
        }

        public SqlConnection GetContext { get { return Context; } }
    }
}
