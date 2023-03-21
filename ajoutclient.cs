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
    public partial class ajoutclient : Form
    { SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-I3NSLNF;Initial Catalog=BDpharmacie;Integrated Security=True");
        //SqlCommand cmd;
       // SqlDataReader dr;
       // SqlDataAdapter da;


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
          int nLeft,
           int nTop,
          int nRight,
          int nBottom,
          int nWidthEllipse,
          int nHeightEllipse);
        public ajoutclient()
        {
            InitializeComponent();
        }

        private void ajoutclient_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("etes vous sur de supprimmer un nouveau client ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete From facture where IDvente = (Select IDvente  From Vente  where  IDclient ='" + textBox9.Text + "');Delete from Vente where  IDclient='" + textBox9.Text + "';Delete From Client where IDclient ='" + textBox9.Text + "' ;";
                cmd.ExecuteNonQuery();
                conn.Close();
                //displaydata();
                MessageBox.Show("Un Client a ete supprimer ");
               
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("etes vous sur d'ajouter un nouveau client ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Client(nom,type,solde,adresse ,telephone)values ('"  + textBox1.Text + "','" + comboBox1.Text + "','" + double.Parse(textBox2.Text) + "','" + textBox6.Text + "','" + textBox5.Text + "') ";
                cmd.ExecuteNonQuery();
                conn.Close();
               // LoadRecords();
                MessageBox.Show("Un nouveau Client a ete inserer ");
                textBox9.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                textBox6.Text = "";
                textBox5.Text = "";
            }

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            textBox9.Text = String.Empty;
            textBox1.Text = String.Empty;
          comboBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox5.Text = String.Empty;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox9.Text);
            string nom = textBox1.Text;
            string adresse = textBox6.Text;
            string telephone = textBox5.Text;
            string solde = textBox2.Text;
            string type = comboBox1.Text;
           


            if (MessageBox.Show("etes vous sur d'appliquer ces modifications?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " Update  Client Set nom='" + nom + "',adresse='" + adresse + "',telephone='" + telephone + "',solde ='" + solde + "',type='" + type +"' where IDclient='" + id + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                //displaydata();
                MessageBox.Show("Un Client a ete modifier ");
                textBox9.Text = " ";
                textBox1.Text = " ";
                textBox6.Text = " ";
                textBox2.Text = " ";
                textBox5.Text = " ";
                comboBox1.Text = " ";

          
            }
            

        }
    }
    }

