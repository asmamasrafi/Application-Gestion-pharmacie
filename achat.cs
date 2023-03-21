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
    public partial class achat : Form
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
        public achat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ajouterCommnade obj =new ajouterCommnade();
            obj.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Commandelivre f1=new Commandelivre();   
            f1.Show();
            this.Close();
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
        public void refr()
        {
            string query = "select * from Commande";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataSet ds = new System.Data.DataSet();
            sda.Fill(ds, "Commande");
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void achat_Load(object sender, EventArgs e)
        {
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            // TODO: cette ligne de code charge les données dans la table 'bDpharmacieDataSet.Commande'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.commandeTableAdapter.Fill(this.bDpharmacieDataSet.Commande);
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Commande";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboboxIDachat.Items.Add(dr["IDachat"]);
            }
            conn.Close();

            ////
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Commande";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxnomprod.Items.Add(dr["designation"]);
            }
            conn.Close();
        }


        public void searchData()
        {
            string nom = comboboxIDachat.Text;
            textBox1.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Commande Where IDachat like '%" + textBox1.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }


        public void searchData1()
        {
            string nom = comboBoxnomprod.Text;
            textBox2.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Commande Where designation like '%" + textBox2.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        private void dataGridView1Vente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ajouterCommnade F1 = new ajouterCommnade();
            F1.textBox9.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            F1.comboBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            F1.textBox5.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            F1.comboBox2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            F1.textBox3.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            F1.textBox1.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            F1.dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();


            F1.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboboxIDachat.Text) == false)
            {

                searchData();
            }
            else if (String.IsNullOrEmpty(comboBoxnomprod.Text) == false)
            {

                searchData1();
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            refr();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            comboboxIDachat.Text = string.Empty;
            comboBoxnomprod.Text = string.Empty;
                
        }
    }
}
