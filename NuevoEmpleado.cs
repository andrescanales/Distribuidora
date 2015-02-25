using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Distribuidora
{
    public partial class NuevoEmpleado : Form
    {
        public NuevoEmpleado()
        {
            InitializeComponent();
        }

        private void NuevoEmpleado_Load(object sender, EventArgs e)
        {
            SqlClass obj_sql = new SqlClass();
            SqlCommand resultado;

            // 1. Traemos el último id disponible de la tabla Clientes
            try
            {
                resultado = obj_sql.sqlquery(
                    "SELECT MAX(id_empleado + 1) FROM empleados",
                    obj_sql.conexion()
                    );

                txt_id.Text = resultado.ExecuteScalar().ToString();
                txt_id.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
