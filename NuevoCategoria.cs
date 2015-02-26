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
    public partial class NuevoCategoria : Form
    {
        public NuevoCategoria()
        {
            InitializeComponent();
        }

        private void NuevoCategoria_Load(object sender, EventArgs e)
        {
            SqlClass obj_sql = new SqlClass();
            SqlCommand resultado;

            // 1. Traemos el último id disponible de la tabla Categorias
            try
            {
                resultado = obj_sql.sqlquery(
                    "SELECT MAX(id_categoria + 1) FROM categorias",
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
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            SqlClass obj_sql = new SqlClass();
            SqlCommand resultado;
            
            if(txt_categoria.Text.Length == 0){
                MessageBox.Show("No puedes dejar Categoria vacío!");
            }
            else
            {
                try
                {
                    resultado = obj_sql.sqlquery(
                    "INSERT INTO categorias(id_categoria, categoria, descripcion) VALUES('"
                    + Int32.Parse(txt_id.Text) + "','"
                    + txt_categoria.Text + "','"
                    + txt_descripcion.Text + "')",
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
