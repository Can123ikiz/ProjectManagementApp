using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem
{
    internal class Kullanıcı
    {
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public Kullanıcı(string kullaniciAdi, string sifre)
        {
            this.kullaniciAdi = kullaniciAdi;
            this.sifre = sifre;
        }
        
    }
}
