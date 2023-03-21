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

namespace GESTIONpharmacie
{
    public partial class Commandelivre : Form
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
        public Commandelivre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ajoutercomLIV f1=new ajoutercomLIV();
            f1.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnfourniseur_Click(object sender, EventArgs e)
        {
            Fournisseur form1 = new Fournisseur();
            form1.Show();
            this.Hide();
        }

        private void btnstock_Click(object sender, EventArgs e)
        {

            Stock f1 = new Stock();
            f1.Show();
            this.Hide();
        }

        private void btnpaiement_Click(object sender, EventArgs e)
        {
            paiement form1 = new paiement();
            form1.Show();
            this.Hide();
        }


        public void searchData()
        {
            string nom = comboBoxrecherchIDliv.Text;
            textBox1.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from CommandeLivre Where num_liv like '%" + textBox1.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        public void searchData1()
        {
            string nom = comboBoxcherenomprod.Text;
            textBox2.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from CommandeLivre Where Nomprod like '%" + textBox2.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        private void Commandelivre_Load(object sender, EventArgs e)
        {
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            // TODO: cette ligne de code charge les données dans la table 'bDpharmacieDataSet1.CommandeLivre'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.commandeLivreTableAdapter1.Fill(this.bDpharmacieDataSet1.CommandeLivre);
            // TODO: cette ligne de code charge les données dans la table 'bDpharmacieDataSet.CommandeLivre'. Vous pouvez la déplacer ou la supprimer selon les besoins.
           

            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM CommandeLivre";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxrecherchIDliv.Items.Add(dr["num_liv"]);
            }
            conn.Close();

            ////
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM CommandeLivre";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxcherenomprod.Items.Add(dr["Nomprod"]);
            }
            conn.Close();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ajoutercomLIV F1 = new ajoutercomLIV();
            F1.textBox9.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            F1.comboBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            F1.textBox5.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            F1.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            F1.textBox2.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            F1.textBox1.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            F1.dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            F1.comboBox1.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            F1.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxrecherchIDliv.Text) == false)
            {

                searchData();
            }
            else if (String.IsNullOrEmpty(comboBoxcherenomprod.Text) == false)
            {

                searchData1();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void refr()
        {
            string query = "select * from CommandeLivre";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataSet ds = new System.Data.DataSet();
            sda.Fill(ds, " CommandeLivre");
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            comboBoxrecherchIDliv.Text = string.Empty;
            comboBoxcherenomprod.Text = string.Empty;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            refr();
        }
    }
}
