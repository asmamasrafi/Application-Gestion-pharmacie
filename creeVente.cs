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
    public partial class creeVente : Form
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
        public creeVente()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Vente_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'bDpharmacieDataSet.Vente'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            // this.venteTableAdapter.Fill(this.bDpharmacieDataSet.Vente);
            // TODO: cette ligne de code charge les données dans la table 'bDpharmacieDataSet.Produit'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //this.produitTableAdapter.Fill(this.bDpharmacieDataSet.Produit);


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
            ///////////
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Produit";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxcherenomprod.Items.Add(dr["designation"]);
            }
            conn.Close();

          
            ///
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM   Utilisateur";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["IDuti"]);
            }
            conn.Close();
            /////
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Client";

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox3.Items.Add(dr["IDclient"]);
            }
            conn.Close();
            LoadRecords1();
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));

        }
   

        private void LoadRecords1()
        {

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Produit ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void btnacceuil_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            this.Hide();
            obj.Show();
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

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void btnvente_Click(object sender, EventArgs e)
        {
            Vente form1 = new Vente ();
            form1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

            paiement f1=new paiement();
            f1.label18.Text = comboBox2.Text;
           // f1.label19.Text = dateTimePicker2.Text;
            f1.label13.Text = this.label13.Text;
            f1.label14.Text = this.label14.Text;
            f1.textBox2.Text = this.textBox4.Text;
            f1.label20.Text = this.textBox2.Text;
            f1.Show();
            this.Hide();

            conn.Open();
            SqlCommand cd = new SqlCommand("insert  into Vente (IDvente,IDclient,IDproduit,designation,qte,prixUnit,montantBrut,remise,montantNet,dateVente,IDutilisateur) values(@IDvente,@IDclient,@IDproduit,@designation,@qte,@prixUnit,@montantBrut,@remise,@montantNet,@dateVente,@IDutilisateur) ;", conn);
            cd.Parameters.AddWithValue("@IDvente", int.Parse(textBox4.Text));
            cd.Parameters.AddWithValue("@IDclient", int.Parse(comboBox3.Text));
            cd.Parameters.AddWithValue("@IDproduit",textBox1.Text);
            cd.Parameters.AddWithValue("@designation", textBox2.Text);
            cd.Parameters.AddWithValue("@qte", int.Parse(textBox5.Text));
            cd.Parameters.AddWithValue("@montantBrut",Decimal.Parse(textBox7.Text));
            cd.Parameters.AddWithValue("@remise", comboBox1.Text);
            cd.Parameters.AddWithValue("@prixUnit", Decimal.Parse(textBox3.Text));
            cd.Parameters.AddWithValue("@montantNet", Decimal.Parse(textBox6.Text));
            cd.Parameters.AddWithValue("@IDutilisateur",int.Parse(comboBox2.Text));
            cd.Parameters.AddWithValue("@dateVente",DateTime.Parse(dateTimePicker2.Text));
            cd.ExecuteNonQuery();
            MessageBox.Show("Un nouvelle vente a ete inserer ");
            conn.Close();


            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox3.Text = "";


            /* string idvente = textBox4.Text;
             string cli = comboBox3.SelectedItem.ToString();
            // int idc = Convert.ToInt32(cli);
             string idprod = textBox3.Text;
             decimal prix = decimal.Parse(textBox3.Text);
             string des = textBox1.Text;
             DateTime datevente = Convert.ToDateTime(dateTimePicker2.Text);
             string remise = comboBox1.SelectedItem.ToString();
             int qte = Convert.ToInt32(textBox5.Text);
             decimal mtnet= Convert.ToDecimal(textBox6.Text);
             decimal mtbrut = Convert.ToDecimal(textBox7.Text);
             string idut = comboBox2.SelectedItem.ToString();
             //int  idutilisa = Convert.ToInt32(idut);


             conn.Open();
             cmd =  new SqlCommand("Exec VenteAjoute'" + idvente + "','" + cli + "','" + idprod + "','" + des + "','" + qte + "','" + prix + "','" + mtbrut + "','" +remise + "','" + mtnet + "','" + datevente + "','" + idut + "'",conn);
             cmd.ExecuteNonQuery();
             MessageBox.Show("Une  nouvelle Vente  A ete ajouter ");
             conn.Close();
                 // LoadRecords();

                 textBox9.Text = "";
                 textBox1.Text = "";
                 textBox2.Text = "";
                 comboBox1.Text = "";
                 textBox6.Text = "";
                 textBox5.Text = "";
            */

        }

        private void btnpaiement_Click(object sender, EventArgs e)
        {
            paiement obj = new paiement();
            this.Hide();
            obj.Show();
        }

       
        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void btnachat_Click(object sender, EventArgs e)
        {
            achat f1 = new achat();
            this.Close();
            f1.Show();
        }

        private void btnfourniseur_Click(object sender, EventArgs e)
        {
            Fournisseur form1 = new Fournisseur();
            form1.Show();
            this.Hide();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            textBox3.Text= string.Empty;
            textBox2.Text= string.Empty;
            textBox1.Text = string.Empty;
            comboBox1.Text = string.Empty;   
            textBox5.Text= string.Empty;
            textBox6.Text= string.Empty;
            textBox7.Text= string.Empty;
            comboBox2.Text= string.Empty;
            comboBoxcherenomprod.Text= string.Empty;
            dateTimePicker2.Text= string.Empty;
            comboBoxrecherchIDprod.Text= string.Empty;  
        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            Stock obj = new Stock();
            this.Hide();
            obj.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
          
            label14.Text = textBox5.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var mt = float.Parse(textBox7.Text);
            if (comboBox1.SelectedIndex == 0)
            {
                if (mt < 200)
                    textBox6.Text = mt.ToString();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (mt < 200)
                    MessageBox.Show("Remise  refusé. le Mantant Brut est inférieur a 200 dh");
                else
                    textBox6.Text = (mt - (mt * 5 / 100)).ToString();

            }
            if (comboBox1.SelectedIndex == 2)
            {
                if (mt < 400)
                    MessageBox.Show("Remise  refusé. le Mantant Brut est inférieur a 400 dh,essayer la remise de 5%");
                else
                    textBox6.Text = (mt - (mt * 7 / 100)).ToString();

            }
            if (comboBox1.SelectedIndex == 3)
            {
                if (mt < 700)
                    MessageBox.Show("Remise  refusé. le Mantant Brut est inférieur a 700 dh,essayer la remise de 5% ou 7%");
                else
                    textBox6.Text = (mt - (mt * 10 / 100)).ToString();

            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label13.Text = textBox6.Text;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Today;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox7.Text = (float.Parse(textBox3.Text) * float.Parse(textBox5.Text)).ToString();
        }
    };
}
