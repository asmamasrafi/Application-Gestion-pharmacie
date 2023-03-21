using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;

namespace GESTIONpharmacie
{
    public partial class medicament : Form
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
        public medicament()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnmedicament_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void btnacceuil_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            this.Hide();
            obj.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void displaydataforproduit()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select  Produit.IDproduit,Produit.designation,Produit.Categorie,Produit.forme,Produit.prixUn,Produit.codeBarre,Produit.dateExp,Produit.status,Stock.Qte_stck,Stock.ppv,Stock.pph,Stock.QteDisp  From Produit full outer join Stock   on Produit.IDproduit=Stock.IDprod  ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        public void searchData()
        {
            string nom = comboBoxrecherchIDprod.Text;
            textBox1.Text = nom;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Produit Where IDproduit like '%" + textBox1.Text + "%'";
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
            cmd.CommandText = "Select * from    Produit Where designation  like '%" + textBox2.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        
        public void searchData2()
        {
           
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Produit Where codeBarre like '%" + textBox6.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        
        private void medicament_Load(object sender, EventArgs e)
        {
            displaydataforproduit();
           

            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            ///////////
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Produit";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxrecherchIDprod.Items.Add(dr["IDproduit"]);
            }
            conn.Close();
            /////////
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Produit";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxcherenomprod.Items.Add(dr["Designation"]);
            }
            conn.Close();
          
        }



        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            Client obj = new Client();
            this.Hide();
            obj.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            this.Hide();
            obj.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            Client obj = new Client();
            this.Hide();
            obj.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void button1_Click(object sender, EventArgs e)

        {
            newprod obj = new newprod();
            obj.Show();
            /* conn.Open();

             cmd = conn.CreateCommand();
             cmd.CommandType = System.Data.CommandType.Text;
             cmd.CommandText = "insert into Produit values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBoxcatego.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() +"','" + textBox3.Text + "','" +DateTime.Parse(dateTimePicker1.Text )+ "','" + comboBox2.SelectedItem.ToString() + "','" + textBox4.Text + "')";
             cmd.ExecuteNonQuery();

             MessageBox.Show("Un nouveau Produit a ete inserer ");
             textBox1.Text = "";
             textBox2.Text = "";
             comboBoxcatego.Text = "";
             comboBox3.Text = "";
             dateTimePicker1.Text = "";
             comboBox2.Text = "";
             textBox4.Text = "";

             LoadRecords();
             conn.Close();*/
        }

        private void btnvente_Click(object sender, EventArgs e)
        {
            Vente obj = new Vente();
            obj.Show();
            this.Close();
        }

        private void btnpaiement_Click(object sender, EventArgs e)
        {
            paiement form1 = new paiement();
            form1.Show();
            this.Hide();
        }

        private void btnfourniseur_Click(object sender, EventArgs e)
        {
            Fournisseur form1 = new Fournisseur();
            form1.Show();
            this.Hide();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
          
           
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
       
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(comboBoxrecherchIDprod.Text)==false) {

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


            //searchData1();
            // searchData2();
        }
        public void refr()
        {
            displaydataforproduit();
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            refr();
        }

        private void dataGridView1prod_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

           
            //F1.TextBox8.Text=this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
           // F1.TextBox7.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();

           
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            comboBoxcherenomprod.Text = string.Empty;
            comboBoxrecherchIDprod.Text = string.Empty;
            textBox6.Text= string.Empty;
            textBox3.Text= string.Empty;
            textBox2.Text= string.Empty;    
            textBox1.Text= string.Empty;

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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            newprod F1 = new newprod();
            F1.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            F1.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            F1.comboBoxcatego.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            F1.comboBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            F1.textBox3.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            F1.dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            F1.comboBox2.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            F1.textBox5.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            F1.textBox6.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            F1.textBox7.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            F1.textBox8.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
            F1.textBox4.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString();
            F1.ShowDialog();
        }
    }
    }

