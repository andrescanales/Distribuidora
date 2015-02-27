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
    public partial class NuevoProducto : Form
    {
        public NuevoProducto()
        {
            InitializeComponent();
        }

        private void NuevoProducto_Load(object sender, EventArgs e)
        {
            SqlClass obj_sql = new SqlClass();
            SqlCommand resultado;

            // 1. Traemos el último id disponible de la tabla Productos
            try
            {
                resultado = obj_sql.sqlquery(
                    "SELECT MAX(id_producto + 1) FROM productos",
                    obj_sql.conexion()
                    );

                string id = resultado.ExecuteScalar().ToString();
                if (id == "")
                {
                    txt_id.Text = "1";
                    txt_id.Enabled = false;
                }
                else
                {
                    txt_id.Text = id;
                    txt_id.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // 2. Luego traemos todos las categorias para mostrarlos en el combobox
            try
            {
                DataSet dataset = new DataSet();

                SqlDataAdapter adapter = obj_sql.adapter(
                   "SELECT id_categoria AS id, categoria AS categoria FROM categorias",
                    obj_sql.conexion()
                    );

                adapter.Fill(dataset);
                adapter.Dispose();

                combo_categoria.DataSource = dataset.Tables[0];
                combo_categoria.ValueMember = "id";
                combo_categoria.DisplayMember = "categoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            SqlClass obj_sql = new SqlClass();
            SqlCommand resultado;

            if (txt_nombre.Text.Length == 0)
            {
                MessageBox.Show("No puedes dejar el producto sin nombre!");
            }
            else if (txt_marca.Text.Length == 0)
            {
                MessageBox.Show("No puedes dejar el producto sin marca!");
            }
            else if (txt_precio.Text.Length == 0)
            {
                MessageBox.Show("No puedes dejar el producto sin precio!");
            }
            else if (combo_categoria.Text.Length == 0)
            {
                MessageBox.Show("Selecciona una categoria");
            }
            else
            {
                try
                {
                    resultado = obj_sql.sqlquery(
                    "INSERT INTO productos(id_producto, nombre, peso, marca, codigo, precio, "
                    +"descripcion, id_categoria) VALUES('"
                    + Int32.Parse(txt_id.Text) + "','"
                    + txt_nombre.Text + "','"
                    + txt_peso.Text + "','"
                    + txt_marca.Text + "','"
                    + txt_codigo.Text + "','"
                    + Double.Parse(txt_precio.Text) + "','"
                    + txt_descripcion.Text + "','"
                    + combo_categoria.SelectedValue + "')",
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
