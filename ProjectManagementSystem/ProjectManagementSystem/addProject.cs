using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    public partial class addProject : Form
    {
        Form2 frm2;
        public addProject(Form2 frm2)
        {
            InitializeComponent();
            this.frm2 = frm2;
            f = new OpenFileDialog();
            f.RestoreDirectory = true;
            f.FilterIndex = 1;
            f.Filter = "PDF Dosyaları (*.Pdf)| *.Pdf|word Dosyaları (*.docx)|*.docx|Excel Dosyaları (*.xlsx)|*.xlsx";
        }
        private void temizle()
        {
            tb_projeAdı.Text = "";
            tb_projeNo.Text = "";
            cb_stratejik.Text = "";
            tb_amac.Text = "";
            tb_problem.Text = "";
            cb_kapsam.Text = "";
            tb_kayıttarihi.Text = "";
            dtp_tahminibas.Text = "";
            dtp_tahminibitis.Text = "";
            tb_projeBaslangıc.Text = "";
            tb_projebitis.Text = "";
            mtb_getiri.Text = "";
            cb_getiriTipi.Text = "";
            lb_ekip.Items.Clear();
            lb_dosya.Items.Clear();
            cb_projeekibi.Text = "";
            cb_yürütücü.Text = "";
            tb_dosya.Text = "";

        }
        //Araçlara girilen bilgilerle proje nesnesi oluşturulur.
        private void btn_projeekle_Click(object sender, EventArgs e)
        {
            List<Employee> employees = new List<Employee>();
            
            for(int i = 0; i < lb_ekip.Items.Count; i++)
            {
                foreach (Employee emp in frm2.Emps)
                {
                    if (lb_ekip.Items[i].Equals(emp.fullName))
                    {
                        employees.Add(emp);
                    }
                }
            }
            Employee manager =  new Employee();
            Durum durum = new Durum();
            durum.onayBekliyor();
            foreach (Employee emp in frm2.Emps)
            {
                if (cb_yürütücü.Text.Equals(emp.fullName))
                {
                    manager = emp;
                }
            }
            List<String> files = new List<String>();
            for(int j = 0; j < lb_dosya.Items.Count; j++)
            {
                files.Add(lb_dosya.Items[j].ToString());
            }
            List<KilometreTasi> kmtas = new List<KilometreTasi>();
            Project prj = new Project(tb_projeAdı.Text, tb_projeNo.Text, cb_stratejik.Text, manager, tb_amac.Text,
            tb_problem.Text, cb_kapsam.Text, int.Parse(mtb_getiri.Text) , cb_getiriTipi.Text, employees, DateTime.Today,durum, dtp_tahminibas.Value,dtp_tahminibitis.Value,kmtas,files);
            

            frm2.Projects.Add(prj);
            TreeNode node = new TreeNode(prj.adi);  //treviewe ekleme
            treeView1.Nodes.Add(node);
            temizle();


        }
        //form yüklendiğinde treviewe proje bilgileri aktarıldı.
        private void addProject_Load(object sender, EventArgs e)
        {
            //NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            //Int64 myInt = -0000;
            //tb_getiri.Text = myInt.ToString("C", nfi);
            
            for(int i= 0; i< frm2.Projects.Count; i++)
            {
                TreeNode node = new TreeNode(frm2.Projects[i].adi);
                treeView1.Nodes.Add(node);
                for(int j= 0; j < frm2.Projects[i].kilometreTaslari.Count; j++)
                {
                    TreeNode node1 = new TreeNode(frm2.Projects[i].kilometreTaslari[j].kmTanimi);
                    treeView1.Nodes[i].Nodes.Add(node1);
                    for(int k = 0; k< frm2.Projects[i].kilometreTaslari[j].görevler.Count; k++)
                    {
                        TreeNode node2 = new TreeNode(frm2.Projects[i].kilometreTaslari[j].görevler[k].görevTanimi);
                        treeView1.Nodes[i].Nodes[j].Nodes.Add(node2);
                    }
                }

            }
            foreach (Employee emp in frm2.Emps) //Combobox değerleri eklendi.
            {
                cb_projeekibi.Items.Add(emp.fullName);
                //cb_yürütücü.Items.Add(emp.fullName);

            }
            //dtp_tahminibas.MinDate = DateTime.Today;
            //dtp_tahminibitis.MinDate = DateTime.Today;
            //dtp_task.MinDate = DateTime.Today;
        }
        //Comboboxtan seçilen işçi ekib eklendi.
        private void btn_ekibeekle_Click(object sender, EventArgs e)
        {
            lb_ekip.Items.Add(cb_projeekibi.Text);
            cb_yürütücü.Items.Add(cb_projeekibi.Text);
            cb_projeekibi.Text = "";
        }
        //proje bilgilerini gösteren buton metodu.
        int gösterilen;
        private void btn_projeGöster_Click(object sender, EventArgs e)
        {
            temizle();
            gösterilen = treeView1.SelectedNode.Index;
            string name = treeView1.SelectedNode.Text;
            foreach (Project proje in frm2.Projects)
            {
                if (proje.adi.Equals(name))
                {
                    tb_projeAdı.Text = proje.adi;
                    tb_projeNo.Text =proje.projeNo;
                    cb_stratejik.Text = proje.stratejikEtkisi;
                    tb_amac.Text = proje.amac;
                    tb_problem.Text = proje.problemTanimi;
                    cb_kapsam.Text = proje.kapsam;
                    tb_kayıttarihi.Text = "";
                    dtp_tahminibas.Value = proje.tahminiBaslangic;
                    dtp_tahminibitis.Value = proje.tahminiBitis;
                    tb_projeBaslangıc.Text = "";
                    tb_projebitis.Text = "";
                    mtb_getiri.Text = proje.parasalGetirisi.ToString();
                    cb_getiriTipi.Text = proje.parasalGetiriTipi;
                    tb_kayıttarihi.Text = DateTime.Parse(proje.kayitTarihi.ToString()).ToLongDateString();
                    if(proje.projeDurumu.durum.Equals("Devam Ediyor") || proje.projeDurumu.durum.Equals("Tamamlandı") || proje.projeDurumu.durum.Equals("Gecikti"))
                    {
                        tb_projeBaslangıc.Text = DateTime.Parse(proje.projeBaslangici.ToString()).ToLongDateString();
                    }
                    if(proje.projeDurumu.durum.Equals("Tamamlandı") || proje.projeDurumu.durum.Equals("Gecikti"))
                        tb_projebitis.Text = DateTime.Parse(proje.projeBitisi.ToString()).ToLongDateString();
                       
                    
                    foreach (Employee emp in proje.projeEkibi)
                    {
                        
                        lb_ekip.Items.Add(emp.fullName);
                        if (emp.fullName.Equals(proje.yürütücü.fullName))
                        {
                            cb_yürütücü.Text =emp.fullName;
                        }
                    }
                    cb_yürütücü.Items.Clear();
                    for (int a = 0; a < lb_ekip.Items.Count; a++)
                    {
                        cb_yürütücü.Items.Add(lb_ekip.Items[a].ToString());
                    }
                    foreach (String s in proje.files)
                    {
                        lb_dosya.Items.Add(s);
                    }
                }
            }
        }
        //araçları temizleyen metod.
        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        //projeyi onaylayan buton
        private void btn_onayla_Click(object sender, EventArgs e)
        {
            string name = treeView1.SelectedNode.Text;
            foreach (Project proje in frm2.Projects)
            {
                if (proje.adi.Equals(name))
                {
                    proje.projeDurumu.onayla();
                    proje.projeBaslangici = DateTime.Today;
                }
            }
        }
        //seçilen projeye kilometre taşı ekleyen buton
        private void btn_kmtEkle_Click(object sender, EventArgs e)
        {
            string name = treeView1.SelectedNode.Text;
            treeView1.SelectedNode.Nodes.Add(new TreeNode(tb_milestone.Text));
            Durum durum = new Durum();
            durum.onayla();
            List<Görev> görevler = new List<Görev>();   
            KilometreTasi kmt = new KilometreTasi(tb_milestone.Text, durum,görevler);
            foreach (Project proje in frm2.Projects)
            {
                if (proje.adi.Equals(name))
                {
                    proje.kilometreTaslari.Add(kmt);
                }
            }
            tb_milestone.Text = "";
        }
        //Seçilen kilometre taşına görev ekleyen buton.
        private void btn_görevEkle_Click(object sender, EventArgs e)
        {
            string name = treeView1.SelectedNode.Text;
            string parent = treeView1.SelectedNode.Parent.Text;
            treeView1.SelectedNode.Nodes.Add(new TreeNode(tb_task.Text));
            Durum durum = new Durum();
            durum.onayBekliyor();
            Görev görev = new Görev(tb_task.Text,durum,dtp_task.Value);
            
            foreach(Project proje in frm2.Projects)
            {
                if (proje.adi.Equals(parent))
                {
                    foreach(KilometreTasi kmt in proje.kilometreTaslari)
                    {
                        if (kmt.kmTanimi.Equals(name))
                        {
                            kmt.görevler.Add(görev);
                        }
                    }
                }
            }
            tb_task.Text = "";

        }
        //görevi onaylama butonu durum değişikliği yapıldı
        private void btn_taskOnayla_Click(object sender, EventArgs e)
        {
            string projead = treeView1.SelectedNode.Parent.Parent.Text;
            string name = treeView1.SelectedNode.Text;

            foreach(Project proje in frm2.Projects)
            {
                if (proje.adi.Equals(projead))
                {
                    if(proje.projeDurumu.durum.Equals("Onay Bekliyor"))
                    {
                        MessageBox.Show("Değişiklik yapmak için proje onaylanmalıdır.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                }
                foreach(KilometreTasi km in proje.kilometreTaslari)
                {
                    foreach(Görev g in km.görevler)
                    {
                        if (g.görevTanimi.Equals(name))
                        {
                            g.görevDurumu.onayla();
                            g.görevBaslangici = DateTime.Today;
                            return;
                        }
                    }
                }
            }
        }
        //Kilometrenin bitip bitmediğini görevlerin bitip bitmemesine bağlı olarak belirleyen metod
        private bool kmBittiMi(KilometreTasi km)
        {
            bool flag = false;
            int count = 0;
            foreach (Görev g in km.görevler)
            {
                if (g.görevDurumu.durum.Equals("Tamamlandı") || g.görevDurumu.durum.Equals("Gecikti"))
                {
                    count++;
                }
            }
            if(count == km.görevler.Count)
                flag = true;
            return flag;
        }
        //Görevi bitirme butonu. Durum güncellemeleri yapıldı. Kilometrenin bütün görevleri bittiyse durumu tamamlandı olarak değiştirildi.
        private void btn_taskBitir_Click(object sender, EventArgs e)
        {
            string name = treeView1.SelectedNode.Text;
            foreach (Project proje in frm2.Projects)
            {
                foreach (KilometreTasi km in proje.kilometreTaslari)
                {
                    foreach (Görev g in km.görevler)
                    {
                        if (g.görevTanimi.Equals(name))
                        {
                            if(g.görevDurumu.durum.Equals("Onay Bekliyor"))
                            {
                                MessageBox.Show("Görevi onaylamadan bitiremezsiniz","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                return;
                            }
                            g.görevBitisi = DateTime.Today;
                            if (g.deadLine < g.görevBitisi)
                                g.görevDurumu.gecikti();
                            else
                                g.görevDurumu.tamamla();
                            break;
                        }
                    }
                    if (kmBittiMi(km))
                    {
                        km.kmDurumu.tamamla();
                    }

                }
            }
        }
        //Projeler üzerinde yapılan değişiklikleri kaydeder ve datagridviewe güncel verileri durumlarına göre fontlandırarak yazdırır.
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            frm2.dgv_projetcs.Rows.Clear();
            frm2.dgv_milestones.Rows.Clear();
            frm2.dgv_tasks.Rows.Clear();
            
            for(int i = 0; i < frm2.Projects.Count; i++)
            {
                int count = 0;
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                foreach (KilometreTasi km in frm2.Projects[i].kilometreTaslari)
                {
                    if (km.kmDurumu.durum.Equals("Tamamlandı"))
                        count++;
                }
                if (frm2.Projects[i].kilometreTaslari.Count==0)
                {
                    frm2.Projects[i].projeDurumu.onayBekliyor();
                }
                else if (count == frm2.Projects[i].kilometreTaslari.Count)
                {
                    frm2.Projects[i].projeBitisi = DateTime.Today;
                    if (frm2.Projects[i].projeBitisi > frm2.Projects[i].tahminiBitis)
                    {
                        frm2.Projects[i].projeDurumu.gecikti();
                    }else
                        frm2.Projects[i].projeDurumu.tamamla();
                }
                    
                if (frm2.Projects[i].projeDurumu.durum.Equals("Onay Bekliyor"))
                {
                    frm2.dgv_projetcs.Rows.Add(frm2.Projects[i].adi, "PRJ"+frm2.Projects[i].projeNo, frm2.Projects[i].projeDurumu.durum, frm2.Projects[i].yürütücü.fullName);
                }
                else if (frm2.Projects[i].projeDurumu.durum.Equals("Devam Ediyor"))
                {
                    renk.BackColor = Color.LemonChiffon;
                    frm2.dgv_projetcs.Rows.Add(frm2.Projects[i].adi, "PRJ" + frm2.Projects[i].projeNo, frm2.Projects[i].projeDurumu.durum, frm2.Projects[i].yürütücü.fullName, frm2.Projects[i].projeBaslangici.ToString());
                    frm2.dgv_projetcs.Rows[i].DefaultCellStyle = renk;
                }
                else if(frm2.Projects[i].projeDurumu.durum.Equals("Tamamlandı"))
                {
                    renk.Font = new Font(frm2.Font, FontStyle.Strikeout);
                    renk.ForeColor = Color.Green;
                    frm2.dgv_projetcs.Rows.Add(frm2.Projects[i].adi, "PRJ" + frm2.Projects[i].projeNo, frm2.Projects[i].projeDurumu.durum, frm2.Projects[i].yürütücü.fullName, frm2.Projects[i].projeBaslangici.ToString(), frm2.Projects[i].projeBitisi.ToString());
                    frm2.dgv_projetcs.Rows[i].Cells[0].Style = renk;
                }
                else
                {
                    renk.BackColor = Color.Pink;
                    frm2.dgv_projetcs.Rows.Add(frm2.Projects[i].adi, "PRJ" + frm2.Projects[i].projeNo, frm2.Projects[i].projeDurumu.durum, frm2.Projects[i].yürütücü.fullName, frm2.Projects[i].projeBaslangici.ToString(), frm2.Projects[i].projeBitisi.ToString());
                    frm2.dgv_projetcs.Rows[i].DefaultCellStyle = renk;
                    
                }
            }
            this.Close();
        }
        OpenFileDialog f;
        //projeye dosya ekleme 
        private void btn_dosyaekle_Click(object sender, EventArgs e)
        {
            f.ShowDialog();

            lb_dosya.Items.Add(f.FileName);
        }
        //projenin dosyasını açma
        private void lb_dosya_DoubleClick(object sender, EventArgs e)
        {
            PDFreader form = new PDFreader(this);
            form.Show();
        }
        //projenin listboxta tıklanan dosyasının adını textboxa yazdırır
        private void lb_dosya_Click(object sender, EventArgs e)
        {
            int index = lb_dosya.SelectedIndex;
            foreach(Project p in frm2.Projects)
            {
                foreach(String s in p.files)
                {
                    if (s.Contains(Path.GetFileName(lb_dosya.Items[index].ToString()))){
                        tb_dosya.Text = Path.GetFileName(lb_dosya.Items[index].ToString());
                    }
                }
            }
        }

        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            if(frm2.Projects[gösterilen].projeDurumu.durum.Equals("Tamamlandı")|| frm2.Projects[gösterilen].projeDurumu.durum.Equals("Gecikti"))
            {
                MessageBox.Show("Tamamlanan proje güncellenemez.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                frm2.Projects[gösterilen].adi = tb_projeAdı.Text;
                frm2.Projects[gösterilen].projeNo = tb_projeNo.Text;
                frm2.Projects[gösterilen].stratejikEtkisi = cb_stratejik.Text;
                frm2.Projects[gösterilen].amac = tb_amac.Text;
                frm2.Projects[gösterilen].problemTanimi = tb_problem.Text;
                frm2.Projects[gösterilen].kapsam = cb_kapsam.Text;
                frm2.Projects[gösterilen].tahminiBitis = dtp_tahminibitis.Value;
                frm2.Projects[gösterilen].parasalGetirisi =int.Parse(mtb_getiri.Text);
                frm2.Projects[gösterilen].parasalGetiriTipi = cb_getiriTipi.Text;
                List<Employee> employees = new List<Employee>();

                for (int i = 0; i < lb_ekip.Items.Count; i++)
                {
                    foreach (Employee emp in frm2.Emps)
                    {
                        if (lb_ekip.Items[i].Equals(emp.fullName))
                        {
                            employees.Add(emp);
                        }
                    }
                }
                Employee manager = new Employee();
                foreach (Employee emp in frm2.Emps)
                {
                    if (cb_yürütücü.Text.Equals(emp.fullName))
                    {
                        manager = emp;
                    }
                }
                List<String> files = new List<String>();
                for (int j = 0; j < lb_dosya.Items.Count; j++)
                {
                    files.Add(lb_dosya.Items[j].ToString());
                }
                frm2.Projects[gösterilen].projeEkibi = employees;
                frm2.Projects[gösterilen].files = files;
                frm2.Projects[gösterilen].yürütücü = manager;
                temizle();
            }
            
        }

        private void btn_ekipSil_Click(object sender, EventArgs e)
        {
            int silinecek = lb_ekip.SelectedIndex;
            if (silinecek > -1)
            {
                
                lb_ekip.Items.RemoveAt(silinecek);
                cb_yürütücü.Items.RemoveAt(silinecek);
            }
            else
                MessageBox.Show("Lütfen silinecek kişiyi seçiniz.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);  
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int silinecek = treeView1.SelectedNode.Index;
            if (silinecek > -1)
            {
                treeView1.Nodes.RemoveAt(silinecek);
                frm2.Projects.RemoveAt(silinecek);
                temizle();
            }
            else
                MessageBox.Show("Silinecek projeyi seçiniz.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            
        }
    }
}
