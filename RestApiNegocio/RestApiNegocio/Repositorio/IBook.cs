using RestApiNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio
{
    public interface IBook
    {
        public List<Book> AllBooks();
        public Book SingleBook(int id);
        public Book CreateBook(Book book);
        public Book UpDateBook(Book book);
        public Book DeleteBook(int id);

    }
}
