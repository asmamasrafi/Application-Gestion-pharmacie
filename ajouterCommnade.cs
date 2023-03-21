using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GESTIONpharmacie
{
    public partial class ajouterCommnade : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I3NSLNF;Initial Catalog=BDpharmacie;Integrated Security=True");
      
        public ajouterCommnade()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("etes vous sur d'ajouter une nouvelle commande ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Commande(IDachat,IDfourn,nomfourn,IDprod ,designation,qte,Date_achat)values ('" + textBox9.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "','"+ textBox1.Text + "','"+ Convert.ToDateTime(dateTimePicker1.Text) + "') ";
                cmd.ExecuteNonQuery();
                conn.Close();
                // LoadRecords();
                MessageBox.Show("Une nouvelle commande a ete inserer ");
                textBox1.Text = "";
                textBox3.Text = "";
                comboBox2.Text = "";
                comboBox1.Text = "";
                textBox5.Text = "";
                textBox9.Text = "";
             
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int idachat = int.Parse(textBox9.Text);
            int idfourn = int.Parse(comboBox1.Text);
            string nomfourn = textBox5.Text;
            string idprod = comboBox2.Text;
            string designation = textBox3.Text;
            string qte = textBox1.Text;
            DateTime dtachat = Convert.ToDateTime(dateTimePicker1.Text);



            if (MessageBox.Show("etes vous sur d'appliquer ces modifications?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " Update  Commande Set IDachat='" + idachat + "',IDfourn='" + idfourn + "',nomfourn='" + nomfourn + "',IDprod ='" + idprod + "',designation='" +designation + "' , qte='"+ qte+"',Date_achat='"+ dtachat + "' where IDachat='" + idachat + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                //displaydata();
                MessageBox.Show("Une Commande  a ete modifier ");
                textBox9.Text = " ";
                textBox1.Text = " ";
                textBox3.Text = " ";
                comboBox2.Text = " ";
                textBox5.Text = " ";
                comboBox1.Text = " ";
                

            }

        }

        private void ajouterCommnade_Load(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlDataReader dr;
            //SqlDataAdapter da;
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Fournisseur";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["IDfourn"]);
            }
            conn.Close();



            //SqlDataAdapter da;
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Produit";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["IDproduit"]);
            }

            conn.Close();
            ///////////


        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("etes vous sur de supprimer cette commande?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete From Commande where IDachat ='" + textBox9.Text + "' ;";
                cmd.ExecuteNonQuery();
                conn.Close();
                //displaydata();
                MessageBox.Show("Une Commande a ete supprimer ");
                textBox9.Text = " ";
                textBox1.Text = " ";
                textBox3.Text = " ";
                comboBox2.Text = " ";
                textBox5.Text = " ";
                comboBox1.Text = " ";
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }
}
