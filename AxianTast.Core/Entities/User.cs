using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxianTast.Core.Entities
{
    
    public class User:BaseEntity
    {      
        [Column(TypeName ="varchar(255)")]
        public string FullName { get; set; }

        
        [EmailAddress]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Type { get; set; }




        [ForeignKey("Employee")]
        public int? EmpId { get; set; }
        public virtual Employee Employee { get; set; }       
    }
}
