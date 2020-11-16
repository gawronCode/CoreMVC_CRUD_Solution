using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVC_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMVC_CRUD.Data
{
    public class CrudContext : DbContext
    {

        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Comment> Comment { get; set; }

    }
}
