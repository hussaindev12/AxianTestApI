using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxianTast.Core.Entities
{
    public class Employee:BaseEntity
    {
        [Column(TypeName = "varchar(255)")]
        public string DOB { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public decimal Salary { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public int LeavPeryear { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public int SickLeave { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }


        [ForeignKey("department")]
        public int DepId { get; set; }
        public Department department { get; set; }


        
        public virtual User User { get; set; }
    }
}
