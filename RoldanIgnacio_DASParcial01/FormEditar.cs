using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoldanIgnacio_DASParcial01
{
    public partial class FormEditar : Form
    {
        int id;

        public FormEditar(int id)
        {
            InitializeComponent();
            this.id = id;

        }
        private void CargarDatos()
        {
            UniversidadDB _UniversidadDB = new UniversidadDB();
            Alumnos alumnos = _UniversidadDB.GetAlumno((int)id);
            txtNombre.Text = alumnos.Nombre;
            txtApellido.Text = alumnos.Apellido;
            txtDNI.Text = alumnos.DNI.ToString();
            txtCodigo.Text = alumnos.Codigo_Carrera;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            UniversidadDB _UniversidadDB = new UniversidadDB();

            _UniversidadDB.Update(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtDNI.Text), txtCodigo.Text, this.id);
            this.Close();
        }

        private void FormEditar_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
