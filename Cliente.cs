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
        string ls_id_clientes = "0";
        public Cliente()
        {
            InitializeComponent();
        }
        private void cargar_datagridview1()
        {
            SqlClass ls_cadena = new SqlClass();
            DataSet lds_tablas = new DataSet();
            ls_cadena.adapter("SELECT id_cliente AS ID, nombre AS NOMBRE, apellido AS APELLIDO, email AS EMAIL, nit AS NIT FROM clientes", ls_cadena.conexion()).Fill(lds_tablas);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = lds_tablas.Tables[0];
            dataGridView1.ClearSelection();
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
         private void btn_editar_Click(object sender, EventArgs e)
        {
            if (ls_id_clientes == "0")
            {
                MessageBox.Show("No ha seleccionado un registro para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EditClientes lfrm_clientes = new EditClientes();
            lfrm_clientes.EditClientes_inicio("M", ls_id_clientes);
            lfrm_clientes.ShowDialog();
            ls_id_clientes = "0";
            cargar_datagridview1();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            { 
                ls_id_clientes = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); 
            } 
            else 
            {
                ls_id_clientes = "0"; 
            }
        }
    }
}
