using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
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
using SeleNUnit.WebObjects.WebElement;

namespace DocFast.WebObjects
{
    public partial class actions
    {
        public void DoDistributorTransferSubGA()
        {
            SearchPolicyCreated();

            WebElement ActionClick = new WebElement().ByXPath("//a[contains(@href, 'javascript:ActionClick();')]");
            ActionClick.Click();
            WebElement Transfer = new WebElement().ByText("Transfer for Approval");
            Transfer.Click();

            Thread.Sleep(4000);

            WebElement CaseManagerSearchEmail = new WebElement().ById("CaseManagerSearchEmail");
            CaseManagerSearchEmail.SendKeys("tmi");

            Thread.Sleep(2000);

            WebElement CaseManagerSearchButton = new WebElement().ByXPath(".//*[@id='CaseManagerSearchButton']");
            CaseManagerSearchButton.Click();

            Thread.Sleep(2000);

            string caseManagerID;
            
            if (PolicyInfo.Server == "UAT") // UAT
            {
                if (PolicyInfo.Supplier == "Lincoln") // Lincoln
                {
                    caseManagerID = "53";
                }
                else if (PolicyInfo.Supplier == "Standard" || PolicyInfo.Supplier == "Standard NY") // The Standard
                {
                    caseManagerID = "53";
                }
                else if (PolicyInfo.Supplier == "Genworth") // Genworth
                {
                    caseManagerID = "53";
                }
                else // Test Carrier
                {
                    caseManagerID = "53";
                }

            }
            else if (PolicyInfo.Server == "PROD") // PROD
            {
                caseManagerID = "77";

            }
            else // QA or QA2
            {
                if (PolicyInfo.Supplier.Equals("Lincoln")) // Lincoln - from tmigliorisi_DCM1
                {
                    caseManagerID = "57"; // PolicyEXUser_DCMA_5, DCMA_5
                }
                else if (PolicyInfo.Supplier.Equals("Standard")) // The Standard - from tmigliorisi_DCM2
                {
                    caseManagerID = "53"; // PolicyEXUser_DCMA_5, DCMA_5
                }
                else if (PolicyInfo.Supplier.Equals("Standard NY")) // The Standard NY - from PolicyEXUser_DCM_4
                {
                    caseManagerID = "57"; // PolicyEXUser_DCMA_5, DCMA_5
                }
                else if (PolicyInfo.Supplier.Equals("Genworth")) // Genworth - from PolicyEXUser_DCM_4
                {
                    caseManagerID = "57"; // PolicyEXUser_DCMA_5, DCMA_5
                }
                else // Test Carrier - from PolicyEXUser_DCM_4
                {
                    caseManagerID = "57"; // PolicyEXUser_DCMA_5, DCMA_5
                }

            }

            WebElement DCM = new WebElement().ByXPath(".//*[@id='divCaseManagerList']");
            DCM.ByName("CaseManagerListRadio").Select(caseManagerID);
            //foreach (IWebElement option in DCM.ByName("CaseManagerListRadio"))
            //{
            //    if (option.GetAttribute("value") == caseManagerID)
            //    {
            //        option.Click();
            //        break;
            //    }
            //}

            WebElement SelectCaseManager = new WebElement().ById("SelectCaseManager");
            SelectCaseManager.Click();

            Thread.Sleep(2000);

            WebElement divBtn = new WebElement().ByXPath("//div[@class='ui-dialog ui-widget ui-widget-content ui-corner-all ui-draggable ui-resizable']/div[@class='ui-dialog-buttonpane ui-widget-content ui-helper-clearfix']/button[1]");
            divBtn.Click();

            Thread.Sleep(10000);

            WebElement okBtn = new WebElement().ByXPath("//button[contains(@class, 'ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only')]");
            okBtn.Click();

            Thread.Sleep(2000);
        }
    }
}