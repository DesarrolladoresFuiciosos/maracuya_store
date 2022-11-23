using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Dal
{
    public class Dapper
    {

        public string Conexion;

        public Tresponse SingleQuery<Trequest, Tresponse>(string procedure, Trequest parameters)
        {
            using (IDbConnection db = new SqlConnection(Conexion))
            {
                return db.Query<Tresponse>(procedure, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Tresponse SingleQuery<Tresponse>(string procedure)
        {
            using (IDbConnection db = new SqlConnection(Conexion))
            {
                return db.Query<Tresponse>(procedure, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Tresponse> ListQuery<Trequest, Tresponse>(string procedure, Trequest parameters)
        {
            using (IDbConnection db = new SqlConnection(Conexion))
            {
                return db.Query<Tresponse>(procedure, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Tresponse> ListQuery<Tresponse>(string procedure)
        {
            using (IDbConnection db = new SqlConnection(Conexion))
            {
                return db.Query<Tresponse>(procedure, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void ExecuteQuery<T>(string procedure, T parameter)
        {
            using (IDbConnection db = new SqlConnection(Conexion))
            {
                db.Execute(procedure, parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }

}
