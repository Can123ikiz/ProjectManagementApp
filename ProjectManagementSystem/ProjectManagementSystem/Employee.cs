using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    internal class Employee
    {
        public string fullName { get; set; }
        public string name { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public DateTime birthday { get; set; }
        public string mail { get; set; }
        public string address { get; set; }
        public string number { get; set; }

        public string picture { get; set; } 


        public Employee(string fullName, string name, string middleName, string lastName, DateTime birthday,string mail, string address, string number, string picture)
        {
            this.fullName = fullName;
            this.name = name;
            this.middleName = middleName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.mail = mail;
            this.address = address;
            this.number = number;
            this.picture = picture;
        }

        public Employee()
        {

        }
            
    }

}
