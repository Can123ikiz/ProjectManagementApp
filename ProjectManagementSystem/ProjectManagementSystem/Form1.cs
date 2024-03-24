using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ProjectManagementSystem
{
    public partial class Form1 : Form
    {  
        public Form1()
        {
            InitializeComponent();
            Kullanıcı user = new Kullanıcı("can", "1234");
            Kullanıcı user1 = new Kullanıcı("cann", "1234");
            Kullanıcı user2 = new Kullanıcı("akif", "1234");
            list.Add(user);
            list.Add(user1);
            list.Add(user2);
            
        }
        List <Kullanıcı> list = new List<Kullanıcı> ();

        private void btn_giris_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string adi = textBox1.Text;
            string sifresi = textBox2.Text;
            foreach (var item in list)
            {
                if(item.kullaniciAdi.Equals(adi) && item.sifre.Equals(sifresi))
                {
                    flag = true; 
                    break;
                }
            }
            if (flag)
            {
                Form2 form = new Form2();
                this.Hide();
                form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.Close();
            this.Dispose();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            this.Close();
            this.Dispose();
        }
    }
}
