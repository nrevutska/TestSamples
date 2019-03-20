using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Tools
{
    public abstract class AExternalReader
    {
        protected const string PATH_SEPARATOR = "\\";
        protected const string FOLDER_DATA = "Resources";
        protected const string FOLDER_BIN = "bin";
        protected const int PATH_PREFIX= 6;

        public abstract IList<IList<string>> GetAllCells();
        public abstract IList<IList<string>> GetAllCells(string path);

       // string GetConnection();
    }
}
