using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Homework_Assignment_5.ViewModels;

namespace Homework_Assignment_5.Controllers
{
    public class HomeController : Controller
    {
        private SqlConnection myConnection = new SqlConnection(Globals.ConnectionString);
        public ActionResult Index()
        {
            try
            {
                myConnection.Open();
                //Read all person records for table
                SqlCommand myCommand = new SqlCommand("Select books.bookId , books.name AS BookName , authors.name , types.name AS Tname , books.pagecount , books.point FROM books INNER JOIN authors ON books.authorId = authors.authorId INNER JOIN types ON books.typeId=types.typeId", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                Globals.bookList.Clear();
                while (myReader.Read())
                {
                    BookViewModel book = new BookViewModel();
                    book.BookID = (int)myReader["bookId"];
                    book.BookName = myReader["BookName"].ToString();
                    book.Author.Aname = myReader["name"].ToString();
                    book.Type.Tname = myReader["Tname"].ToString();
                    book.Page = (int)myReader["pagecount"];
                    book.Point = (int)myReader["point"];


                    Globals.bookList.Add(book);
                }
            }
            catch (Exception err)
            {
                ViewBag.Status = 0;
            }
            finally
            {
                myConnection.Close();
            }
            return View(Globals.bookList);


            //Search-----------------------------------------------------------------------------------------------------------------------------------------------------
        }

        public ActionResult Search(string searchText, string searchText2, string searchText3)
        {
            try
            {

                myConnection.Open();
                //Read all person records for table
                SqlCommand mySearch = new SqlCommand("Select books.bookId , books.name AS BookName , authors.name , books.typeId , books.pagecount,books.point FROM books INNER JOIN authors ON books.authorId = authors.authorId where BookName LIKE '%" + searchText + "%' OR authors.name LIKE '%" + searchText2 + "%' OR types.name LIKE '%" + searchText3 + "%'", myConnection);
                SqlDataReader myReader = mySearch.ExecuteReader();
                Globals.bookList.Clear();
                while (myReader.Read())
                {
                    BookViewModel book = new BookViewModel();
                    book.BookID = (int)myReader["bookId"];
                    book.BookName = myReader["BookName"].ToString();
                    book.Author.Aname = myReader["name"].ToString();
                    book.Type.Tname = myReader["Tname"].ToString();
                    book.Page = (int)myReader["pagecount"];
                    book.Point = (int)myReader["point"];
                    ViewBag.Status = 1;

                    Globals.bookList.Add(book);
                }
                ViewBag.SearchStatus = 2;
                ViewBag.SearchText = "Showing results for: '" + searchText + searchText2 +searchText3+ "'";
            }
            catch (Exception err)
            {
                ViewBag.Status = 0;
            }
            finally
            {
                myConnection.Close();
            }
            return View("Index", Globals.bookList);
        }


        // -------------------------------------------------------------------------get book details----------------------------------------------------------------------------
        public ActionResult BookDetails(string bookname, int bookid)
        {
            BorrowsViewModel borrowmodel = new BorrowsViewModel();
            borrowmodel.Book = Globals.bookList.Where(p => p.BookID == bookid).FirstOrDefault();
            try
            {
                myConnection.Open();
                //Read all book details for table
                SqlCommand myCommand = new SqlCommand("Select borrowId,borrows.takenDate,borrows.broughtDate,students.name from borrows INNER JOIN students ON borrows.studentId=students.studentId INNER JOIN books ON borrows.bookId=books.bookId Where books.bookId Like '"+bookid+"' ", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();
                Globals.bookList.Clear();
                while (myReader.Read())
                {
                    BorrowsViewModel borrow = new BorrowsViewModel();
                    borrow.BorrowID = (int)myReader["borrowId"];
                    borrow.TakenDate = (DateTime)myReader["takenDate"];
                    borrow.BroughtDate = (DateTime)myReader["broughtDate"];
                    borrow.Student.Sname = myReader["name"].ToString();
                    borrow.Book.BookID = (int)myReader["bookId"];
                    Globals.borrowsList.Add(borrow);
                }
                ViewBag.Title = bookname;
            }
            catch (Exception err)
            {
                ViewBag.Status = 0;
            }
            finally
            {
                myConnection.Close();
            }
            return View(Globals.bookList);


        }

        public ActionResult StudenDetails()
        {
            try
            {
                myConnection.Open();
                //Read all book details for table
                SqlCommand myCommand = new SqlCommand("Select students.studentId,students.name,students.surname,students.class,students.point from students", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();
                Globals.bookList.Clear();
                while (myReader.Read())
                {
                    StudentViewModel student = new StudentViewModel();
                    student.StudentID = (int)myReader["studentId"];
                    student.Sname = myReader["name"].ToString();
                    student.Ssurname = myReader["surname"].ToString();
                    student.Class = (double)myReader["class"];
                    student.Spoint = (int)myReader["point"];
                    Globals.studentList.Add(student);
                }
                
            }
            catch (Exception err)
            {
                ViewBag.Status = 0;
            }
            finally
            {
                myConnection.Close();
            }
            return View(Globals.bookList);


        }

    }
}