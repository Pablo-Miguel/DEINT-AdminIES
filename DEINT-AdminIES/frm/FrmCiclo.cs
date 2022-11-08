using DEINT_AdminIES.DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEINT_AdminIES.frm
{
    public partial class FrmCiclo : Form
    {
        CicloDLL ciclodll;
        public FrmCiclo()
        {
            ciclodll = new CicloDLL();
            InitializeComponent();
            dgCiclo.DataSource = ciclodll.MostrarCiclos().Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!tbCiclo.Text.Equals(""))
            {
                ciclodll.Agregar(tbCiclo.Text);
                dgCiclo.DataSource = ciclodll.MostrarCiclos().Tables[0];
            }
            else {
                MessageBox.Show("Campo del ciclo vacío, porfavor introduza los datos oportunos");
            }
        }

        private void dgCiclo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) { 
                tbID.Text = dgCiclo.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbCiclo.Text = dgCiclo.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!tbCiclo.Text.Equals("") && !tbID.Text.Equals(""))
            {
                ciclodll.Modificar(tbID.Text, tbCiclo.Text);
                dgCiclo.DataSource = ciclodll.MostrarCiclos().Tables[0];
            }
            else
            {
                MessageBox.Show("Campo del ciclo vacío, porfavor introduza los datos oportunos");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (!tbID.Text.Equals(""))
            {
                ciclodll.Borrar(tbID.Text);
                dgCiclo.DataSource = ciclodll.MostrarCiclos().Tables[0];
                tbID.Clear();
                tbCiclo.Clear();
            }
            else
            {
                MessageBox.Show("Campo ID vacío, porfavor no toque los datos para borrar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
