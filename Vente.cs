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
    public partial class Vente : Form
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
        public Vente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            creeVente obj=new creeVente();
            this.Hide();
            obj.Show(); 
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void searchData()
        {
            string nom = comboBoxrecherchIDvente.Text;
            textBox1.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Vente Where IDvente like '%" + Convert.ToInt32(textBox1.Text) + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1Vente.DataSource = dt;
            conn.Close();

        }


        public void searchData1()
        {
            string nom = comboBoxcherenomprod.Text;
            textBox2.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Vente Where designation like '%" + textBox2.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1Vente.DataSource = dt;
            conn.Close();

        }
        private void LoadRecords()
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Vente ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1Vente.DataSource = dt;
            conn.Close();
        }
        private void Vente_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'bDpharmacieDataSet.Vente'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //   this.venteTableAdapter.Fill(this.bDpharmacieDataSet.Vente);
            LoadRecords();
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Vente";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxrecherchIDvente.Items.Add(dr["IDvente"]);
            }
            conn.Close();


            /////
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Vente";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxcherenomprod.Items.Add(dr["designation"]);
            }
            conn.Close();


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            this.Hide();
            obj.Show();
        }

        private void btnfourniseur_Click(object sender, EventArgs e)
        {
            Fournisseur form1 = new Fournisseur();
            form1.Show();
            this.Hide();
        }

        private void btnvente_Click(object sender, EventArgs e)
        {

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

        private void btnpaiement_Click(object sender, EventArgs e)
        {
            paiement form1 = new paiement();
            form1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1Vente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            modifierVente F1 = new modifierVente();
            F1.textBox2.Text = this.dataGridView1Vente.CurrentRow.Cells[0].Value.ToString();
            F1.textBox5.Text = this.dataGridView1Vente.CurrentRow.Cells[1].Value.ToString();
            F1.textBox4.Text = this.dataGridView1Vente.CurrentRow.Cells[2].Value.ToString();
            F1.textBox7.Text = this.dataGridView1Vente.CurrentRow.Cells[3].Value.ToString();
            F1.textBox11.Text = this.dataGridView1Vente.CurrentRow.Cells[4].Value.ToString();
            F1.textBox3.Text = this.dataGridView1Vente.CurrentRow.Cells[5].Value.ToString();
            F1.textBox10.Text = this.dataGridView1Vente.CurrentRow.Cells[6].Value.ToString();
            F1.comboBoxcRemise.Text = this.dataGridView1Vente.CurrentRow.Cells[7].Value.ToString();
            F1.textBox8.Text = this.dataGridView1Vente.CurrentRow.Cells[8].Value.ToString();
            F1.dateTimePicker1.Text = this.dataGridView1Vente.CurrentRow.Cells[9].Value.ToString();
            F1.textBox1.Text = this.dataGridView1Vente.CurrentRow.Cells[10].Value.ToString();


            F1.ShowDialog();

        }

        private void dataGridView1Vente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            Stock obj = new Stock();
            this.Hide();
            obj.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxrecherchIDvente.Text) == false)
            {

                searchData();
            }
            else if (String.IsNullOrEmpty(comboBoxcherenomprod.Text) == false)
            {

                searchData1();
            }
           
        }

        private void btnachat_Click(object sender, EventArgs e)
        {
            achat f1 = new achat();
            this.Close();
            f1.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            comboBoxrecherchIDvente.Text = string.Empty;
            comboBoxcherenomprod.Text = string.Empty;
        }
        public void refr()
        {
            string query = "select * from Vente";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataSet ds = new System.Data.DataSet();
            sda.Fill(ds, "Vente");
            dataGridView1Vente.DataSource = ds.Tables[0];
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            refr();
        }
    }
}
