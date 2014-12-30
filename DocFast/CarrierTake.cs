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
        public void DoCarrierTake()
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
                if (PolicyInfo.Supplier.Equals("Lincoln")) // Lincoln - from tmigliorisi_CCM1
                {
                    username = "tmigliorisi_CCMA1"; // Migliorisi, Teresita CCMA1
                }
                else if (PolicyInfo.Supplier.Equals("Standard")) // The Standard - from tmigliorisi_CCM2
                {
                    username = "tmigliorisi_CCMA2"; // Migliorisi, Teresita CCMA2
                }
                else if (PolicyInfo.Supplier.Equals("Standard NY")) // The Standard - from tmigliorisi_CCM
                {
                    username = "tmigliorisi_CCMA"; // Migliorisi, Teresita CCMA
                }
                else if (PolicyInfo.Supplier.Equals("Genworth")) // Genworth - from tmigliorisi_CCM10
                {
                    username = "tmigliorisi_CCMA10"; // Migliorisi, Teresita CCMA10
                }
                else // Test Carrier - from PolicyEXUser_CCM_3
                {
                    username = "PolicyEXUser_CCMA_5"; // PolicyEXUser_CCMA_5
                }

            }
            
            GoToUrl(username);

            Thread.Sleep(2000);

            SearchPolicyCreated();

            WebElement ActionClick = new WebElement().ByXPath("//a[contains(@href, 'javascript:ActionClick();')]");
            ActionClick.Click();
            WebElement Take = new WebElement().ByText("Take Approver Ownership");
            Take.Click();
            
            Thread.Sleep(4000);

            WebElement TakeApproverOwnership = new WebElement().ById("TakeApproverOwnership");
            TakeApproverOwnership.Click();
            
            Thread.Sleep(10000);

            WebElement okBtn = new WebElement().ByXPath("//button[contains(@class, 'ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only')]");
            okBtn.Click();

            Thread.Sleep(2000);
        }
    }
}