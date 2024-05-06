using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApplication
{
    public partial class newAccount : Form
    {
        string gender = string.Empty;
        string m_status = string.Empty;
        decimal no;
        banking_dbEntities1 BSE;
        MemoryStream ms;
      
        public newAccount()
        {
            InitializeComponent();
            loaddate();
            loadaccount();
            loadstate();
        }

        private void loadstate()
        {
            //throw new NotImplementedException();
            comboBox1.Items.Add("Punjab");
            comboBox1.Items.Add("Sindh");
            comboBox1.Items.Add("KPK");
            comboBox1.Items.Add("Balochistan");
            comboBox1.Items.Add("Azad Jammu & Kashmir");
            comboBox1.Items.Add("Islamabad");
        }

        private void loadaccount()
        {
            BSE = new banking_dbEntities1();
            var item = BSE.userAccounts.ToArray();
            no = item.LastOrDefault().Account_No + 1;
            accnotxt.Text = Convert.ToString(no);
            //var item = BSE.user
        }

        private void loaddate()
        {
            //throw new NotImplementedException();
            datelbl.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void newAccount_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maleRadiobtn.Checked)
            {
                gender = "male";
            }
            else if (femaleRadiobtn.Checked)
            {
                gender = "female";
            }else if (otherGenderRadiobtn.Checked)
            {
                gender = "other";
            }
            if (marriedRadio.Checked)
            {
                m_status = "married";
            }
            else if (unmarriedRadio.Checked)
            {
                m_status = "Un-Married";
            }
            BSE = new banking_dbEntities1();
            userAccount acc = new userAccount();
            acc.Account_No = Convert.ToDecimal(accnotxt.Text);
            acc.Name=txtName.Text;
            acc.DOB=dateTimePicker1.Value.ToString();
            acc.PhoneNo=txtPhNo.Text;
            acc.Address=txtAdd.Text;
            acc.District = txtDist.Text;
            acc.State = comboBox1.SelectedItem.ToString();
            acc.Gender=gender;
            acc.marital_status = m_status;
            acc.Mother_Name = txtMotherName.Text;
            acc.Father_Name = txtFatherName.Text;
            acc.balance = Convert.ToDecimal(txtBalance.Text);
            acc.Date = datelbl.Text;
            acc.Picture = ms.ToArray();
            BSE.userAccounts.Add(acc);
            BSE.SaveChanges();
            MessageBox.Show("Record Inserted Successfully");
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(dlg.FileName);
                pictureBox1.Image = img;
                ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maleRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPhNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtDist_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void datelbl_Click(object sender, EventArgs e)
        {

        }
    }
}
