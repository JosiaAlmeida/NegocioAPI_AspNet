using RestApiNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Repositorio
{
    interface IBook
    {
        public List<Book> AllBooks();
      //  public Book CreateBook(Book book);
        //public Book UpDateBook(Book book);

    }
}
