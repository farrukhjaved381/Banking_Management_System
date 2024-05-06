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
    public partial class updateForm : Form
    {
        banking_dbEntities1 dbEntities1;
        MemoryStream ms;
        BindingList<userAccount> bi;
        public updateForm()
        {
            InitializeComponent();
        }

        private void updateForm_Load(object sender, EventArgs e)
        {

        }

        private void txtMotherName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bi = new BindingList<userAccount>();
            dbEntities1 = new banking_dbEntities1();
            decimal accno = Convert.ToDecimal(accnotxt.Text);
            var item = dbEntities1.userAccounts.Where(a => a.Account_No == accno);
            foreach(var item1 in item)
            {
                bi.Add(item1);
            }
            dataGridView1.DataSource = bi;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bi = new BindingList<userAccount>();
            dbEntities1 = new banking_dbEntities1();
            decimal accno = Convert.ToDecimal(accnotxt.Text);
            var item = dbEntities1.userAccounts.Where(a => a.Account_No == accno);
            foreach (var item1 in item)
            {
                bi.Add(item1);
            }
            dataGridView1.DataSource = bi;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dbEntities1 = new banking_dbEntities1();
            decimal accno = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            var item = dbEntities1.userAccounts.Where(a => a.Account_No == accno).FirstOrDefault();
            accnotxt.Text = item.Account_No.ToString();
            txtName.Text = item.Name;
            txtMotherName.Text = item.Mother_Name;
            txtFatherName.Text = item.Father_Name;
            txtPhNo.Text = item.PhoneNo;
            txtAdd.Text = item.Address;
            byte[] img = item.Picture;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            txtDist.Text = item.District;
            txtState.Text = item.State;
            if (item.Gender == "male")
            {
                maleRadiobtn.Checked = true;
            }
            else if (item.Gender == "female")
            {
                femaleRadiobtn.Checked = true;
            }
            else if (item.Gender == "other")
            {
                otherGenderRadiobtn.Checked = true;
            }
            if (item.marital_status == "married")
            {
                marriedRadio.Checked = true;
            }
            else if (item.marital_status == "Un-Married")
            {
                unmarriedRadio.Checked = true;
            }else if(item.marital_status == "other")
            {
                othersStatusRadio.Checked = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image=img;
                ms = new MemoryStream();
                img.Save(ms,img.RawFormat);
            }
        }

               private void button1_Click(object sender, EventArgs e)
        {
            dbEntities1 = new banking_dbEntities1();
            decimal accountno = Convert.ToDecimal(accnotxt.Text);
            userAccount user = dbEntities1.userAccounts.First(s=> s.Account_No.Equals(accountno));
            user.Account_No = Convert.ToDecimal(accnotxt.Text);
            user.Name = txtName.Text;
            user.Date = dateTimePicker1.Value.ToString();
            user.Mother_Name = txtMotherName.Text;
            user.Father_Name = txtFatherName.Text;
            user.PhoneNo = txtPhNo.Text;
            if (user.Gender == "male")
            {
                maleRadiobtn.Checked = true;
            }
            else if (user.Gender == "female")
            {
                femaleRadiobtn.Checked = true;
            }
            else if (user.Gender == "other")
            {
                otherGenderRadiobtn.Checked = true;
            }
            if (user.marital_status == "married")
            {
                marriedRadio.Checked = true;
            }
            else if (user.marital_status == "Un-Married")
            {
                unmarriedRadio.Checked = true;
            }
            else if (user.marital_status == "other")
            {
                othersStatusRadio.Checked = true;
            }
            Image img = pictureBox1.Image;
            if (img.RawFormat != null) {
            if(ms!=null)
                {
                    img.Save(ms,img.RawFormat);
                    user.Picture=ms.ToArray();
                }
            }
            user.Address = txtAdd.Text;
            user.District = txtDist.Text;
            user.State = txtState.Text;
            dbEntities1.SaveChanges();
            MessageBox.Show("Record Updated Successfully");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bi.RemoveAt(dataGridView1.SelectedRows[0].Index);
            dbEntities1 = new banking_dbEntities1();
            decimal a = Convert.ToDecimal(accnotxt.Text);
            userAccount acc = dbEntities1.userAccounts.First(s=>s.Account_No.Equals(a));
            dbEntities1.userAccounts.Remove(acc);
            dbEntities1.SaveChanges();
        }
    }
}
