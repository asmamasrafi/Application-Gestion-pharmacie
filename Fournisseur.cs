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
    public partial class Fournisseur : Form
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
        public Fournisseur()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void btnvente_Click(object sender, EventArgs e)
        {
            Vente obj = new Vente();
            this.Hide();
            obj.Show();
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            this.Hide();
            obj.Show();
        }

        private void btnmedicament_Click(object sender, EventArgs e)
        {
            medicament obj = new medicament();
            obj.Show();
            this.Close();
        }

        private void btnacceuil_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            this.Hide();
            obj.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void btnpaiement_Click(object sender, EventArgs e)
        {
            paiement form1 = new paiement();
            form1.Show();
            this.Hide();
        }
        public void searchData()
        {
            string nom = comboBox4cherchenomfourn.Text;
            textBox2.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Fournisseur Where Nom like '%" + textBox2.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        public void searchData1()
        {
            string nom = comboecherchIDfourn.Text;
            textBox1.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Fournisseur Where IDfourn like '%" + textBox1.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        private void Fournisseur_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Fournisseur";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboecherchIDfourn.Items.Add(dr["IDfourn"]);
            }
            conn.Close();


            /////
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Fournisseur";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox4cherchenomfourn.Items.Add(dr["nom"]);
            }
            conn.Close();





            // TODO: cette ligne de code charge les données dans la table 'bDpharmacieDataSet1.Fournisseur'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.fournisseurTableAdapter1.Fill(this.bDpharmacieDataSet1.Fournisseur);
            // TODO: cette ligne de code charge les données dans la table 'bDpharmacieDataSet.Fournisseur'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.fournisseurTableAdapter.Fill(this.bDpharmacieDataSet.Fournisseur);
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ajouterfourniseur F1 = new ajouterfourniseur();
            F1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            Stock obj = new Stock();
            this.Hide();
            obj.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

              ajouterfourniseur F1 = new ajouterfourniseur();
            F1.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            F1.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            F1.textBox4.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            F1.textBox6.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            F1.textBox5.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
           // F1.textBox6.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();


            F1.ShowDialog();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrEmpty(comboecherchIDfourn.Text) == false)
            {

                searchData1();
            }
            else if (String.IsNullOrEmpty(comboBox4cherchenomfourn.Text) == false)
            {

                searchData();
            }
            
            
        }
        public void refr()
        {
            string query = "select * from Fournisseur";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataSet ds = new System.Data.DataSet();
            sda.Fill(ds, " Fournisseur");
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void btnachat_Click(object sender, EventArgs e)
        {
            achat f1 = new achat();
            this.Close();
            f1.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            comboBox4cherchenomfourn.Text = string.Empty;
            comboecherchIDfourn.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            refr();
        }
    }
}
