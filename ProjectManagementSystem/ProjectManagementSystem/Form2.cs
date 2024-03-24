using System;
using System.Collections;
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
    
    public partial class Form2 : Form
    {
        //DataGridViewCellStyle d = new DataGridViewCellStyle();
        List<Employee> emps = new List<Employee>();
        internal List<Employee> Emps { get => emps; set => emps = value; }

        List<Project> projects = new List<Project>();
        internal List<Project> Projects { get => projects; set => projects = value; }
        DataGridViewCellStyle d = new DataGridViewCellStyle();
        public Form2()
        {
            InitializeComponent();
            d.Font = new Font(this.Font, this.Font.Style);
            
        }
        List<Panel> panelList= new List<Panel>();
        private void Form2_Load(object sender, EventArgs e)
        {
            panel_menu.Width = 70;
            panelProject.Left  -= 100;
            panelProject.Width += 100;
            panelEmployee.Left -= 100;
            panelEmployee.Width += 100;
            gb_projects.Width += 100;
            gb_milestones.Width +=100;
            gb_tasks.Width += 100;
            panelList.Add(panelProject);
            panelList.Add(panelEmployee);
            string st = "11/12/1968";

            pictureBox1.Image = Properties.Resources.clear;
            Employee emp = new Employee("Can İkiz", "Can", "", "İkiz", DateTime.Parse(st), "aaa", "izmir", "5419611732", "pp");
            Employee emp1 = new Employee("Akif Çelebi", "Akif", "", "Çelebi", DateTime.Parse(st), "akif.celebi@example.com", "susurluk", "5534638342", "akif");
            Emps.Add(emp);
            Emps.Add(emp1);


            Project proje1 = new Project();
            List<String> file1 = new List<String>();
            proje1.files = file1;
            Görev g1 = new Görev();
            Durum gdurum1 = new Durum();
            gdurum1.durum = "Onay Bekliyor";
            g1.görevTanimi = "görev1";
            g1.görevDurumu = gdurum1;
            g1.deadLine = DateTime.Parse("28/11/2022");

            Görev g11 = new Görev();
            Durum gdurum11 = new Durum();
            gdurum11.durum = "Onay Bekliyor";
            g11.görevTanimi = "görev11";
            g11.görevDurumu = gdurum11;
            g11.deadLine = DateTime.Parse("30/11/2022");
            List<KilometreTasi> kms1 = new List<KilometreTasi>();
            List<Görev> gs1 = new List<Görev>();
            gs1.Add(g1);
            gs1.Add(g11);
            Durum kmdurum = new Durum();
            kmdurum.durum = "Devam Ediyor";
            KilometreTasi km1 = new KilometreTasi("kilometretaşı1",kmdurum,gs1);
            kms1.Add(km1);
            proje1.kilometreTaslari = kms1;
                        
            
            Durum projeDurumu1 = new Durum();
            List<Employee> ekipList1 = new List<Employee>();
            

            Project proje2 = new Project();
            List<String> file2 = new List<String>();
            proje2.files = file2;
            Görev g2 = new Görev();
            Durum gdurum2 = new Durum();
            gdurum2.durum = "Onay Bekliyor";
            g2.görevTanimi = "görev2";
            g2.görevDurumu = gdurum2;
            g2.deadLine = DateTime.Parse("30/11/2022");

            Görev g22 = new Görev();
            Durum gdurum22 = new Durum();
            gdurum22.durum = "Onay Bekliyor";
            g22.görevTanimi = "görev22";
            g22.görevDurumu = gdurum22;
            g22.deadLine = DateTime.Parse("30/11/2022");
            List<KilometreTasi> kms2 = new List<KilometreTasi>();
            List<Görev> gs2 = new List<Görev>();
            gs2.Add(g2);
            gs2.Add(g22);
            Durum kmdurum2 = new Durum();
            kmdurum2.durum = "Devam Ediyor";
            KilometreTasi km2 = new KilometreTasi("kilometretaşı2", kmdurum2, gs2);
            kms2.Add(km2);
            proje2.kilometreTaslari = kms2;
            Employee projeYurutucu2 = new Employee();
            Durum projeDurumu2 = new Durum();
            List<Employee> ekipList2 = new List<Employee>();
            
            Project proje3 = new Project();
            List<String> file3 = new List<String>();
            proje3.files = file3;
            Görev g3 = new Görev();
            Durum gdurum3 = new Durum();
            gdurum3.durum = "Onay Bekliyor";
            g3.görevTanimi = "görev3";
            g3.görevDurumu = gdurum3;
            g3.deadLine = DateTime.Parse("30/11/2022");

            Görev g33 = new Görev();
            Durum gdurum33 = new Durum();
            gdurum33.durum = "Onay Bekliyor";
            g33.görevTanimi = "görev33";
            g33.görevDurumu = gdurum33;
            g33.deadLine = DateTime.Parse("30/11/2022");
            List<KilometreTasi> kms3 = new List<KilometreTasi>();
            List<Görev> gs3 = new List<Görev>();
            gs3.Add(g3);
            gs3.Add(g33);
            Durum kmdurum3 = new Durum();
            kmdurum3.durum = "Devam Ediyor";
            KilometreTasi km3 = new KilometreTasi("kilometretaşı3", kmdurum3, gs3);
            kms3.Add(km3);
            proje3.kilometreTaslari = kms3;
            Employee projeYurutucu3 = new Employee();
            Durum projeDurumu3 = new Durum();
            List<Employee> ekipList3 = new List<Employee>();

            //*******************************************************************

            proje1.adi = "Köprü";
            proje1.projeNo = "12253610";
            proje1.stratejikEtkisi = "Kritik";
            proje1.yürütücü = emp;

            proje1.kayitTarihi = DateTime.Parse("12/01/2022");
            
            proje1.tahminiBaslangic = DateTime.Parse("25/11/2022");
            proje1.tahminiBitis = DateTime.Parse("28/11/2022");
            
            projeDurumu1.durum = "Onay Bekliyor";
            proje1.projeDurumu = projeDurumu1;
            

            proje1.amac = "yok";
            proje1.problemTanimi = "Kendisi";
            proje1.kapsam = "Büyük";
            proje1.parasalGetirisi = 10000;
            proje1.parasalGetiriTipi = "Günlük";

            ekipList1.Add(emp);
            ekipList1.Add(emp1);
            proje1.projeEkibi = ekipList1;

            projects.Add(proje1);

            //****************************************************************

            proje2.adi = "Yol";
            proje2.projeNo = "123456";
            proje2.stratejikEtkisi = "Önemli";
            proje2.yürütücü = emp1;

            proje2.kayitTarihi = DateTime.Parse("15/01/2022");
            proje2.projeBaslangici = DateTime.Parse("30/11/2022");
            proje2.projeBitisi = DateTime.Parse("02/12/2022");
            proje2.tahminiBaslangic = DateTime.Parse("30/11/2022");
            proje2.tahminiBitis = DateTime.Parse("02/12/2022");
            proje2.projeDurumu = projeDurumu2;
            proje2.projeDurumu.durum = "Onay Bekliyor";

            proje2.amac = "yok1";
            proje2.problemTanimi = "Kendisi1";
            proje2.kapsam = "Orta";
            proje2.parasalGetirisi = 20000;
            proje2.parasalGetiriTipi = "Aylık";
            ekipList2.Add(emp);
            ekipList2.Add(emp1);
            proje2.projeEkibi= ekipList2;


            projects.Add(proje2);

            //*************************************************************

            proje3.adi = "Tünel";
            proje3.projeNo = "987654";
            proje3.stratejikEtkisi = "Genel";
            proje3.yürütücü = emp;

            proje3.kayitTarihi = DateTime.Parse("12/10/2022");
            proje3.projeBaslangici = DateTime.Parse("30/11/2022");
            proje3.projeBitisi = DateTime.Parse("02/12/2022");
            proje3.tahminiBaslangic = DateTime.Parse("30/11/2022");
            proje3.tahminiBitis = DateTime.Parse("02/12/2022");
            proje3.projeDurumu = projeDurumu3;

            projeDurumu3.durum = "Onay Bekliyor";
            

            proje3.amac = "yok2";
            proje3.problemTanimi = "Kendisi2";
            proje3.kapsam = "Küçük";
            proje3.parasalGetirisi = 30000;
            proje3.parasalGetiriTipi = "Yıllık";

            ekipList3.Add(emp);
            ekipList3.Add(emp1);
            proje3.projeEkibi = ekipList3;



            projects.Add(proje3);

            //****************************************************************************
            //proje gömme işleminin ardından anasayfadaki datagridview'e projenin ilgili alanları eklenir.

            dgv_projetcs.Rows.Add();
            dgv_projetcs.Rows[0].Cells[0].Value = proje1.adi;
            dgv_projetcs.Rows[0].Cells[1].Value = "PRJ" + proje1.projeNo;
            dgv_projetcs.Rows[0].Cells[2].Value = proje1.projeDurumu.durum;
            dgv_projetcs.Rows[0].Cells[3].Value = proje1.yürütücü.fullName;

            dgv_projetcs.Rows.Add();
            dgv_projetcs.Rows[1].Cells[0].Value = proje2.adi;
            dgv_projetcs.Rows[1].Cells[1].Value = "PRJ" + proje2.projeNo;
            dgv_projetcs.Rows[1].Cells[2].Value = proje2.projeDurumu.durum;
            dgv_projetcs.Rows[1].Cells[3].Value = proje2.yürütücü.fullName;

            dgv_projetcs.Rows.Add();
            dgv_projetcs.Rows[2].Cells[0].Value = proje3.adi;
            dgv_projetcs.Rows[2].Cells[1].Value = "PRJ" + proje3.projeNo;
            dgv_projetcs.Rows[2].Cells[2].Value = proje3.projeDurumu.durum;
            dgv_projetcs.Rows[2].Cells[3].Value = proje3.yürütücü.fullName;
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.Close();
            this.Dispose();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            this.Close();
            this.Dispose();
        }

        private void btn_emp_Click(object sender, EventArgs e)
        {
            panelEmployee.BringToFront();
        }

        private void btn_project_Click(object sender, EventArgs e)
        {
            panelProject.BringToFront();
        }

        private void btn_emp_MouseHover(object sender, EventArgs e)
        {
            panel_menu.Width = 170;
            if (buttonFlag)
            {
                return;
            }
            panelProject.Left += 100;
            panelProject.Width -= 100;
            panelEmployee.Left += 100;
            panelEmployee.Width -= 100;
            gb_projects.Width -= 100;
            gb_milestones.Width -= 100;
            gb_tasks.Width -=100;
            buttonFlag = true;

        }
        bool buttonFlag = false;

        private void Form2_MouseHover(object sender, EventArgs e)
        {
            panel_menu.Width = 70;
            if (buttonFlag)
            {
                panelProject.Left -= 100;
                panelProject.Width += 100;
                panelEmployee.Left -= 100;
                panelEmployee.Width += 100;
                gb_projects.Width += 100;
                gb_milestones.Width += 100;
                gb_tasks.Width += 100;
            }
            buttonFlag = false;
            
        }
        //İşçi ekleme formuna geçiş.
        private void add_employee_Click(object sender, EventArgs e)
        {
            addEmployee form = new addEmployee(this);
            form.Show();
            //pictureBox1.Image = (Image)(Properties.Resources.ResourceManager.GetObject(emp.picture));
            //pictureBox1.Image = Image.FromFile(emp.picture);
            //pictureBox1.Image = Properties.Resources.ResourceManager.GetObject(emp.picture);
        }
        private void tb_fullname_TextChanged(object sender, EventArgs e)
        {
            
            //Employee panelinde fullnamei yazılan işçinin bilgilerini ekrana getiren metod.
            string name = tb_fullname.Text;
            foreach(Employee emp in emps)
            {
                if (emp.fullName.Equals(name))
                {
                    tb_firtsname.Text = emp.name;
                    tb_lastname.Text = emp.lastName;
                    tb_mail.Text = emp.mail;
                    tb_birthday.Text = DateTime.Parse(emp.birthday.ToString()).ToLongDateString();
                    rtb_address.Text = emp.address;
                    mtb_number.Text = emp.number;
                    pictureBox1.Image = (Image)(Properties.Resources.ResourceManager.GetObject(emp.picture));
                    return;
                }
                else
                {
                    tb_firtsname.Text = "";
                    tb_lastname.Text = "";
                    tb_mail.Text = "";
                    tb_birthday.Text = "";
                    rtb_address.Text = "";
                    mtb_number.Text = "";
                    pictureBox1.Image = Properties.Resources.clear;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        //proje ekleme ve güncelleme formuna geçiş.
        private void btn_addproject_Click(object sender, EventArgs e)
        {
            addProject form = new addProject(this);
            form.Show();
        }

        //DataGridViewCellStyle renk = new DataGridViewCellStyle();
        //Projelerin Kilometre taşlarının durumlarına göre datagridview'e aktarılması.
        int index;
        private void dgv_projetcs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_milestones.Rows.Clear();
            dgv_tasks.Rows.Clear();
            index = dgv_projetcs.SelectedCells[0].RowIndex;
            for (int i = 0; i < projects[index].kilometreTaslari.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if(projects[index].kilometreTaslari[i].kmDurumu.durum.Equals("Devam Ediyor")){
                    renk.BackColor = Color.LemonChiffon;
                }
                else if(projects[index].kilometreTaslari[i].kmDurumu.durum.Equals("Tamamlandı"))
                {
                    renk.Font = new Font(this.Font, FontStyle.Strikeout);
                    renk.ForeColor = Color.Green;
                }
                dgv_milestones.Rows.Add(projects[index].kilometreTaslari[i].kmTanimi, projects[index].kilometreTaslari[i].kmDurumu.durum);
                dgv_milestones.Rows[i].Cells[0].Style = renk;
            }
            
        }

        //Kilometre Taşlarının görevlerinin durumlarına göre datagridview'e aktarılması.
        private void dgv_milestones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_tasks.Rows.Clear();
            int index0 = dgv_milestones.SelectedCells[0].RowIndex;
            for(int i = 0; i < projects[index].kilometreTaslari[index0].görevler.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (projects[index].kilometreTaslari[index0].görevler[i].görevDurumu.durum.Equals("Onay Bekliyor")){
                    dgv_tasks.Rows.Add(projects[index].kilometreTaslari[index0].görevler[i].görevTanimi, projects[index].kilometreTaslari[index0].görevler[i].görevDurumu.durum);
                }else if (projects[index].kilometreTaslari[index0].görevler[i].görevDurumu.durum.Equals("Devam Ediyor"))
                {
                    renk.BackColor = Color.LemonChiffon;
                    dgv_tasks.Rows.Add(projects[index].kilometreTaslari[index0].görevler[i].görevTanimi, projects[index].kilometreTaslari[index0].görevler[i].görevDurumu.durum, projects[index].kilometreTaslari[index0].görevler[i].görevBaslangici);
                    dgv_tasks.Rows[i].DefaultCellStyle = renk;
                }else if(projects[index].kilometreTaslari[index0].görevler[i].görevDurumu.durum.Equals("Tamamlandı"))
                {

                    renk.Font = new Font(this.Font, FontStyle.Strikeout);
                    renk.ForeColor = Color.Green;

                    dgv_tasks.Rows.Add(projects[index].kilometreTaslari[index0].görevler[i].görevTanimi, projects[index].kilometreTaslari[index0].görevler[i].görevDurumu.durum, projects[index].kilometreTaslari[index0].görevler[i].görevBaslangici, projects[index].kilometreTaslari[index0].görevler[i].görevBitisi);
                    dgv_tasks.Rows[i].Cells[0].Style= renk;
                }
                else
                {
                    renk.BackColor = Color.Pink;
                    dgv_tasks.Rows.Add(projects[index].kilometreTaslari[index0].görevler[i].görevTanimi, projects[index].kilometreTaslari[index0].görevler[i].görevDurumu.durum, projects[index].kilometreTaslari[index0].görevler[i].görevBaslangici, projects[index].kilometreTaslari[index0].görevler[i].görevBitisi);
                    dgv_tasks.Rows[i].DefaultCellStyle = renk;
                }

            }

        }
        
        
        private void clearFont()
        {
            timesNewRomanToolStripMenuItem.Checked = false;
            comicSansToolStripMenuItem.Checked = false;
        }
        private void clearColor()
        {
            redToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;

        }
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearColor();
            d.ForeColor = Color.Red;
            dgv_projetcs.DefaultCellStyle = d;
            dgv_milestones.DefaultCellStyle = d;
            dgv_tasks.DefaultCellStyle = d;
            redToolStripMenuItem.Checked = true;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*clearColor();
            d.ForeColor = Color.Blue;
            dgv_projetcs.DefaultCellStyle = d;
            dgv_milestones.DefaultCellStyle = d;
            dgv_tasks.DefaultCellStyle = d;
            blueToolStripMenuItem.Checked = true;*/
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*clearColor();
            d.ForeColor = Color.Green;
            dgv_projetcs.DefaultCellStyle = d;
            dgv_milestones.DefaultCellStyle = d;
            dgv_tasks.DefaultCellStyle = d;
            greenToolStripMenuItem.Checked = true;*/
        }
        
        private void timesNewRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearFont();
            timesNewRomanToolStripMenuItem.Checked = !timesNewRomanToolStripMenuItem.Checked;
            d.Font = new Font("Times New Roman",14, d.Font.Style);
            dgv_projetcs.DefaultCellStyle = d;
            dgv_milestones.DefaultCellStyle = d;
            dgv_tasks.DefaultCellStyle = d;
        }

        private void italicToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           /* italicToolStripMenuItem1.Checked = !italicToolStripMenuItem1.Checked;
            d.Font = new Font(d.Font, d.Font.Style ^ FontStyle.Italic);
            dgv_projetcs.DefaultCellStyle = d;
            dgv_milestones.DefaultCellStyle = d;
            dgv_tasks.DefaultCellStyle = d;*/
        }

        private void comicSansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*clearFont();
            comicSansToolStripMenuItem.Checked = !comicSansToolStripMenuItem.Checked;
            d.Font = new Font("Comic Sans", 14, d.Font.Style);
            dgv_projetcs.DefaultCellStyle = d;
            dgv_milestones.DefaultCellStyle = d;
            dgv_tasks.DefaultCellStyle = d;*/
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boldToolStripMenuItem.Checked = !boldToolStripMenuItem.Checked;
            d.Font = new Font(d.Font, d.Font.Style ^ FontStyle.Bold);
            dgv_projetcs.DefaultCellStyle = d;
            dgv_milestones.DefaultCellStyle = d;
            dgv_tasks.DefaultCellStyle = d;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*clearColor();
            clearFont();
            d.Font = this.Font;
            dgv_projetcs.DefaultCellStyle = d;
            dgv_milestones.DefaultCellStyle = d;
            dgv_tasks.DefaultCellStyle = d;*/

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Windows Form Project","About",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
