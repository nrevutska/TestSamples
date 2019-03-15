using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Data
{
    class User:IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }

        //public IUser Registered()
        //{
        //    return new User();
        //}
    }

    internal interface IUser
    {
        string Login { get; set; }
        string Password { get; set; }
    }
}
