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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GESTIONpharmacie
{
    public partial class ajouterfourniseur : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I3NSLNF;Initial Catalog=BDpharmacie;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        public ajouterfourniseur()
        {
            InitializeComponent();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("etes vous sur d'ajouter un nouveau fournisseur ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Fournisseur(IDfourn,Nom,Telephone,ville ,Email)values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox5.Text + "') ";
                cmd.ExecuteNonQuery();
                conn.Close();
                // LoadRecords();
                MessageBox.Show("Un nouveau Client a ete inserer ");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox5.Text = "";
            }

        }

        private void ajouterfourniseur_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            int id = int.Parse(textBox1.Text);
            string nom = textBox2.Text;
            string ville = textBox6.Text;
            string telephone = textBox4.Text;
            string Email = textBox5.Text;




            if (MessageBox.Show("etes vous sur d'appliquer ces modifications?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " Update  Fournisseur Set Nom='" + nom + "',Telephone='" + telephone + "',ville ='" + ville + "',Email='" + Email + "' where IDfourn = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                //displaydata();
                MessageBox.Show("Un Fournisseur a ete modifier ");

                textBox1.Text = " ";
                textBox6.Text = " ";
                textBox2.Text = " ";
                textBox5.Text = " ";
                
                textBox4.Text = " "; 
                textBox5.Text = " "; 

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("etes vous sur de supprimmer un nouveau Fournisseur ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Fournisseur where  IDfourn='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                //displaydata();
                MessageBox.Show("Un Fournisseur a ete supprimer ");

            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }
}