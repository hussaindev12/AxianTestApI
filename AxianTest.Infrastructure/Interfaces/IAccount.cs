using AxianTest.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxianTest.Infrastructure.Interfaces
{
    public interface IAccount
    {
        public UserModel Authentication(UserModel user);
        

    }
}
