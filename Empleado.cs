using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Distribuidora
{
    public partial class Empleado : Form
    {
        public Empleado()
        {
            InitializeComponent();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            try
            {
                SqlClass obj_sql = new SqlClass();
                DataSet obj_dataset = new DataSet();
                
                obj_sql.adapter(
                    "SELECT e.id_empleado AS ID, e.nombre AS NOMBRE, e.apellido AS APELLIDO, e.email AS CORREO, "+
                    "e.telefono AS TELEFONO, t.tipo AS CARGO FROM empleados e "+
                    "INNER JOIN tipo_empleados t ON e.id_tipo_empleado=t.id_tipo_empleado;",
                    obj_sql.conexion()
                    ).Fill(obj_dataset);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = obj_dataset.Tables[0];
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            NuevoEmpleado form = new NuevoEmpleado();
            form.Show();
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
