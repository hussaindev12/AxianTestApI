using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxianTest.Infrastructure.ViewModel
{
    public class DepartmentModel:BaseModel
    {
        public string Name { get; set; }       
        public string Location { get; set; }
        public bool UpdateRequest { get; set; }
    }
}
