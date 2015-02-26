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
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            try
            {
                SqlClass obj_sql = new SqlClass();
                DataSet obj_dataset = new DataSet();

                obj_sql.adapter(
                    "SELECT id_categoria AS ID, categoria AS CATEGORIA, descripcion AS DESCRIPCION FROM categorias",
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
            NuevoCategoria form = new NuevoCategoria();
            form.Show();
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
