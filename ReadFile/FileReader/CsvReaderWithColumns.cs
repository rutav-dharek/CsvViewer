using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile
{
    public class CsvReaderWithColumns : IFileReader
    {
        public CsvReaderWithColumns(int noOfColumn,string[] DataType)
        {

        }
        public IEnumerable<string> Read(string filePath)
        {   
            IEnumerable<string> lines = null;

            if (string.IsNullOrEmpty(filePath))
                throw new ApplicationException("File path is null or empty");

            lines = File.ReadAllLines(filePath);

            if (lines == null && lines.Count() < 1)
                throw new ApplicationException("No read value");

            //Implementation of reading specific column is pending

            return lines;
        }
    }
}
