using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEjemploSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Instancia de EmpleadoConexionSQL, inicializa 
            empleadoConexionSQL = new EmpleadoConexionSQL();
            MostrarEmpleadosEnDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private EmpleadoConexionSQL empleadoConexionSQL;

      
        private void MostrarEmpleadosEnDataGridView()
        {
            // Limpio el DataGridView
            dataGridView1.Rows.Clear();

            // Obtrngo la lista de empleados desde la base de datos
            List<Empleado> empleados = empleadoConexionSQL.ListarEmpleados();

            // Agrego las columnas manualmente
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("Nombre", "NOMBRE");
            dataGridView1.Columns.Add("Descripcion", "DESCRIPCION");
            dataGridView1.Columns.Add("Precio", "PRECIO");

            // Agrego cada empleado al DataGridView
            foreach (Empleado empleado in empleados)
            {
                // Agrego una fila al DataGridView
                dataGridView1.Rows.Add(empleado.Id, empleado.Nombre, empleado.Descripcion, empleado.Precio);
            }
        }

        private void TuBotonMostrarEmpleados_Click(object sender, EventArgs e)
        {
           
            MostrarEmpleadosEnDataGridView();
        }
    }






}

