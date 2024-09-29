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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Refrescar();
        }
        private void Refrescar()
        {
            UniversidadDB dB = new UniversidadDB();
            dtgvAlumnos.DataSource = dB.Get();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private int getId()
        {
            return int.Parse(dtgvAlumnos.Rows[dtgvAlumnos.CurrentRow.Index].Cells[0].Value.ToString());
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregar frm = new FormAgregar();
            frm.ShowDialog();
            Refrescar();
        }



        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            int id = getId();
            FormEditar frmeditar = new FormEditar(id);
            frmeditar.ShowDialog();
            Refrescar();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int id = getId();
            try
            {
                UniversidadDB dB = new UniversidadDB();
                dB.Remove((int)id);
                Refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)

        {
                int dni;
                if (int.TryParse(txtDNI.Text, out dni)) 
                {
                    UniversidadDB db = new UniversidadDB();
                    List<Alumnos> alumnos = db.BuscarPorDNI(dni);

                    dtgvAlumnos.DataSource = alumnos; 
                }
                else
                {
                    MessageBox.Show("Por favor, introduce un DNI válido.");
                }
            }


    }
    }

