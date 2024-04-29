using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Json.Models
{

        public class StudentContext : DbContext
        {
            public DbSet<Student> Students { get; set; }
        }
    }
}