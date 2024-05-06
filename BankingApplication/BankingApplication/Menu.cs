using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApplication
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       

        private void newAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            newAccount newacc = new newAccount();
            newacc.MdiParent = this;
            newacc.Show();
        }

        private void updateSearchCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateForm upd = new updateForm();
            upd.MdiParent = this;
            upd.Show();
        }

        private void allCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersList aCf = new CustomersList();
            aCf.MdiParent = this;
            aCf.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Withdraw w = new Withdraw();
            w.MdiParent = this;
            w.Show();
        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            depositForm depof = new depositForm();
            depof.MdiParent = this;
            depof.Show();
        }

     

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            balanceForm bf = new balanceForm();
            bf.MdiParent = this;
            bf.Show();
        }

       

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
