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

        private void VerifyStatusAndActions(string performed)
        {
            Thread.Sleep(3000);

            // new WebElement().By.PartialLinkText(polNbr)).Click();

            if (currentUser.Equals("Carrier")) // Carrier Dashboard
            {
                if (performed.Equals("Save")) // Save as Incomplete
                {
                    if (!PolicyInfo.AgentRole.Equals("CC") && !PolicyInfo.AgentRole.Equals("CCRO"))
                    {
                        if (new WebElement().ById("PolicyStatusLabel").Text.TrimEnd().Equals("Status: Pending Delivery"))
                        {
                            WebElement actionsList = new WebElement().ByClass("actions-list-detail");
                            string expectedActions = String.Empty;

                            //foreach (IWebElement option in actionsList.ByClass("actions-list-detail-row"))
                            //{
                            //    if (!option.GetAttribute("text").Equals(String.Empty))
                            //    {
                            //        expectedActions += option.GetAttribute("text") + ";";
                            //    }
                                
                            //}
                        }
                    }
                    else
                    {
                        Assert.AreEqual("Status: Incomplete", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                    }
                }
                else if (performed.Equals("Send")) // Send Policy
                {
                    if (PolicyInfo.Flow.Equals("CDAC"))
                    {
                        if (PolicyInfo.DistributorRole.Equals("CC") || PolicyInfo.DistributorRole.Equals("CCRO")) 
                        {
                            if (PolicyInfo.AgentRole.Equals("CC") || PolicyInfo.AgentRole.Equals("CCRO")) // Sent to Consumer
                            {
                                Assert.AreEqual("Status: Sent to Consumer", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                            }
                            else // Sent to Agent
                            {
                                Assert.AreEqual("Status: Sent to Agent", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                            }
                        }
                        else // Sent to Distributor
                        {
                            Assert.AreEqual("Status: Sent to Distributor", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                        }
                    }
                    else if (PolicyInfo.Flow.Equals("CAC-DW") || PolicyInfo.Flow.Equals("CAC-CA"))
                    {
                        if (PolicyInfo.AgentRole.Equals("CC") || PolicyInfo.AgentRole.Equals("CCRO")) // Sent to Consumer
                        {
                            Assert.AreEqual("Status: Sent to Consumer", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                        }
                        else // Sent to Agent
                        {
                            Assert.AreEqual("Status: Sent to Agent", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                        }
                    }
                    else // DTC, Sent to Consumer
                    {
                        Assert.AreEqual("Status: Sent to Consumer", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                    }
                }
            }
            else if (currentUser.Equals("Agent")) // Agent Dashboard
            {
                if (performed.Equals("Save")) // Save as Incomplete
                {
                    Assert.AreEqual("Status: Pending Delivery", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                }
                else if (performed.Equals("Send")) // Send Policy
                {
                    if (PolicyInfo.Flow.Equals("CDAC"))
                    {
                        if (PolicyInfo.DistributorRole.Equals("CC") || PolicyInfo.DistributorRole.Equals("CCRO"))
                        {
                            if (PolicyInfo.AgentRole.Equals("CC") || PolicyInfo.AgentRole.Equals("CCRO")) // Sent to Consumer
                            {
                                Assert.AreEqual("Status: Sent to Consumer", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                            }
                            else // Sent to Agent
                            {
                                Assert.AreEqual("Status: Sent to Agent", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                            }
                        }
                        else // Sent to Distributor
                        {
                            Assert.AreEqual("Status: Sent to Distributor", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                        }
                    }
                    else if (PolicyInfo.Flow.Equals("CAC-DW") || PolicyInfo.Flow.Equals("CAC-CA"))
                    {
                        if (PolicyInfo.AgentRole.Equals("CC") || PolicyInfo.AgentRole.Equals("CCRO")) // Sent to Consumer
                        {
                            Assert.AreEqual("Status: Sent to Consumer", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                        }
                        else // Sent to Agent
                        {
                            Assert.AreEqual("Status: Sent to Agent", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                        }
                    }
                    
                }
            }
            else // Distributor
            {
                if (performed == "Save") // Save as Incomplete
                {
                    Assert.AreEqual("Status: Pending Delivery", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                }
                else if (performed == "Send") // Send Policy
                {
                    if (PolicyInfo.Flow == "CDAC")
                    {
                        if (PolicyInfo.DistributorRole == "CC" || PolicyInfo.DistributorRole == "CCRO")
                        {
                            if (PolicyInfo.AgentRole == "CC" || PolicyInfo.AgentRole == "CCRO") // Sent to Consumer
                            {
                                Assert.AreEqual("Status: Sent to Consumer", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                            }
                            else // Sent to Agent
                            {
                                Assert.AreEqual("Status: Sent to Agent", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                            }
                        }
                        else // Sent to Distributor
                        {
                            Assert.AreEqual("Status: Sent to Distributor", new WebElement().ById("PolicyStatusLabel").Text.TrimEnd());
                        }
                    }
                    
                }
            }
        }

       
        

              
    }
}