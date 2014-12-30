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
        
        private void DistributorPolicyRole()
        {
            Thread.Sleep(2000);

            WebElement distributorPolicyRole = new WebElement().ByXPath(".//*[@id='distributorPolicyRole']");
            
            if (PolicyInfo.DistributorRole == "App")
            {
                distributorPolicyRole.InnerHtml.Equals("Approver");
                //foreach (IWebElement option in distributorPolicyRole.FindElements(By.TagName("option")))
                //{
                //    if (option.GetAttribute("value") == "1")
                //    {
                //        option.Click();
                //        break;
                //    }
                //}
            }
            else if (PolicyInfo.DistributorRole == "CC")
            {
                distributorPolicyRole.InnerHtml.Equals("Carbon Copy");

                //foreach (IWebElement option in distributorPolicyRole.FindElements(By.TagName("option")))
                //{
                //    if (option.GetAttribute("value") == "3")
                //    {
                //        option.Click();
                //        break;
                //    }
                //}
            }
            else if (PolicyInfo.DistributorRole == "CCRO")
            {
                distributorPolicyRole.InnerHtml.Equals("Carbon Copy (Read Only)");

                //foreach (IWebElement option in distributorPolicyRole.FindElements(By.TagName("option")))
                //{
                //    if (option.GetAttribute("value") == "4")
                //    {
                //        option.Click();
                //        break;
                //    }
                //}
            }

            Thread.Sleep(2000);
        }

        private void AgentPolicyRole()
        {
            Thread.Sleep(2000);

            WebElement agentPolicyRole = new WebElement().ByXPath(".//*[@id='agentPolicyRole']");
           
            if (PolicyInfo.AgentRole == "App")
            {
                agentPolicyRole.InnerHtml.Equals("Approver");
                //foreach (IWebElement option in agentPolicyRole.FindElements(By.TagName("option")))
                //{
                //    if (option.GetAttribute("value") == "1")
                //    {
                //        option.Click();
                //        break;
                //    }
                //}
            }
            else if (PolicyInfo.AgentRole == "CC")
            {
                agentPolicyRole.InnerHtml.Equals("Carbon Copy");

                //foreach (IWebElement option in agentPolicyRole.FindElements(By.TagName("option")))
                //{
                //    if (option.GetAttribute("value") == "3")
                //    {
                //        option.Click();
                //        break;
                //    }
                //}
            }
            else if (PolicyInfo.AgentRole == "CCRO")
            {
                agentPolicyRole.InnerHtml.Equals("Carbon Copy (Read Only)");

                //foreach (IWebElement option in agentPolicyRole.FindElements(By.TagName("option")))
                //{
                //    if (option.GetAttribute("value") == "4")
                //    {
                //        option.Click();
                //        break;
                //    }
                //}
            }
        }

       
    }
}