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
using System.Data.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GESTIONpharmacie
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I3NSLNF;Initial Catalog=BDpharmacie;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        { 
          
           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Utilisateur";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxNOM.Items.Add(dr["nom"]);
            }
            conn.Close();
        }
            

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nom = comboBoxNOM.Text;
            string mot_passe = textBOXmotpasse.Text;
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Utilisateur where nom='" + comboBoxNOM.Text + "' AND mot_passe='" + textBOXmotpasse.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form2 form2 = new Form2();
                form2.Show();

                this.Hide();
           
            }
            else
            {
                MessageBox.Show("le nom d'utilisateur ou le mot de passe est incorectte essayer encors");
            }
            conn.Close();

        }
    


        private void comboLOGIN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBOXmotpasse.PasswordChar = '\0';

            }
            else
            {
                textBOXmotpasse.PasswordChar = '•';
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBoxNOM.Text = "";
            textBOXmotpasse.Text = "";
        }
    }
}
