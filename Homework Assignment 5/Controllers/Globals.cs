using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Homework_Assignment_5.ViewModels;

namespace Homework_Assignment_5.Controllers
{
    public static class Globals
    {
        public static string ConnectionString = "Data Source=.;Initial Catalog=Library;Integrated Security=True";
        public static List<BookViewModel> bookList = new List<BookViewModel>();
        public static List<BorrowsViewModel> borrowsList = new List<BorrowsViewModel>();
        public static List<StudentViewModel> studentList = new List<StudentViewModel>();
        public static List<TypeViewModel> TypeList = new List<TypeViewModel>();

    }
}