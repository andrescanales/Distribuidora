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

            // 1. Traemos el último id disponible de la tabla Empleados
            try
            {
                resultado = obj_sql.sqlquery(
                    "SELECT MAX(id_empleado + 1) FROM empleados",
                    obj_sql.conexion()
                    );

                string id = resultado.ExecuteScalar().ToString();
                if (id == "") {
                    txt_id.Text = "1";
                    txt_id.Enabled = false;
                }
                else { 
                    txt_id.Text = id;
                    txt_id.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // 2. Luego traemos todos los tipos de empelados para mostrarlos en el combobox
            try
            {
                DataSet dataset = new DataSet();
                        
                SqlDataAdapter adapter = obj_sql.adapter(
                   "SELECT id_tipo_empleado AS id, tipo AS tipo FROM tipo_empleados",
                    obj_sql.conexion()
                    );
                
                adapter.Fill(dataset);
                adapter.Dispose();
                
                combo_tipoemp.DataSource = dataset.Tables[0];
                combo_tipoemp.ValueMember = "id";
                combo_tipoemp.DisplayMember = "tipo";
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

        private void btn_guardar_Click(object sender, EventArgs e)
        {     
            SqlClass obj_sql = new SqlClass();
            SqlCommand resultado;
            
            if(txt_nombre.Text.Length == 0){
                MessageBox.Show("No puedes dejar el Nombre vacío!");
            }
            else if (txt_apellido.Text.Length == 0)
            {
                MessageBox.Show("No puedes dejar el Apellido vacío!");
            }
            else if (combo_tipoemp.Text.Length == 0)
            {
                MessageBox.Show("Selecciona un Tipo de Empleado");
            }
            else
            {
                try
                {
                    resultado = obj_sql.sqlquery(
                    "INSERT INTO empleados(id_empleado, nombre, apellido, direccion, fecha_nacimiento,"
                    +"email, telefono, id_tipo_empleado) VALUES('"
                    + Int32.Parse(txt_id.Text) + "','"
                    + txt_nombre.Text + "','"
                    + txt_apellido.Text + "','"
                    + txt_direccion.Text + "','"
                    + txt_fecha.Text + "','"
                    + txt_email.Text + "','"
                    + txt_telefono.Text + "','"
                    + combo_tipoemp.SelectedValue + "')",
                    obj_sql.conexion()
                    );

                    int rows = resultado.ExecuteNonQuery();
                    // Verificamos si el ExecuteNonQuery devuelve columnas afectadas 
                    if (rows == 0)
                    {
                        MessageBox.Show("Opps, algo ocurrió mal. Intentalo más tarde.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El registro fue agregado!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
