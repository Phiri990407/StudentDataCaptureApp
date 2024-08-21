using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project_PRG281.BusinessLogicLayer
{
    internal class Students
    {
        int StudentNumber ;
        string StudentNameSurname;
        byte StudentImage;
        DateTime DOB;
        string Gender;
        string Phone;
        string Address;
        string ModuleCodes;

        public Students() { }

        public Students(int studentNumber, string studentNameSurname, byte studentImage, DateTime dOB, string gender, string phone, string address, string moduleCodes)
        {
            StudentNumber = studentNumber;
            StudentNameSurname = studentNameSurname;
            StudentImage = studentImage;
            DOB = dOB;
            Gender = gender;
            Phone = phone;
            Address = address;
            ModuleCodes = moduleCodes;
        }

        public int StudentNumber1 { get; set; }
        public string StudentNameSurname1 { get; set; }
        public byte StudentImage1 { get; set; }
        public DateTime DOB1 { get; set; }
        public string Gender1 { get; set; }
        public string Phone1 { get; set; }
        public string Address1 { get; set; }
        public string ModuleCodes1 { get; set; }
    }
}
