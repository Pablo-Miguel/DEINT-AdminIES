using DEINT_AdminIES.frm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEINT_AdminIES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCiclos_Click(object sender, EventArgs e)
        {
            FrmCiclo frmCiclo = new FrmCiclo();
            frmCiclo.ShowDialog();
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            FrmEstudiante frmEstudiante = new FrmEstudiante();
            frmEstudiante.ShowDialog();
        }
    }
}
