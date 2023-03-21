using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GESTIONpharmacie
{
    public partial class Stock : Form
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
        public Stock()
        {
            InitializeComponent();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Stock_Load(object sender, EventArgs e)
        {
            panel2CLIENT.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2CLIENT.Width, panel2CLIENT.Height, 20, 20));
            // TODO: cette ligne de code charge les données dans la table 'bDpharmacieDataSet.Stock'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.stockTableAdapter.Fill(this.bDpharmacieDataSet.Stock);
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Stock";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxcherenomprod.Items.Add(dr["designation"]);
            }
            conn.Close();
            ///////////
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Stock";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxrecherchIDprod.Items.Add(dr["IDprod"]);
            }
            conn.Close();
            //////
           

        }

        private void btnmedicament_Click(object sender, EventArgs e)
        {
            medicament obj = new medicament();
            this.Hide();
            obj.Show();
        }


        public void searchData()
        {
            string nom = comboBoxrecherchIDprod.Text;
            textBox1.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Stock Where IDprod like '%" + textBox1.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewCLIENT.DataSource = dt;
            conn.Close();

        }

        public void searchData1()
        {
            string nom = comboBoxcherenomprod.Text;
            textBox2.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Stock  Where designation like '%" + textBox2.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewCLIENT.DataSource = dt;
            conn.Close();

        }
        public void searchData2()
        {
            
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Stock Where CodeBar like '%" + textBox6.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewCLIENT.DataSource = dt;
            conn.Close();

        }
        private void btnclient_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            this.Hide();
            obj.Show();
        }

        private void btnvente_Click(object sender, EventArgs e)
        {
            Vente obj= new Vente();
            this.Hide();
            obj.Show();
        }

        private void btnfourniseur_Click(object sender, EventArgs e)
        {
            Fournisseur fournisseurobj = new Fournisseur();
            this.Hide();
            fournisseurobj.Show();
        }

        private void btnpaiement_Click(object sender, EventArgs e)
        {
            paiement obj= new paiement();
            this.Hide();
            obj.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            comboBoxcherenomprod.Text = string.Empty;
            comboBoxrecherchIDprod.Text = string.Empty;
            textBox6.Text = string.Empty;

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newprod f1 = new newprod();
            f1.Show();
        }

        private void btnachat_Click(object sender, EventArgs e)
        {
            achat f1 = new achat();
            this.Close();
            f1.Show();
        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxrecherchIDprod.Text) == false)
            {

                searchData();
            }
            else if (String.IsNullOrEmpty(comboBoxcherenomprod.Text) == false)
            {

                searchData1();
            }
            else if (String.IsNullOrEmpty(textBox6.Text) == false)
                {

                    searchData2();
                }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void refrch()
        {
            string query = "select * from Stock";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataSet ds = new System.Data.DataSet();
            sda.Fill(ds, "Stock");
            dataGridViewCLIENT.DataSource = ds.Tables[0];

        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            refrch();
        }
    }
}
