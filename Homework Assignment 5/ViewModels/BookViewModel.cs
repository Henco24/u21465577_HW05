using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework_Assignment_5.ViewModels;

namespace Homework_Assignment_5.ViewModels
{
    public class BookViewModel
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int Page { get; set; }
        public int Point { get; set; }
        public AuthorViewModel Author { get; set; }
        public TypeViewModel Type { get; set; }

        public BookViewModel()
        {
            Type = new TypeViewModel();
            Author = new AuthorViewModel();
        }
    }
}