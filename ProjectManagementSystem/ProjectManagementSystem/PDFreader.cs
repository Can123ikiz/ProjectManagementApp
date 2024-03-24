using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    public partial class PDFreader : Form
    {
        addProject frm;
        public PDFreader(addProject frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        Form2 form2;
        private void PDFreader_Load(object sender, EventArgs e)
        {
            int index = frm.lb_dosya.SelectedIndex;
            string a = frm.lb_dosya.Items[index].ToString();
            string yeni="";
            for(int i = 0; i < a.Length-4; i++)
            {
                yeni += a[i];
            }
            axAcroPDF1.LoadFile(frm.lb_dosya.Items[index].ToString());
        }
    }
}
