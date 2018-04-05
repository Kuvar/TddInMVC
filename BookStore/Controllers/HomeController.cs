using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = null;

        public HomeController() : this(new UnitOfWork())
        {
                
        }

        public HomeController(UnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public ActionResult Index()
        {
            List<Book> books = unitOfWork.BooksRepository.GetAllBooks();
            return View(books);
        }

        public ActionResult Details(int id)
        {
            Book book = unitOfWork.BooksRepository.GetBookById(id);

            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BooksRepository.AddBook(book);
                unitOfWork.BooksRepository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            Book book = unitOfWork.BooksRepository.GetBookById(id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BooksRepository.UpdateBook(book);
                unitOfWork.BooksRepository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Book book = unitOfWork.BooksRepository.GetBookById(id);
            unitOfWork.BooksRepository.DeleteBook(book);
            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            Book book = unitOfWork.BooksRepository.GetBookById(id);
            unitOfWork.BooksRepository.DeleteBook(book);
            unitOfWork.BooksRepository.Save();
            return View("Deleted");
        }

        public ActionResult Deleted()
        {
            return View();
        }
    }
}