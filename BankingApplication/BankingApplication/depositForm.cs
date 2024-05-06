using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApplication
{
    public partial class depositForm : Form
    {
        public depositForm()
        {
            InitializeComponent();
            loaddate();
            loadmode();
        }
        private void loaddate()
        {
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
        private void loadmode()
        {
            //throw new NotImplementedException();
            comboBox1.Items.Add("Cash");
            comboBox1.Items.Add("Cheque");
        }

        private void depositForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            banking_dbEntities1 dbe = new banking_dbEntities1();
            decimal b = Convert.ToDecimal(txtAccNo.Text);
            var item = (from u in dbe.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();
            txtName.Text = item.Name;
            txtOldBalance.Text = Convert.ToString(item.balance);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            banking_dbEntities1 dbe = new banking_dbEntities1();
            newAccount nacc = new newAccount();
            debit dp = new debit();
            dp.Date = lblDate.Text;
            dp.AccountNo = Convert.ToDecimal(txtAccNo.Text);
            dp.Name = txtName.Text;
            dp.OldBalance = Convert.ToDecimal(txtOldBalance.Text);
            dp.Mode = comboBox1.SelectedItem.ToString();
            dp.DebAmount = Convert.ToDecimal(txtDepositAmount.Text);
            dbe.debits.Add(dp);
            dbe.SaveChanges();
            decimal b = Convert.ToDecimal(txtAccNo.Text);
            var item = (from u in dbe.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();
            item.balance = item.balance - Convert.ToDecimal(txtDepositAmount.Text);
            dbe.SaveChanges();
            MessageBox.Show("Withdraw money Successfully");
        }
    }
}
