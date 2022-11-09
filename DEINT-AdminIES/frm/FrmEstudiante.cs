using DEINT_AdminIES.DLL;
using DEINT_AdminIES.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEINT_AdminIES.frm
{
    public partial class FrmEstudiante : Form
    {
        private EstudianteDLL estudianteDLL;
        private CicloDLL ciclodll;
        private byte[] imgaenByte;

        public FrmEstudiante()
        {
            estudianteDLL = new EstudianteDLL();
            ciclodll = new CicloDLL();
            InitializeComponent();
            DataTable dt = ciclodll.MostrarCiclos().Tables[0];

            cbCiclo.ValueMember = "id";
            cbCiclo.DisplayMember = "nombre";
            cbCiclo.DataSource = dt;

            dgEstudiante.DataSource = estudianteDLL.MostrarEstudiantes().Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!tbNombre.Text.Equals("") && !tbPrimerApellido.Text.Equals("") && !tbCorreo.Text.Equals("") && !cbCiclo.Text.Equals(""))
            {
                estudianteDLL.Agregar(tbNombre.Text, tbPrimerApellido.Text, tbSegundoApllido.Text, 
                    tbCorreo.Text, cbCiclo.SelectedValue.ToString());
                dgEstudiante.DataSource = estudianteDLL.MostrarEstudiantes().Tables[0];
            }
            else
            {
                MessageBox.Show("Algún campo de estudiante está vacío, porfavor introduza los datos oportunos");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!tbClave.Text.Equals("") && !tbNombre.Text.Equals("") && !tbPrimerApellido.Text.Equals("") && !tbCorreo.Text.Equals("") && !cbCiclo.Text.Equals(""))
            {
                estudianteDLL.Modificar(tbClave.Text, tbNombre.Text, tbPrimerApellido.Text, tbSegundoApllido.Text, 
                    tbCorreo.Text, cbCiclo.SelectedValue.ToString());
                dgEstudiante.DataSource = estudianteDLL.MostrarEstudiantes().Tables[0];
            }
            else
            {
                MessageBox.Show("Algún campo de estudiante está vacío, porfavor introduza los datos oportunos");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (!tbClave.Text.Equals(""))
            {
                estudianteDLL.Borrar(tbClave.Text);
                dgEstudiante.DataSource = estudianteDLL.MostrarEstudiantes().Tables[0];
            }
            else
            {
                MessageBox.Show("Porfavor, la clave no puede estar vacía");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgEstudiante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();
            selectorImagen.Title = "Seleccionar imagen";

            if (selectorImagen.ShowDialog() == DialogResult.OK) {
                pbImagen.Image = Image.FromStream(selectorImagen.OpenFile());
                MemoryStream memoryStream = new MemoryStream();
                pbImagen.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                imgaenByte = memoryStream.ToArray();
            }
        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                // Convert byte[] to base 64 string
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        private void dgEstudiante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tbClave.Text = dgEstudiante.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbNombre.Text = dgEstudiante.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbPrimerApellido.Text = dgEstudiante.Rows[e.RowIndex].Cells[2].Value.ToString();
                tbSegundoApllido.Text = dgEstudiante.Rows[e.RowIndex].Cells[3].Value.ToString();
                tbCorreo.Text = dgEstudiante.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (!tbClave.Text.ToString().Equals("")) { 
                    cbCiclo.Text = estudianteDLL.obtenerCiclo(tbClave.Text).Tables[0].Rows[0]["nombre"].ToString();
                }
                
            }
        }
    }
}
