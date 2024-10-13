using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SQLDBHelper
    {
        DataTable Tabla;
        SqlConnection strConexion = new SqlConnection("Data Source=CorickGS\\SQLEXPRESS;initial Catalog=DB Ubicaciones;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public DataTable EjecutarComandoSQL(SqlCommand strSQLCommand)
        {
            //pa seleccionar datos de DB

            cmd = strSQLCommand;
            cmd.Connection = strConexion;
            if (strConexion.State == 0)
            {
                strConexion.Open();
            }
            Tabla = new DataTable();
            Tabla.Load(cmd.ExecuteReader());
            strConexion.Close();

            
            return Tabla;
        }

        public int EjecutarComandoSQLNonQuery(SqlCommand strSQLCommand)
        {
            //pa seleccionar datos de DB

            cmd = strSQLCommand;
            cmd.Connection = strConexion;
            if (strConexion.State == 0)
            {
                strConexion.Open();
            }
            int rows = cmd.ExecuteNonQuery();
            strConexion.Close();


            return rows;
        }
    }
}
