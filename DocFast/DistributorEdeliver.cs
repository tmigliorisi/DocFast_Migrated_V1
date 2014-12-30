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
        public void DoDistributorEdeliver()
        {
            SearchPolicyCreated();

            WebElement ActionClick = new WebElement().ByXPath("//a[contains(@href, 'javascript:ActionClick();')]");
            ActionClick.Click();
            WebElement eDeliver = new WebElement().ByText("e-Deliver to Agent");
            eDeliver.Click();
            
            Thread.Sleep(4000);

            WebElement SendPolicytoAgent = new WebElement().ByXPath(".//*[@id='SendPolicytoAgent']");
            SendPolicytoAgent.Click();
                        
            Thread.Sleep(10000);
            
            if (PolicyInfo.AgentRole == "CC" || PolicyInfo.AgentRole == "CCRO")
            {
                WebElement txtEmail = new WebElement().ByXPath("//input[contains(@id, 'txtEmail')]");

                if (txtEmail.InnerHtml.Equals(String.Empty))
                {
                    txtEmail.SendKeys(DocFast.WebObjects.Resource.Consumer_Email);
                }

                WebElement AgentResendNotfication = new WebElement().ByXPath("//*[@id='AgentResendNotfication']");
                AgentResendNotfication.Click();

                Thread.Sleep(10000);

                WebElement backBtn = new WebElement().ByXPath("//button[contains(@class, 'ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only')][2]");
                backBtn.Click();
            }

            Thread.Sleep(2000);
        }
    }
}