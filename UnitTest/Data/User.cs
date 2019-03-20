using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Tools;

namespace UnitTest.Data
{
    class User:IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public static IList<IUser> GetAllUsers(AExternalReader externalData)
        {
            IList<IUser> users = new List<IUser>();
            bool isCaption = true;
            foreach(IList<string> row in externalData.GetAllCells())
            {
                if(isCaption)
                {
                    isCaption = false;
                    continue;
                }
                users.Add(new User(row[0], row[1]));
            }
            return users;
        }
    }

    public interface IUser
    {
        string Login { get; set; }
        string Password { get; set; }
    }
}
