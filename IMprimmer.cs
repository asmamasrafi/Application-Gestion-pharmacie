using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GESTIONpharmacie
{
    public partial class IMprimmer : Form
    {
        public string date,idvente,total,nprod,qte,prixun,mode;

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
        }

        public IMprimmer()
        {
            InitializeComponent();
            date = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
        Bitmap memory;
       private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panelPrint = pnl;
            getprintera(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument_printpage);
            printPreviewDialog1.ShowDialog();

        }

        private void panelPrint_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void getprintera(Panel pnl)
        {
            memory = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memory, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

       private void PrintDocument_printpage(object sender, PrintPageEventArgs e)
        {
            Rectangle PAGE = e.PageBounds;
            e.Graphics.DrawImage(memory, (PAGE.Width / 2) - (this.panelPrint.Width / 2), this.panelPrint.Location.Y);

        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            
            this.Close();  
        }

        private void IMprimmer_Load(object sender, EventArgs e)
        {
            
            label8.Text = idvente;
            label10.Text = nprod;
            label16.Text = qte;
            label9.Text = DateTime.Now.ToString();
            label18.Text = total;
            label19.Text = mode;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Print(panelPrint);
           // printPreviewDialog1.ShowDialog();
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
           
        }
    }
}
