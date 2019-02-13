using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApiAppl.Models;

namespace WebApiAppl.EF
{
    public class Context : DbContext
    {
        public Context() :  base("WebApiConnection")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Position> Positions { get; set; }
    }
}