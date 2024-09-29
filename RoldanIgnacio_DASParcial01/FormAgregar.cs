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
    public partial class FormAgregar : Form
    {
            private int? id;
            public FormAgregar(int? id = null)
            {
                InitializeComponent();
                this.id = id;
                if (this.id != null)
                {
                    CargarDatos();
                }
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
            try
            {
                _UniversidadDB.Add(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtDNI.Text), txtCodigo.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }
        }
    }

}

