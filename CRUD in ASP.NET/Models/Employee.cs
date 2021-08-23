using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_in_ASP.NET.Models
{
    public class EmplyeeCRUDDb
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " Please Enter Name ")]
        public String Name { get; set; }
        [MaxLength(5)]
        public String EmpCode { get; set; }
        public String Position { get; set; }
    }
}
