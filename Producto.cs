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
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();
        }

        private void Producto_Load(object sender, EventArgs e)
        {

            try
            {
                SqlClass obj_sql = new SqlClass();
                DataSet obj_dataset = new DataSet();

                obj_sql.adapter(
                    "SELECT p.id_producto AS ID, p.nombre AS NOMBRE, p.marca AS MARCA,"+ 
                    "p.codigo AS CODIGO, p.precio AS PRECIO c.categoria AS CATEGORIA FROM productos p"+
                    "INNER JOIN categorias c ON p.id_categoria = c.id_categoria;",
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
    }
}
