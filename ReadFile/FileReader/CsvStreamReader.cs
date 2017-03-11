using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile
{
    public class CsvStreamReader : IFileReader
    {
        public IEnumerable<string> Read(string filePath)
        {
            string csvText;
            if (string.IsNullOrEmpty(filePath))
                throw new ApplicationException("File path is null or empty");

            List<string> readRows = new List<string>();
            using (StreamReader strmReader = new StreamReader(filePath))
            {
                while (!strmReader.EndOfStream)
                {
                    csvText = strmReader.ReadToEnd().ToString();
                    readRows = csvText.Split('\n').ToList();
                }
            }
            return readRows;
        }
    }
}
