using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_in_ASP.NET.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext()
        {

        }
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }
        public DbSet<EmplyeeCRUDDb> Employees { get; set; }
    }
}
