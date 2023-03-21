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
    public partial class ajoutercomLIV : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I3NSLNF;Initial Catalog=BDpharmacie;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        public ajoutercomLIV()
        {
            InitializeComponent();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ajoutercomLIV_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            SqlDataReader dr;
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Fournisseur  ";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["IDfourn"]);
            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into CommandeLivre(num_liv,IDfourn,Nomfourn,Nomprod,PrixUn,Qte,date_liv,etat)values ('" + textBox9.Text + "','" + Convert.ToInt16(comboBox2.Text)+ "','" + textBox5.Text + "','" + textBox4.Text + "','" + Convert.ToDecimal(textBox2.Text) + "','" + textBox1.Text + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "','" + comboBox1.Text + "') ";
            cmd.ExecuteNonQuery();
            conn.Close();
            // LoadRecords();
            MessageBox.Show("Une nouvelle Commande a ete enregistrer ");
            textBox1.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox9.Text = "";
            comboBox2.Text = "";


        }

        private void button5_Click(object sender, EventArgs e)
        {
            string idaliv = textBox9.Text;
            string idfourn = comboBox2.Text;
            string nomfourn = textBox5.Text;
            string etat = comboBox1.Text;
            string nomprod = textBox4.Text;
            decimal prix = Convert.ToDecimal(textBox2.Text);
            string qte = textBox1.Text;
            DateTime dtliv = Convert.ToDateTime(dateTimePicker1.Text);



            if (MessageBox.Show("etes vous sur d'appliquer ces modifications?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " Update  CommandeLivre Set num_liv='" + idaliv + "',IDfourn='" + idfourn + "',Nomfourn='" + nomfourn + "',Nomprod ='" + nomprod + "',PrixUn='" + prix + "' , Qte='" + qte + "',date_liv='" + dtliv + "',etat='" + etat + "' where num_liv='" + idaliv + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                //displaydata();
                MessageBox.Show("Une Commande  a ete modifier ");
                textBox9.Text = " ";
                textBox1.Text = " ";
              comboBox2.Text = " ";
                textBox2.Text = " ";
                textBox5.Text = " ";
                comboBox1.Text = " ";
                textBox4.Text = " ";

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            SqlDataReader dr;
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Fournisseur where IDfourn= '" + comboBox2.SelectedItem.ToString() + "'";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox5.Text = dr["Nom"].ToString();
            }
            conn.Close();
        }
    }
}
