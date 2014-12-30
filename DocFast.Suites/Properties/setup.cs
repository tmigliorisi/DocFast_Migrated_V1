using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Data;
using System.Data.OleDb;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using SeleNUnit.WebObjects;
using DocFast.WebObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleNUnit.WebObjects.WebElement;
using NUnit.Framework;

namespace DocFast.Suites
{

    [TestFixture]
    public partial class RT
    {
        public DocFast.WebObjects.actions.Policy newPol = new DocFast.WebObjects.actions.Policy();

        [SetUp]
        public void TestInitialize()
        {
            GetFile();
 
        }

        [Test]
        public void TestScenario()
        {
            for (int row = 1; row < dtExcel.Rows.Count; row++) // Loop file rows to setup test data
            {
                newPol.Server = dtExcel.Rows[row].ItemArray[0].ToString();
                newPol.Browser = dtExcel.Rows[row].ItemArray[1].ToString();
                newPol.Flow = dtExcel.Rows[row].ItemArray[2].ToString();
                newPol.DistributorRole = dtExcel.Rows[row].ItemArray[3].ToString();
                newPol.AgentRole = dtExcel.Rows[row].ItemArray[4].ToString();
                newPol.Product = dtExcel.Rows[row].ItemArray[5].ToString();
                newPol.AnnualPremium = Convert.ToBoolean(dtExcel.Rows[row].ItemArray[6].ToString());
                newPol.ESV = Convert.ToBoolean(dtExcel.Rows[row].ItemArray[7].ToString());
                newPol.CCQ = Convert.ToBoolean(dtExcel.Rows[row].ItemArray[8].ToString());
                newPol.CQ = Convert.ToBoolean(dtExcel.Rows[row].ItemArray[9].ToString());
                newPol.Additional = Convert.ToBoolean(dtExcel.Rows[row].ItemArray[10].ToString());
                newPol.PrivateAttachment = Convert.ToBoolean(dtExcel.Rows[row].ItemArray[11].ToString());
                newPol.NewAgent = Convert.ToBoolean(dtExcel.Rows[row].ItemArray[12].ToString());
                newPol.PIEmail = Convert.ToBoolean(dtExcel.Rows[row].ItemArray[13].ToString());
                newPol.SaveOrSend = dtExcel.Rows[row].ItemArray[14].ToString();
                newPol.Actor = dtExcel.Rows[row].ItemArray[15].ToString();
                newPol.Action = dtExcel.Rows[row].ItemArray[16].ToString();
                newPol.Supplier = dtExcel.Rows[row].ItemArray[17].ToString();
                newPol.DistributorID = dtExcel.Rows[row].ItemArray[18].ToString();
                newPol.DCMID = dtExcel.Rows[row].ItemArray[19].ToString();
                newPol.AgentID = dtExcel.Rows[row].ItemArray[20].ToString();
                newPol.AgentSearch = dtExcel.Rows[row].ItemArray[21].ToString();
                newPol.Carrier = dtExcel.Rows[row].ItemArray[22].ToString();
                newPol.Distributor = dtExcel.Rows[row].ItemArray[23].ToString();
                newPol.Agent = dtExcel.Rows[row].ItemArray[24].ToString();

                actions Actions = new actions();
                Actions.PolicyInfo = newPol;

                if (newPol.Browser.Equals("IE"))
                {
                    Browser.SelectedBrowser = Browsers.InternetExplorer;
                }
                else if (newPol.Browser.Equals("Ch"))
                {
                    Browser.SelectedBrowser = Browsers.Chrome;
                }
                else
                {
                    Browser.SelectedBrowser = Browsers.Firefox;
                }

                Browser.Start("http://localhost:4444/wd/hub");
                
                Actions.username = newPol.Carrier;
                Actions.DoAction();
            }
            
        }

        

        DataTable dtExcel = new DataTable();

        public void GetFile()
        {
            DataSet ds_Data = new DataSet();
            OleDbConnection oleCon = new OleDbConnection();

            string strExcelFile = DocFast.WebObjects.Resource.FilePath;
            oleCon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strExcelFile + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
            string SpreadSheetName = "";

            OleDbDataAdapter Adapter = new OleDbDataAdapter();
            OleDbConnection conn = new OleDbConnection(oleCon.ConnectionString);

            string strQuery;
            conn.Open();
            
            DataTable ExcelSheets = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            SpreadSheetName = "QA Test Carrier$"; 

            strQuery = "select * from [" + SpreadSheetName + "] ";
            OleDbCommand cmd = new OleDbCommand(strQuery, conn);
            Adapter.SelectCommand = cmd;

            Adapter.Fill(dtExcel);
            conn.Close();
        }
               
    }
}
   
    