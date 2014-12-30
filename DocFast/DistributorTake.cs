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
        public void DoDistributorTake()
        {
            LogOut();
            
            if (PolicyInfo.Server == "UAT") // UAT
            {
                if (PolicyInfo.Supplier == "Lincoln") // Lincoln
                {
                    username = "53";
                }
                else if (PolicyInfo.Supplier == "Standard" || PolicyInfo.Supplier == "Standard NY") // The Standard
                {
                    username = "53";
                }
                else if (PolicyInfo.Supplier == "Genworth") // Genworth
                {
                    username = "53";
                }
                else // Test Carrier
                {
                    username = "53";
                }

            }
            else if (PolicyInfo.Server == "PROD") // PROD
            {
                username = "77";

            }
            else // QA or QA2
            {
                if (PolicyInfo.Supplier.Equals("Lincoln")) // Lincoln - from tmigliorisi_DCM1
                {
                    username = "tmigliorisi_DCMA1"; // PolicyEXUser_DCM_4, DCM_4
                }
                else if (PolicyInfo.Supplier.Equals("Standard")) // The Standard - from tmigliorisi_DCM2
                {
                    username = "tmigliorisi_DCMA2"; // PolicyEXUser_DCM_4, DCM_4
                }
                else if (PolicyInfo.Supplier.Equals("Standard NY")) // The Standard NY - from PolicyEXUser_DCM_4
                {
                    username = "PolicyEXUser_DCMA_4"; // PolicyEXUser_DCM_5, DCM_5
                }
                else if (PolicyInfo.Supplier.Equals("Genworth")) // Genworth - from PolicyEXUser_DCM_4
                {
                    username = "PolicyEXUser_DCMA_4"; // PolicyEXUser_DCM_5, DCM_5
                }
                else // Test Carrier - from PolicyEXUser_DCM_4
                {
                    username = "PolicyEXUser_DCMA_4"; // PolicyEXUser_DCM_5, DCM_5
                }

            }

            GoToUrl(username);

            Thread.Sleep(2000);

            SearchPolicyCreated();

            new WebElement().ByXPath("//a[contains(@href, 'javascript:ActionClick();')]").Click();
            new WebElement().ByText("Take Approver Ownership").Click();

            Thread.Sleep(4000);

            new WebElement().ById("TakeApproverOwnership").Click();

            Thread.Sleep(10000);
            new WebElement().ByXPath("//button[contains(@class, 'ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only')]").Click();
            Thread.Sleep(2000);
        }
    }
}