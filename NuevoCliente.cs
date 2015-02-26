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
    public partial class NuevoCliente : Form
    {
        public NuevoCliente()
        {
            InitializeComponent();
        }

        private void NuevoCliente_Load(object sender, EventArgs e)
        {        
            SqlClass obj_sql = new SqlClass();
            SqlCommand resultado;

            // 1. Traemos el último id disponible de la tabla Clientes
            try
            {
                resultado = obj_sql.sqlquery(
                    "SELECT MAX(id_cliente + 1) FROM clientes",
                    obj_sql.conexion()
                    );

                txt_id.Text = resultado.ExecuteScalar().ToString();
                txt_id.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // 2. Luego traemos todos los departamentos para mostrarlos en el combobox
            try {

                DataSet dataset = new DataSet();

                SqlDataAdapter adapter = obj_sql.adapter(
                    "SELECT id_departamento, nombre FROM departamentos",
                    obj_sql.conexion()
                    );

                adapter.Fill(dataset);
                adapter.Dispose();
                 
                combo_departamentos.DataSource = dataset.Tables[0];
                combo_departamentos.ValueMember = "id_departamento";
                combo_departamentos.DisplayMember = "nombre";
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

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
            else if (combo_departamentos.Text.Length == 0)
            {
                MessageBox.Show("Selecciona un departamento");
            }
            else
            {
                try
                {
                    resultado = obj_sql.sqlquery(
                    "INSERT INTO clientes(id_cliente, nombre, apellido, email, direccion, sitio_web, nit, id_departamento) VALUES('"
                    + Int32.Parse(txt_id.Text) + "','" 
                    + txt_nombre.Text + "','" 
                    + txt_apellido.Text + "','" 
                    + txt_email.Text + "','" 
                    + txt_direccion.Text + "','" 
                    + txt_sitio.Text + "','"
                    + txt_nit.Text + "','" 
                    + combo_departamentos.SelectedValue + "')",
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
