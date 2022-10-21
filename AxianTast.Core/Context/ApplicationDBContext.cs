using AxianTast.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxianTast.Core.Context
{
   public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }      
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }       
    }
}
