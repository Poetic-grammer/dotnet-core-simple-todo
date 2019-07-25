using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_To_Do.Models;

namespace Core_To_Do.Data
{
    public class InMemoryDBContext : DbContext
    {
        public InMemoryDBContext (DbContextOptions<InMemoryDBContext> options) : base(options)
        {

        }

        public DbSet<ToDoItemModel> ToDoItems { get; set; }

    }
}
