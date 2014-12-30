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
        public void DoCarrierResend()
        {
            SearchPolicyCreated();

            WebElement ActionClick = new WebElement().ByXPath("//a[contains(@href, 'javascript:ActionClick();')]");
            ActionClick.Click();
            WebElement Resend = new WebElement().ByText("Resend");
            Resend.Click();

            Thread.Sleep(4000);

            if (!PolicyInfo.AgentRole.Equals("CC") && !PolicyInfo.AgentRole.Equals("CCRO") && !PolicyInfo.Flow.Equals("DTC"))
            {
                WebElement ResendNotfication = new WebElement().ByXPath(".//*[@id='ResendNotfication']");
                ResendNotfication.Click();
            }
            else
            {
                Thread.Sleep(2000);

                if (PolicyInfo.DistributorRole == "App")
                {
                    WebElement ResendNotfication = new WebElement().ByXPath(".//*[@id='ResendNotfication']");
                    ResendNotfication.Click();
                }
                else
                {
                    WebElement AgentResendNotfication = new WebElement().ByXPath(".//*[@id='AgentResendNotfication']");
                    AgentResendNotfication.Click();
                }
            }

            Thread.Sleep(10000);

            WebElement okBtn = new WebElement().ByXPath("//button[contains(@class, 'ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only')]");
            okBtn.Click();

            Thread.Sleep(2000);
        }
    }
}