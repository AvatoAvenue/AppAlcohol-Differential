using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TiempodeUnaCervezaDef
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void cargaDatosCMB()
        {
            LlenadoCB cervezasDB = new LlenadoCB();
            var cervezas = cervezasDB.Get();
            foreach (var c in cervezas)
            {
                cmbCervezas.Items.Add(c.nombre);
            }
        }
        private void txtEnter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            foreach (Control ctrl in pContainer.Controls)
            {
                if (ctrl is PictureBox && ctrl.Name == "pb" + txt.Tag.ToString())
                {
                    ctrl.BackColor = Color.FromArgb(79, 129, 189);
                }
                if (ctrl is Label && ctrl.Name == "lbl" + txt.Tag.ToString())
                {
                    ctrl.ForeColor = Color.FromArgb(79, 129, 189);
                }
            }
        }
        private void txtleave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            foreach (Control ctrl in pContainer.Controls)
            {
                if (ctrl is PictureBox && ctrl.Name == "pb" + txt.Tag.ToString())
                {
                    ctrl.BackColor = Color.White;
                }
                if (ctrl is Label && ctrl.Name == "lbl" + txt.Tag.ToString())
                {
                    ctrl.ForeColor = Color.White;
                }
            }
        }
        private void BtnSalida(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnSicheve(object sender, EventArgs e)
        {
            Informacion.eModelo = cmbCervezas.SelectedIndex;
            Informacion.eCantidad = txtboxcantidadcervezas.Text;
            Informacion.eTiempo = txtboxtiempo.Text;
            ProcesoDeCalculo pc = new ProcesoDeCalculo();
            pc.proceso();
            cmbCervezas.SelectedIndex = -1;
            txtboxcantidadcervezas.Text = "";
        }
        private void btnNocheve(object sender, EventArgs e)
        { 
            cmbCervezas.Visible = false;
            txtboxcantidadcervezas.Visible = false;
            button3.Visible = false;
            button2.Visible = false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargaDatosCMB();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        public void btnResultao(object sender, EventArgs e)
        {
            Informacion.eModelo = cmbCervezas.SelectedIndex;
            Informacion.eCantidad = txtboxcantidadcervezas.Text;
            Informacion.eTiempo = txtboxtiempo.Text;
            if (temporal.temp == 0)
            {
                txtboxtiempo.Visible = false;
                cmbCervezas.Visible = false;
                txtboxcantidadcervezas.Visible = false;
                button6.Visible = true;
                
                ProcesoDeCalculo pc = new ProcesoDeCalculo();
                pc.proceso();
                pc.impresionTotal();
                temporal.temp = 0;
            }
            else if(temporal.temp > 0)
            {
                ProcesoDeCalculo pc = new ProcesoDeCalculo();
                pc.procesoOT();
                pc.impresionTotal();
            }
            else
            {
                MessageBox.Show("Recuerda seleccionar que no a la posibilidad de otra cerveza o actualizar");
            }
            button5.Visible = true; button6.Visible = true;
        }
        private void btnNotempo(object sender, EventArgs e)
        {
            button5.Visible = true;
            button6.Visible = false;
            temporal.temp = 0;
        }

        private void btnSitempo(object sender, EventArgs e)
        {
            txtboxtiempo.Visible=true;
            button5.Visible=true;
            button6.Visible=true;
            temporal.temp = 1;

        }
    }

    class temporal
    {
        public static int temp { get; set;}
    }
}
