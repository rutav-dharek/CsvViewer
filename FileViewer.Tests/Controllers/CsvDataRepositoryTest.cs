using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadFile;

namespace FileEditor.Tests.Controllers
{
    [TestClass]
    public class CsvDataRepositoryTest
    {
        [TestMethod]
        public void NullFilePathTest()
        {
            string _filePath = null;
            CsvDataRepository _csvRepo = new CsvDataRepository(_filePath, new CsvStreamReader(), new DataTableConverter());
            Assert.IsNotNull(_csvRepo.Get());
        }

        [TestMethod]
        public void NullCsvReaderTest()
        {
            string _filePath = @"E:\Learning\Visual Studio 2015 Projects\FileViewer\FileViewer\App_Data\WithHeaderData.csv";
            CsvDataRepository _csvRepo = new CsvDataRepository(_filePath, null, new DataTableConverter());
            Assert.IsNotNull(_csvRepo.Get());            
        }

        [TestMethod]
        public void NullDataTableReaderTest()
        {
            string _filePath = @"E:\Learning\Visual Studio 2015 Projects\FileViewer\FileViewer\App_Data\WithHeaderData.csv";
            CsvDataRepository _csvRepo = new CsvDataRepository(_filePath, new CsvStreamReader(), null);
            Assert.IsNotNull(_csvRepo.Get());
        }
    }
}
