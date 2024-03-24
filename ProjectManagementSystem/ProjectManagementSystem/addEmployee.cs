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

namespace ProjectManagementSystem
{
    public partial class addEmployee : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        Form2 frm2;
        public addEmployee(Form2 frm2)
        {
            this.frm2 = frm2;
            InitializeComponent();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            string file = "";
            string file1 = Path.GetFileName(openFileDialog.FileName);
            for (int i = 0; i < file1.Length-4; i++)
            {
                file += file1[i];
            }
            Employee emp = new Employee(tb_fullname.Text,tb_firtsname.Text,tb_middlename.Text,tb_lastname.Text,dtp_birthday.Value,tb_mail.Text,rtb_address.Text, mtb_number.Text, file);
            frm2.Emps.Add(emp);
            this.Hide();
        }

        private void addEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
        private void btn_fotoekle_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            
        }
        private void addEmployee_Load(object sender, EventArgs e)
        {
            dtp_birthday.MaxDate = DateTime.Today;
        }
    }
}
