using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GESTIONpharmacie
{
    public partial class Client : Form
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
        public Client()
        {
            InitializeComponent();
        }

        private void comboecherchIDprod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void refr()
        {
            string query = "select * from Client";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataSet ds = new System.Data.DataSet();
            sda.Fill(ds, "Client");
            dataGridViewCLIENT.DataSource = ds.Tables[0];
        }
        private void Client_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'bDpharmacieDataSet.Client'. Vous pouvez la déplacer ou la supprimer selon les besoins.
          //  this.clientTableAdapter.Fill(this.bDpharmacieDataSet.Client);
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Client";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboecherchIDclient.Items.Add(dr["IDclient"]);
            }
            conn.Close();
            ///////////
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Client";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox4cherchenomCLLIENT.Items.Add(dr["nom"]);
            }
            conn.Close();
            panel2CLIENT.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2CLIENT.Width, panel2CLIENT.Height, 20, 20));
            //// AJOUTER CLIENT

            LoadRecords();
        }

        private void btnclient_Click(object sender, EventArgs e)
        {

        }

        private void btnacceuil_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Close();
        }

        private void btnmedicament_Click(object sender, EventArgs e)
        {
            medicament obj = new medicament();
            obj.Show();
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            medicament obj = new medicament();
            obj.Show();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        int a;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
         private void LoadRecords()
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Client ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewCLIENT.DataSource = dt;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
       

        private void btnvente_Click(object sender, EventArgs e)
        {
            Vente obj = new Vente();
            obj.Show();
            this.Close();
        }

        private void btnpaiement_Click(object sender, EventArgs e)
        {
            paiement obj = new paiement();
            this.Hide();
            obj.Show();
        }

        private void btnfourniseur_Click(object sender, EventArgs e)
        {

            Fournisseur form1 = new Fournisseur();
            form1.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I3NSLNF;Initial Catalog=BDpharmacie;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Client Where type like  '%Client regulière%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewCLIENT.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox4cherchenomCLLIENT.Text) == false)
            {

                searchData1();
            }
            else if (String.IsNullOrEmpty(comboecherchIDclient.Text) == false)
            {

                searchData();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ajoutclient obj =new ajoutclient();
           
            obj.Show(); 
        }

        private void dataGridViewCLIENT_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ajoutclient F1 = new ajoutclient();
            F1.textBox9.Text = this.dataGridViewCLIENT.CurrentRow.Cells[0].Value.ToString();
            F1.textBox1.Text = this.dataGridViewCLIENT.CurrentRow.Cells[1].Value.ToString();
            F1.comboBox1.Text = this.dataGridViewCLIENT.CurrentRow.Cells[2].Value.ToString();
            F1.textBox6.Text = this.dataGridViewCLIENT.CurrentRow.Cells[3].Value.ToString();
            F1.textBox5.Text = this.dataGridViewCLIENT.CurrentRow.Cells[4].Value.ToString();
            F1.textBox2.Text = this.dataGridViewCLIENT.CurrentRow.Cells[5].Value.ToString();


            F1.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            comboecherchIDclient.Text = string.Empty;
            comboBox4cherchenomCLLIENT.Text=string.Empty;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            refr();
        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            Stock obj = new Stock();
            this.Hide();
            obj.Show();
        }
        public void searchData()
        {
            string nom = comboecherchIDclient.Text;
            textBox1.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Client Where IDclient like '%" + Convert.ToInt32(textBox1.Text) + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewCLIENT.DataSource = dt;
            conn.Close();

        }
        public void searchData1()
        {
            string nom = comboBox4cherchenomCLLIENT.Text;
            textBox2.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Client Where nom like '%" + textBox2.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewCLIENT.DataSource = dt;
            conn.Close();

        }

        private void btnachat_Click(object sender, EventArgs e)
        {
            achat f1 = new achat();
            this.Close();
            f1.Show();

        }
    }
}
