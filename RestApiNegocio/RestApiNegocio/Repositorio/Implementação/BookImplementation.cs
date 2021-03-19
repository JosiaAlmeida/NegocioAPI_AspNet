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

        public Book CreateBook(Book book)
        {
            if (book == null) return null;
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

        public Book DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Book SingleBook(int id)
        {
            throw new NotImplementedException();
        }

        public Book UpDateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
