using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GESTIONpharmacie
{
    public partial class newprod : Form
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
        public newprod()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("etes vous sur de supprimmer ce medicament?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();

                SqlCommand cd = new SqlCommand("delete from Stock where IDprod=@Produitid ;", conn);
                cd.Parameters.AddWithValue("@Produitid", textBox1.Text);
                cd.ExecuteNonQuery();
                 cd = new SqlCommand("delete from Facture where IDproduit=@Produitid ;", conn);
                cd.Parameters.AddWithValue("@Produitid", textBox1.Text);
                cd.ExecuteNonQuery();
                cd = new SqlCommand("delete from  where IDproduit=@Produitid ;", conn);
                cd.Parameters.AddWithValue("@Produitid", textBox1.Text);
                cd.ExecuteNonQuery();
                cd = new SqlCommand("delete from Facture where IDproduit=@Produitid ;", conn);
                cd.Parameters.AddWithValue("@Produitid", textBox1.Text);
                cd.ExecuteNonQuery();

                cd = new SqlCommand("delete from Produit where IDproduit=@Produitid ;", conn);
                cd.Parameters.AddWithValue("@Produitid", textBox1.Text);
                cd.ExecuteNonQuery();
                MessageBox.Show("Un Produit a ete supprimer");
                conn.Close();


                textBox8.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                comboBoxcatego.Text = "";
                comboBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                comboBox3.Text = "";
            }

        }


        private void newprod_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cd = new SqlCommand("insert  into Produit (IDProduit,designation,forme,prixUn,dateExp,status,codeBarre,Categorie) values(@Produitid,@designation,@forme" +
                ",@prixUn,@dateExp,@status,@codeBarre,@Categorie) ;", conn);
            cd.Parameters.AddWithValue("@Produitid", textBox1.Text);
            cd.Parameters.AddWithValue("@designation", textBox2.Text);
            cd.Parameters.AddWithValue("@forme", comboBox3.Text);
            cd.Parameters.AddWithValue("@prixUn", Decimal.Parse(textBox3.Text));
            cd.Parameters.AddWithValue("@dateExp", dateTimePicker1.Text);
            cd.Parameters.AddWithValue("@status", comboBox2.Text);
            cd.Parameters.AddWithValue("@codeBarre", textBox5.Text);
            cd.Parameters.AddWithValue("@Categorie", comboBoxcatego.Text);
            cd.ExecuteNonQuery();
            cd = new SqlCommand("insert into Stock (IDprod,Qte_stck,pph,ppv,QteDisp) values(@Produitid,@Qte_stck,@pph,@ppv,@QteDisp)", conn);
            cd.Parameters.AddWithValue("@Produitid", textBox1.Text);
            cd.Parameters.AddWithValue("@Qte_stck", int.Parse(textBox6.Text));
            cd.Parameters.AddWithValue("@pph", Decimal.Parse(textBox8.Text));
            cd.Parameters.AddWithValue("@ppv", Decimal.Parse(textBox7.Text));
            cd.Parameters.AddWithValue("@QteDisp", int.Parse(textBox4.Text));
            cd.ExecuteNonQuery();
            MessageBox.Show("Un nouveau Produit a ete inserer ");
            conn.Close();

            
            textBox8.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBoxcatego.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cd = new SqlCommand("update Produit set designation=@designation,forme=@forme,prixUn=@prixUn,dateExp=@dateExp,status=@status,codeBarre=@codeBarre," +
                "Categorie=@Categorie where IDproduit=@Produitid ;",conn);
            cd.Parameters.AddWithValue("@Produitid",textBox1.Text);
            cd.Parameters.AddWithValue("@designation",textBox2.Text);
            cd.Parameters.AddWithValue("@forme",comboBox3.Text);
            cd.Parameters.AddWithValue("@prixUn",Decimal.Parse(textBox3.Text));
            cd.Parameters.AddWithValue("@dateExp",dateTimePicker1.Text);
            cd.Parameters.AddWithValue("@status",comboBox2.Text);
            cd.Parameters.AddWithValue("@codeBarre",textBox5.Text);
            cd.Parameters.AddWithValue("@Categorie",comboBoxcatego.Text);
            cd.ExecuteNonQuery();
            
            cmd = new SqlCommand("update Stock set Qte_stck=@Qte_stck,pph=@pph,ppv=@ppv,QteDisp=@QteDisp where  IDprod=@Produitid", conn);
            cmd.Parameters.AddWithValue("@Produitid", textBox1.Text);
            cmd.Parameters.AddWithValue("@Qte_stck", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@pph", Decimal.Parse(textBox8.Text));
            cmd.Parameters.AddWithValue("@ppv", Decimal.Parse(textBox7.Text));
            cmd.Parameters.AddWithValue("@QteDisp", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Un Produit a ete modifier ");
            textBox8.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBoxcatego.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox3.Text = "";
            conn.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
            /* medicament obj= new medicament();
             this.Hide();
             obj.Show();*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty; ;
          textBox2.Text = string.Empty; ;
            comboBoxcatego.Text = string.Empty; ;
             comboBox3.Text = string.Empty; ;
         textBox3.Text = string.Empty; 
            textBox5.Text = string.Empty; ;
             dateTimePicker1.Text = string.Empty; ;
             comboBox2.Text = string.Empty; ;
           textBox6.Text = string.Empty; ;
           textBox8.Text = string.Empty; ;
             textBox7.Text = string.Empty; ;
          textBox4.Text = string.Empty; ;
            textBox3.Text = string.Empty;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

