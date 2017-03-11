using System;
using System.Collections.Generic;
using System.Data;

namespace ReadFile
{
    /// <summary>
    /// This class provides a common medium to get data from source and return it back
    /// </summary>
    public class CsvDataRepository : IDataRepository
    {
        private readonly string _filePath;
        private readonly IFileReader _fileReader;
        private readonly IDataTableConverter _dataTableConverter;

        public CsvDataRepository(string filePath ,IFileReader fileReader, IDataTableConverter dataTableConverter)
        {
            _filePath = filePath;
            _fileReader = fileReader;
            _dataTableConverter = dataTableConverter;
        }

        public DataTable Get()
        {
            DataTable dt = new DataTable();
            IEnumerable<string> sourceData;

            if (string.IsNullOrEmpty(_filePath))
                throw new NullReferenceException("File path is null");

            if (_fileReader == null)
                throw new NullReferenceException("File Reader is null");

            if (_dataTableConverter == null)
                throw new NullReferenceException("Data Table Conveter is null");

            sourceData = _fileReader.Read(_filePath);

            if (sourceData == null)
                throw new NullReferenceException("Source data is null");

            return _dataTableConverter.Convert(sourceData);
        }        
    }
}
