using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoNow.Models
{
    public class ToDoNowDb : DbContext
    {

        public ToDoNowDb() : base("name=DefaultConnection")
        {

        }

        public DbSet<Todo> Todos { get; set; }


    }
}