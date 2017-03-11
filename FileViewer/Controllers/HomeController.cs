using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadFile;

namespace FileViewer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Rutav Dharek is a seasoned Software Developer";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "For now there's only contact number";

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase uploadedFile)
        {
            DataTable csvTable = new DataTable();

            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {               
                var upldFileName = Path.GetFileName(uploadedFile.FileName);
                var upldFilePath = Path.Combine(Server.MapPath("~/App_Data/"), upldFileName);
                uploadedFile.SaveAs(upldFilePath);

                /*-- 1st Pass --*/
                #region Achieved basic functinality, In order to make code maintainable , refactored it using Interface drive development
                //string csvText;
                //using (StreamReader strmReader = new StreamReader(upldFilePath))
                //{
                //    while (!strmReader.EndOfStream)
                //    {
                //        csvText = strmReader.ReadToEnd().ToString();
                //        string[] readRows = csvText.Split('\n');


                //        for (int i = 0; i < readRows.Count() - 1; i++)
                //        {
                //            string[] rowValues = readRows[i].Split(','); //split each row with comma to get individual values  
                //            {
                //                if (i == 0)
                //                {
                //                    for (int j = 0; j < rowValues.Count(); j++)  //add headers  
                //                    {
                //                        csvTable.Columns.Add(rowValues[j]);
                //                    }
                //                }
                //                else
                //                {
                //                    DataRow dr = csvTable.NewRow(); //adding rows here
                //                    for (int k = 0; k < rowValues.Count(); k++)
                //                    {
                //                        dr[k] = rowValues[k].ToString();
                //                    }
                //                    csvTable.Rows.Add(dr); 
                //                }
                //            }
                //        }

                //    }
                //}
                #endregion
                /*---------------------------------------------------------------------------------------------------------------*/

                /*-- 2nd Pass, by refactoring code --*/

                //1st Approach to read file using Stream Reader
                IDataRepository csvDataRepo = new CsvDataRepository(upldFilePath, new CsvStreamReader(), new DataTableConverter());

                //2nd Approach  to read file -- For now it has been commmented
                //IDataRepository csvDataRepo = new CsvDataRepository(upldFilePath, new FileReader(new ConsoleWriter()), new DataTableConverter());

                /*---------------------------------------------------------------------------------------------------------------------------------*/
                csvTable = csvDataRepo.Get();
            }
            return View(csvTable);
        }
    }
}