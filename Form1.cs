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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void creditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarollado por:\n Ramón Andrés Canales\n Alexander Navarro\n Ricardo Clemente\n Jorge Menjívar");
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente form_cliente = new Cliente();
            form_cliente.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleado form_empleado = new Empleado();
            form_empleado.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categoria form_categoria = new Categoria();
            form_categoria.Show();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Producto form_producto = new Producto();
            form_producto.Show();
        }
    }
}
