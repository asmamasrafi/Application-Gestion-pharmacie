using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GESTIONpharmacie
{
    public partial class paiement : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I3NSLNF;Initial Catalog=BDpharmacie;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeft,
            int nTop,
           int nRight,
           int nBottom,
           int nWidthEllipse,
           int nHeightEllipse);
        public paiement()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

           // Application.Exit();

        }

        private void btnacceuil_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            this.Hide();
            obj.Show();
        }

        private void btnmedicament_Click(object sender, EventArgs e)
        {

            medicament obj = new medicament();
            obj.Show();
            this.Close();
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            this.Hide();
            obj.Show();
        }

        private void btnvente_Click(object sender, EventArgs e)
        {
          Vente obj = new Vente();
            this.Hide();
            obj.Show();
        }

        private void paiement_Load(object sender, EventArgs e)
        {
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));

        }

        private void btnfourniseur_Click(object sender, EventArgs e)
        {

            Fournisseur form1 = new Fournisseur();
            form1.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Fournisseur form1 = new Fournisseur();
            form1.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            Vente obj = new Vente();
            this.Hide();
            obj.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            this.Hide();
            obj.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            medicament obj = new medicament();
            obj.Show();
            this.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            this.Hide();
            obj.Show();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            textBox1.Text= string.Empty;
            textBox2.Text= string.Empty;    
            textBox3.Text= string.Empty;
            checkBox1.Text= string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            creditcart obj= new creditcart();
            obj.Show();

        }

        private void button1espece_Click(object sender, EventArgs e)
        {
            MessageBox.Show("vous avez effectuer un paiement en espece ");
            label21.Text = "en Espece";

        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            Stock f1= new Stock();
            f1.Show();
            this.Hide();
        }

        private void btnachat_Click(object sender, EventArgs e)
        {
            achat f1=new achat();
            f1.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            creeVente f1= new creeVente();

            label17.Text=f1.dateTimePicker2.Value.ToString();
        }

        private void label18_Click(object sender, EventArgs e)
        {
           /* creeVente f1 = new creeVente();
          f1.comboBox2.Text  =this.label18.Text.ToString() ;*/
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int mt = int.Parse(textBox1.Text);
            int mtr = int.Parse(label13.Text);

            mt = mt - mtr;
            label12.Text = mt.ToString();

        }

        private void label12_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IMprimmer f1=new IMprimmer();
            f1.idvente = textBox2.Text;
            f1.nprod = label20.Text;
            f1.qte = label14.Text;
            f1.mode = label19.Text;
            f1.total = label13.Text;
            f1.ShowDialog();  

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
