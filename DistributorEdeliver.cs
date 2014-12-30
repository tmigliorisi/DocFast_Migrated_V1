﻿using System;
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

namespace DocFast
{
    [TestFixture]
    public partial class RT
    {
        public void DoDistributorEdeliver()
        {
            SearchPolicyCreated();

            driver.FindElement(By.XPath("//a[contains(@href, 'javascript:ActionClick();')]")).Click();
            driver.FindElement(By.LinkText("e-Deliver to Agent")).Click();
            Thread.Sleep(4000);

            driver.FindElement(By.XPath(".//*[@id='SendPolicytoAgent']")).Click();
            
            Thread.Sleep(10000);
            
            if (newPol.AgentRole == "CC" || newPol.AgentRole == "CCRO")
            {
                if (driver.FindElement(By.XPath("//input[contains(@id, 'txtEmail')]")).GetAttribute("value").Equals(String.Empty))
                {
                    driver.FindElement(By.XPath("//input[contains(@id, 'txtEmail')]")).SendKeys(DocFast.Resource.Consumer_Email);
                }

                driver.FindElement(By.XPath("//*[@id='AgentResendNotfication']")).Click();

                Thread.Sleep(10000);

                driver.FindElement(By.XPath("//button[contains(@class, 'ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only')][2]")).Click();
            }

            Thread.Sleep(2000);
        }
    }
}