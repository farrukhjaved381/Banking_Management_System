using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApplication
{
    public partial class balanceForm : Form
    {
        public balanceForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            banking_dbEntities1 dbEntities1 = new banking_dbEntities1();
            decimal b = Convert.ToDecimal(txtAccNo.Text);
            var item = (from u in dbEntities1.debits
                        where u.AccountNo == b
                        select u);
            dataGridView1.DataSource = item.ToList();
            var item1 = (from u in dbEntities1.deposits
                        where u.AccountNo == b
                        select u);
            dataGridView2.DataSource = item1.ToList();
        }

        private void balanceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
