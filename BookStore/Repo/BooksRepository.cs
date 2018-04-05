using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Repo
{
    public class BooksRepository : IBooksRepository
    {
        BookStoreEntities entities = null;        

        public BooksRepository(BookStoreEntities entities)
        {
            this.entities = entities;
        }

        public List<Book> GetAllBooks()
        {
            return entities.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return entities.Books.SingleOrDefault(book => book.ID == id);
        }

        public void AddBook(Book book)
        {
            entities.Books.Add(book);
            Save();
        }

        public void UpdateBook(Book book)
        {
            Book data = GetBookById(book.ID);
            data.BookName = book.BookName;
            data.AuthorName = book.AuthorName;
            data.ISBN = book.ISBN;
            Save();
        }

        public void DeleteBook(Book book)
        {
            entities.Books.Remove(book);
            Save();
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}