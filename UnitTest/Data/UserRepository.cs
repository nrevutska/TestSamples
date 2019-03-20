using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Tools;

namespace UnitTest.Data
{
    class UserRepository
    {
        private volatile static UserRepository instance;
        private static object lockingObject = new object();

        public static UserRepository Get()
        {
            if(instance == null)
            {
                lock(lockingObject)
                {
                    if (instance == null)
                        instance = new UserRepository();
                }
            }
            return instance;
        }

        public IUser Registered()
        {
            return new User("admin", "demo123");
        }
        public IUser Invalid()
        {
            return new User("haha", "demo123");
        }

        public IList<IUser> FromCSV()
        {
            return FromCSV("UsersCSV.csv");
        }
        public IList<IUser> FromCSV(string filename)
        {
            return User.GetAllUsers(new CSVReader(filename));
        }
    }
}
