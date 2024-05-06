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
    public partial class Withdraw : Form
    {
        public Withdraw()
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
        private void Withdraw_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            banking_dbEntities1 context = new banking_dbEntities1();
            decimal b = Convert.ToDecimal(txtAccNo.Text);
            var item = (from u in context.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();
            txtName.Text = item.Name;
            txtOldBalance.Text=Convert.ToString(item.balance);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            banking_dbEntities1 context = new banking_dbEntities1();
            newAccount acc = new newAccount();
            deposit dp = new deposit();
            dp.Date = lblDate.Text;
            dp.AccountNo = Convert.ToDecimal(txtAccNo.Text);
            dp.Name = txtName.Text;
            dp.OldBalance = Convert.ToDecimal(txtOldBalance.Text);
            dp.Mode = comboBox1.SelectedItem.ToString();
            dp.DipAmount = Convert.ToDecimal(txtDepositAmount.Text);
            context.deposits.Add(dp);
            //context.SaveChanges();
            decimal b = Convert.ToDecimal(txtAccNo.Text);
            var item = (from u in context.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();
            item.balance = item.balance + Convert.ToDecimal(txtDepositAmount.Text);
            //context.SaveChanges();
            MessageBox.Show("Deposit money Successfully");
        }
    }
}
