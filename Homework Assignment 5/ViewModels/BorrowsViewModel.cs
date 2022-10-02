using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework_Assignment_5.ViewModels
{
    public class BorrowsViewModel
    {
        public int BorrowID { get; set; }
        public StudentViewModel Student { get; set; }

        public BookViewModel Book { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime BroughtDate { get; set; }

        public BorrowsViewModel()
        {
            Student = new StudentViewModel();
            Book = new BookViewModel();
        }
    }
}