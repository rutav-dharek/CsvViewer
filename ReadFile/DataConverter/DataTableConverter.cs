using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile
{
    public class DataTableConverter : IDataTableConverter
    {
        private readonly DataTable _csvTable;

        public DataTableConverter()
        {
            _csvTable = new DataTable();
        }

        public DataTable Convert(IEnumerable<string> sourceData)
        {
            if (sourceData == null && sourceData.Count() < 1)
                throw new NullReferenceException("Source Data cannot be null or empty");

            string[] _sourceDataList = sourceData.ToArray();

            for (int i = 0; i < _sourceDataList.Count() - 1; i++)
            {
                string[] rowValues = _sourceDataList[i].Split(','); //split each row with comma to get individual values  
                {
                    if (i == 0)
                    {
                        for (int j = 0; j < rowValues.Count(); j++)
                        {
                            _csvTable.Columns.Add(rowValues[j]); //add headers  
                        }
                    }
                    else
                    {
                        DataRow dr = _csvTable.NewRow();
                        for (int k = 0; k < rowValues.Count(); k++)
                        {
                            dr[k] = rowValues[k].ToString();
                        }
                        _csvTable.Rows.Add(dr); //add other rows  
                    }
                }
            }
            return _csvTable;
        }
    }
}
