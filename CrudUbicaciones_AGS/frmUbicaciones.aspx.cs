using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace CrudUbicaciones_AGS
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        Ubicaciones_BLL oUbicacionesBLL;
        Ubicaciones_DAL oUbicacionesDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarUbicaciones();
            }
        }
        
        public void ListarUbicaciones()
        {
            oUbicacionesDAL = new Ubicaciones_DAL();
            gvUbicaciones.DataSource = oUbicacionesDAL.Listar();
            gvUbicaciones.DataBind();
        }

        public Ubicaciones_BLL DatosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new Ubicaciones_BLL();
            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.latitud = txtLat.Text;
            oUbicacionesBLL.longitud = txtLong.Text;
            return oUbicacionesBLL;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new Ubicaciones_DAL();
            oUbicacionesDAL.Agregar(DatosUbicacion());
            ListarUbicaciones();
        }

        protected void gvUbicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Value = gvUbicaciones.Rows[gvUbicaciones.SelectedRow.RowIndex].Cells[1].Text;
            txtUbicacion.Text = gvUbicaciones.Rows[gvUbicaciones.SelectedRow.RowIndex].Cells[2].Text;
            txtLat.Text = gvUbicaciones.Rows[gvUbicaciones.SelectedRow.RowIndex].Cells[3].Text;
            txtLong.Text = gvUbicaciones.Rows[gvUbicaciones.SelectedRow.RowIndex].Cells[4].Text;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUbicacion.Text = string.Empty;
            txtLat.Text = string.Empty;
            txtLong.Text = string.Empty;
            txtID.Value = null;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new Ubicaciones_DAL();
            oUbicacionesDAL.Modificar(DatosUbicacion());
            ListarUbicaciones();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new Ubicaciones_DAL();
            oUbicacionesDAL.Eliminar(DatosUbicacion());
            ListarUbicaciones();
        }
    }
}