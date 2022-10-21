using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxianTast.Core.Entities
{
    public class Department: BaseEntity
    {
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Location { get; set; }

        public bool? UpdateRequest { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
