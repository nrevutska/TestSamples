using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Tools
{
    public class CSVReader : AExternalReader
    {
        private const char CSV_SPLIT_BY = ';';

        public string FileName { get; private set; }
        public string Path { get; private set; }

        public CSVReader(string fileName)
        {
            FileName = fileName;
            Path = System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(CSVReader)).CodeBase).Substring(6);
            Path = Path.Remove(Path.IndexOf("bin")) + FOLDER_DATA + PATH_SEPARATOR + fileName;
        }

        public override IList<IList<string>>GetAllCells()
        {
            return GetAllCells(Path);
        }
        public override IList<IList<string>>GetAllCells(string path)
        {
            Path = path;
            IList<IList<string>> allCells = new List<IList<string>>();

            string row;
            using (StreamReader streamReader = new StreamReader(path))
            {
                while ((row = streamReader.ReadLine()) != null)
                    allCells.Add(row.Split(CSV_SPLIT_BY).ToList<string>());
            }
            return allCells;
        }
    }
}
