using Microsoft.EntityFrameworkCore;
using RestApiNegocio.Models;
using RestApiNegocio.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio.Implementação
{
    public class BookImplementation : IBook
    {
        private MysqlContext _context;
        private DbSet<Book> _dataset;

        public BookImplementation(MysqlContext book)
        {
            this._context = book;
            _dataset = _context.Set<Book>();
        }

        public List<Book> AllBooks()
        {
            return _dataset.ToList();
        }

        public Book SingleBook(int id)
        {
            if (id == null) return null;
            return _dataset.SingleOrDefault(b => b.BookId.Equals(id));
        }
        public Book CreateBook(Book book)
        {
            try
            {
                _dataset.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }

        public Book UpDateBook(Book book)
        {
            if (book.BookId == null) return null;
            try
            {
                _dataset.Update(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return book;
        }
        public Book DeleteBook(int id)
        {
            if (id == null) return null;
            var delete = _dataset.SingleOrDefault(b => b.BookId.Equals(id));
            try
            {
                _dataset.Remove(delete);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return delete;
        }

    }
}
