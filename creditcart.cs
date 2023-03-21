using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GESTIONpharmacie
{
    public partial class creditcart : Form
    {
        public creditcart()
        {
            InitializeComponent();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }
        private void InitializeComboBox()
        {
            DataTable typecard = new DataTable();
            typecard.Columns.Add("id");
            typecard.Columns.Add("name");

            typecard.Rows.Add("1", "Visa");
            typecard.Rows.Add("2", "MasterCard");
            typecard.Rows.Add("3", "American Express");
            typecard.Rows.Add("4", "Unknown");

            comboBox1.DataSource = typecard;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string cardType = GetCardType(textBox1.Text);
            comboBox1.Text = cardType;
        }
        public string GetCardType(string cardNumber)
        {
            // Visa
            if (cardNumber.StartsWith("4"))
            {
                return "Visa";
            }
            // MasterCard
            else if (cardNumber.StartsWith("51") || cardNumber.StartsWith("52") ||
                cardNumber.StartsWith("53") || cardNumber.StartsWith("54") || cardNumber.StartsWith("55"))
            {
                return "MasterCard";
            }
            // American Express
            else if (cardNumber.StartsWith("34") || cardNumber.StartsWith("37"))
            {
                return "American Express";
            }
            // Unknown
            else
            {
                return "Unknown";
            }
        }


        private static bool CheckifValid(String input)
        {
            int[] cartenum = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                cartenum[i] = (int)(input[i] - '0');

            }
            for (int i = cartenum.Length - 2; i >= 0; i = i - 2)
            {
                int valeur = cartenum[i];
                valeur = valeur * 2;
                if (valeur > 9)
                {
                    valeur = (valeur % 10) + 1;

                }
                cartenum[i] = valeur;

            }
            //calculer total des digits
            int total = 0;
            for (int i = 0; i < cartenum.Length; i++)
            {
                total += cartenum[i];
            }
            if (total % 10 == 0)
            {
                return true;
            }
            MessageBox.Show(input + "nombre de carte non valide");
            return false;

        }

        static bool IsExpirationDateValid(string cardNumber, int month, int year)
        {
            string[] expirationDateParts = cardNumber.Split('/');


            if (expirationDateParts.Length != 2)
            {
                MessageBox.Show(cardNumber + " la date d'expiration n'est pas dans la bonne forme , il faut qu'il est comme  'MM/YYYY' ");
                return false;
            }
            if (!int.TryParse(expirationDateParts[0], out month) || month < 1 || month > 12)
            {
                MessageBox.Show(cardNumber + " le mois que vous avez choisi n'existe pas");
                return false;
            }
            if (!int.TryParse(expirationDateParts[1], out year) || year < 1)
            {
                MessageBox.Show("changer l'annees que vous avez choisir");
                return false;
            }
            DateTime currentDate = DateTime.Now;
            if (year < currentDate.Year || (year == currentDate.Year && month < currentDate.Month))
            {
                MessageBox.Show("your card has expired back in " + year);
                return false;
            }

            return true;

        }
        bool IsCVVValid(string cvv)
        {

            if (cvv.Length != 3 && cvv.Length != 4)
            {
                return false;
            }


            foreach (char c in cvv)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show(cvv + "entrer seulement des nombres  ");
                    return false;

                }
            }

            return true;
        }
        private void button_WOC1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            String expirationDate = textBox5.Text;
            string[] dateParts = expirationDate.Split('/');
            int month = int.Parse(dateParts[0]);
            int year = int.Parse(dateParts[1]);
            string cvv = textBox2.Text;
            if (IsCVVValid(cvv) == true && IsExpirationDateValid(expirationDate, month, year) == true && CheckifValid(input) == true)
            {
                MessageBox.Show("informations enregistrer parfaitment");               
                paiement f1 = new paiement();
                f1.label19.Text = "par carte bancaire";
                Application.Exit();
            }
            else
            {
                

            }
         
        }

        private void creditcart_Load(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
