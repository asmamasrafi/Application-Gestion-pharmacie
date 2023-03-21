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

namespace GESTIONpharmacie
{
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I3NSLNF;Initial Catalog=BDpharmacie;Integrated Security=True");
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeft,
            int nTop,
           int nRight,
           int nBottom,
           int nWidthEllipse,
           int nHeightEllipse);
        public Form2()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public string searchbest1()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select  Client.nom from Client ,Vente where  Client.IDclient=Vente.IDclient Group by Client. nom having COUNT(nom) >= 2  ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            String res = string.Join(Environment.NewLine,
            dt.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            return res;
        }
        public string searchbest2()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select  Produit.designation  from Produit ,Vente where  Vente.IDproduit=Produit.IDproduit Group by Produit.designation having COUNT(Produit.designation) >= 2  ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            String res = string.Join(Environment.NewLine,
            dt.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            return res;
        }
        public string searchbestFORNISSEUR()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select  Fournisseur.Nom  from Fournisseur ,CommandeLivre where  CommandeLivre.IDfourn=Fournisseur.IDfourn Group by Fournisseur.Nom having COUNT(Fournisseur.Nom) >= 2  ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            String res = string.Join(Environment.NewLine,
            dt.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            return res;
        }
        public string nbrFORNISSEUR()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select  Count(*) from Fournisseur ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            String res = string.Join(Environment.NewLine,
            dt.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            return res;
        }
        public string nbr_client()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select  top 1 Count(*) from Client ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            String res = string.Join(Environment.NewLine,
            dt.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            return res;
        }
        public string nbr_produit()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select  Count(*) from Produit   ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            String res = string.Join(Environment.NewLine,
            dt.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
            return res;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 40, 40));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 20, 20));
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 20, 20));
            panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width, panel6.Height, 20, 20));

            panel7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel7.Width, panel7.Height, 20, 20));
            panel8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel8.Width, panel8.Height, 20, 20));

            label13.Text = searchbestFORNISSEUR();
            label11.Text = searchbest1();
            label14.Text = searchbest2();
            label5.Text = nbr_produit();
            label7.Text = nbr_client();
            label9.Text = nbrFORNISSEUR();
        }

        private void button7_Click(object sender, EventArgs e)
        {
             Form1 form1= new Form1();
            form1.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {Application.Exit();
          
                }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

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
            this.Hide();
            obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            this.Hide();
            obj.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            medicament obj = new medicament();
            this.Hide();
            obj.Show();
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            this.Hide();
            obj.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            this.Hide();
            obj.Show();
        }

        private void btnvente_Click(object sender, EventArgs e)
        {
            Vente obj = new Vente();
            obj.Show();
            this.Close();
        }

        private void btnpaiement_Click(object sender, EventArgs e)
        {
            paiement obj =new paiement();
            this.Hide();
            obj.Show();
        }

        private void btnfourniseur_Click(object sender, EventArgs e)
        {

            Fournisseur form1 = new Fournisseur();
            form1.Show();
            this.Hide();
        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            Stock obj = new Stock();
            this.Hide();
            obj.Show();
        }

        private void btnachat_Click(object sender, EventArgs e)
        {
            achat f1 = new achat();
            this.Close();
            f1.Show();
        }
    }
}
