using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework_Assignment_5.ViewModels
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        public string Sname { get; set; }
        public string Ssurname { get; set; }
        public DateTime BirthDate { get; set; }
        public double Class { get; set; }
        public int Spoint { get; set; }

    }
}