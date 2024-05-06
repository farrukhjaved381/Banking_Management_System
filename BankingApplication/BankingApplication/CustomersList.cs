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
    public partial class CustomersList : Form
    {
        public CustomersList()
        {
            InitializeComponent();
            bindgrid();
        }

        private void bindgrid()
        {
           // throw new NotImplementedException();
           banking_dbEntities1 bs = new banking_dbEntities1();
            var item = bs.userAccounts.ToList();
            dataGridView1.DataSource = item;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
