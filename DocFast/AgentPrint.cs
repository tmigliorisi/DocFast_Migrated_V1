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
        public void DoAgentPrint()
        {
            SearchPolicyCreated();

            WebElement ActionClick = new WebElement().ByXPath("//a[contains(@href, 'javascript:ActionClick();')]");
            ActionClick.Click();
            WebElement print = new WebElement().ByText("Print and Hand Deliver");
            print.Click();

            Thread.Sleep(4000);

            if (PolicyInfo.PrivateAttachment) // if policy has private attachment
            {
                WebElement txtEmail = new WebElement().ByXPath("//input[contains(@id, 'consumerAttachmentEmail_')]");

                if (txtEmail.InnerHtml.Equals(String.Empty))
                {
                    txtEmail.SendKeys(DocFast.WebObjects.Resource.Consumer_Email);
                }
            }

            WebElement printAct = new WebElement().ById("PrintAndHandDeliver");
            printAct.Click();

            Thread.Sleep(4000);

            //driver.SwitchTo().Window(driver.WindowHandles.ToList().Last()); // switches to the new window
            //driver.Close(); // Now closes the new window
            //Thread.Sleep(2000);
            //driver.SwitchTo().Window(driver.WindowHandles.ToList().Last()); // switches back to the parent window

            Thread.Sleep(10000);

            WebElement okBtn = new WebElement().ByXPath("//button[contains(@class, 'ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only')]");
            okBtn.Click();

            Thread.Sleep(2000);
        }
    }
}