using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    internal class Project
    {
        public string adi { get; set; }
        public string projeNo { get; set; }
        public string stratejikEtkisi { get; set; }
        public Employee yürütücü { get; set; }
        public string amac { get; set; }
        public string problemTanimi { get; set; }
        public string kapsam { get; set; }
        public DateTime kayitTarihi { get; set; }
        public DateTime projeBaslangici { get; set; }
        public DateTime projeBitisi { get; set; }
        public DateTime tahminiBaslangic { get; set; }
        public DateTime tahminiBitis { get; set; }
        public Durum projeDurumu { get; set; }
        public int parasalGetirisi { get; set; }
        public string parasalGetiriTipi { get; set; }
        public List<Employee> projeEkibi { get; set; }
        public List<String> files { get; set; }
        public List<KilometreTasi> kilometreTaslari { get; set; }

        /*public Project(string adi, string projeNo, string stratejikEtkisi, Employee yürütücü, string amac,
            string problemTanimi, string kapsam, DateTime kayitTarihi, DateTime projeBaslangici,
            DateTime projeBitisi, DateTime tahminiBaslangıc, DateTime tahminiBitis,
            Durum projeDurumu, int parasalGetirisi, string parasalGetiriTipi, List<Employee> projeEkibi,
            List<FileDialog> files, List<KilometreTasi> kilometreTaslari)
        {
            this.adi = adi;
            this.projeNo = "PRJ" + projeNo;
            this.stratejikEtkisi = stratejikEtkisi;
            this.yürütücü = yürütücü;
            this.amac = amac;
            this.problemTanimi = problemTanimi;
            this.kapsam = kapsam;
            this.projeBitisi = projeBitisi;
            this.tahminiBitis = tahminiBitis;
            this.projeDurumu = projeDurumu;
            this.parasalGetirisi = parasalGetirisi;
            this.parasalGetiriTipi = parasalGetiriTipi;
            this.projeEkibi = projeEkibi;
            this.files = files;
            
            this.kilometreTaslari = kilometreTaslari;
        }*/
        public Project()
        {

        }
        public Project(string Adi, string ProjeNo, string StratejikEtkisi, Employee Yurutucu, string Amac,
            string ProblemTanimi, string Kapsam,int ParasalGetirisi, string ParasalGetiriTipi, List<Employee> projeEkibi, DateTime kayitTarihi, Durum projeDurumu, DateTime tahminiBaslangıc,DateTime tahminiBitis,List<KilometreTasi> kilometreTaslari,List<String> files)
        {
            this.adi = Adi;
            this.projeNo = ProjeNo;
            this.stratejikEtkisi = StratejikEtkisi;
            this.yürütücü = Yurutucu;
            this.amac = Amac;
            this.problemTanimi = ProblemTanimi;
            this.kapsam = Kapsam;
            
            this.parasalGetirisi = ParasalGetirisi;
            this.parasalGetiriTipi = ParasalGetiriTipi;
            this.projeEkibi = projeEkibi;
            this.kayitTarihi = kayitTarihi;
            this.projeDurumu = projeDurumu;
            this.tahminiBaslangic = tahminiBaslangıc;
            this.tahminiBitis = tahminiBitis;

            this.kilometreTaslari = kilometreTaslari;
            this.files = files;
        }


    }

    public class Durum
    {
        public string durum;
        public void onayBekliyor()
        {
            this.durum = "Onay Bekliyor";
        }
        public void onayla()
        {
            this.durum = "Devam Ediyor";
        }
        public void tamamla()
        {
            this.durum = "Tamamlandı";
        }
        public void gecikti()
        {
            this.durum = "Gecikti";
        }
        /*public bool OnaylandiMi { get; set; }
        public bool devamEdiyorMu { get; set; }
        public bool TamamlandiMi { get; set; }*/
    }
    
    public class KilometreTasi
    {
        public string kmTanimi { get; set; }
        public Durum kmDurumu { get; set; }
        public List<Görev> görevler { get; set; }
        
        public KilometreTasi(string kmTanimi, Durum kmDurumu, List<Görev> görevler)
        {
            this.kmTanimi = kmTanimi;
            this.kmDurumu = kmDurumu;
            this.görevler = görevler;
        }
    }
    public class Görev{
        public string görevTanimi { get; set; }
        public Durum görevDurumu { get; set; }
        public DateTime görevBaslangici { get; set; }
        public DateTime görevBitisi { get; set; }
        public DateTime deadLine { get; set; }

        public Görev(string görevTanimi, Durum görevDurumu, DateTime deadLine)
        {
            this.görevTanimi = görevTanimi;
            this.görevDurumu = görevDurumu;
            this.deadLine = deadLine;
        }
        public Görev()
        {

        }
    }

}


