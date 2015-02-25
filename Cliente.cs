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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            try
            {
                SqlClass obj_sql = new SqlClass();
                DataSet obj_dataset = new DataSet();
                obj_sql.adapter(
                    "SELECT id_cliente AS ID, nombre AS NOMBRE, apellido AS APELLIDO, email AS EMAIL, nit AS NIT FROM clientes",
                    obj_sql.conexion()
                    ).Fill(obj_dataset);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = obj_dataset.Tables[0];
                dataGridView1.ClearSelection();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            NuevoCliente form = new NuevoCliente();
            form.Show();
        }
    }
}
