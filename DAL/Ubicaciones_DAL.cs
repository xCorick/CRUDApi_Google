using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BLL;
using System.Threading.Tasks;

namespace DAL
{
    public class Ubicaciones_DAL
    {
        SQLDBHelper oConexion;
        //inicializar la conexion a la DB con el constructor
        public Ubicaciones_DAL() 
        {
            oConexion = new SQLDBHelper();
        }
        public bool Agregar(Ubicaciones_BLL oUbicacionesBLL) 
        {
            SqlCommand cmdCommand = new SqlCommand();
            cmdCommand.CommandText = "insert into Direcciones(Ubicacion, Latitud, Longitud) values(@Ubicacion, @Latitud, @Longitud)";
            cmdCommand.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = oUbicacionesBLL.ubicacion;
            cmdCommand.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = oUbicacionesBLL.latitud;
            cmdCommand.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = oUbicacionesBLL.longitud;
            
            return oConexion.EjecutarComandoSQL(cmdCommand).Rows.Count > 1 ? true:false;
        }
        public bool Eliminar(Ubicaciones_BLL oUbicacionesBLL) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Direcciones where ID = @ID";
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = oUbicacionesBLL.ID;

            int row = oConexion.EjecutarComandoSQLNonQuery(cmd);

            return row > 0 ? true:false;
        }
        public bool Modificar(Ubicaciones_BLL oUbicacionesBLL) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateUbicacion";
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = oUbicacionesBLL.ID;
            cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = oUbicacionesBLL.ubicacion;
            cmd.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = oUbicacionesBLL.latitud;
            cmd.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = oUbicacionesBLL.longitud;

            int row = oConexion.EjecutarComandoSQLNonQuery(cmd);

            return row > 0 ? true:false;
        }
        //seleccionar los registros de la tabla por select
        public DataTable Listar()
        {
            SqlCommand cmdCommand = new SqlCommand();
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandText = "Lst_Direcciones";
            DataTable TablaResultado = oConexion.EjecutarComandoSQL(cmdCommand);
            return TablaResultado;
        }
    }
}
