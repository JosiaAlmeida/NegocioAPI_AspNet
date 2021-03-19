using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiNegocio.Models.Context
{
    public class MysqlContext : DbContext
    {
        protected MysqlContext()
        {
        }
        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options) { }
        public DbSet<Book> books { get; set; }
    }
}
