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

        public string username { get; set; }

        private string currentUser = "Carrier";
        public string CurrentUser
        {   get {   return currentUser; }
        set {   currentUser = value;    }
        }

        private Policy policyInfo;
        public Policy PolicyInfo  
        {
            get {   return policyInfo;  }
            set {   policyInfo = value; }
        }

        public void DoAction()
        {
            GoToUrl(username);
           
            if (PolicyInfo.Flow == "CDAC") // CDAC actions
            {
                if (currentUser == "Carrier")
                {
                    CreateCDAC();
                    SearchPolicyCreated();
                    VerifyStatusAndActions(PolicyInfo.SaveOrSend);

                    Thread.Sleep(4000);
                    

                    WebElement GoToDashboardLink = new WebElement().ById("GoToDashboardLink");
                    GoToDashboardLink.Click();

                    if (PolicyInfo.Actor.Equals("CCM") || PolicyInfo.Actor.Equals("CCMA"))
                    {
                        if (PolicyInfo.Action == "Send")
                        {
                            DoCarrierSend();
                        }
                        else if (PolicyInfo.Action == "Cancel")
                        {
                            DoCarrierCancel();
                        }
                        else if (PolicyInfo.Action == "Print")
                        {
                            DoCarrierPrint();
                        }
                        else if (PolicyInfo.Action == "Approve")
                        {
                            DoCarrierApprove();
                        }
                        else if (PolicyInfo.Action == "Transfer")
                        {
                            DoCarrierTransfer();
                        }
                        else if (PolicyInfo.Action == "Change")
                        {
                            DoCarrierChange();
                        }
                        else if (PolicyInfo.Action == "Resend")
                        {
                            DoCarrierResend();
                        }
                        else if (PolicyInfo.Action == "Take")
                        {
                            DoCarrierTake();
                        }
                        else if (PolicyInfo.Action == "Decline")
                        {
                            LogOut();
                            if (PolicyInfo.DistributorRole.Equals("CCRO")) // Agent makes the request
                            {
                                GoToUrl(PolicyInfo.Agent);
                                DoAgentRequestExt();
                                
                            }
                            else // Distributor makes the request
                            {
                                GoToUrl(PolicyInfo.Distributor);
                                DoDistributorRequestExt();
                                
                            }

                            LogOut();
                            GoToUrl(PolicyInfo.Carrier);
                            DoCarrierDecline();
                        }
          
                    }

                    LogOut();
                    
                    if (PolicyInfo.Actor == "DCM")
                    {
                        currentUser = "Distributor";
                        GoToUrl(PolicyInfo.Distributor);
                        DoAction();
                    }
                    else if (PolicyInfo.Actor == "DCMA")
                    {
                        currentUser = "Distributor";
                       
                    }
                    else if (PolicyInfo.Actor == "Agent")
                    {
                        if (!PolicyInfo.DistributorRole.Equals("CC") && !PolicyInfo.DistributorRole.Equals("CCRO"))
                        {
                            GoToUrl(PolicyInfo.Distributor);
                            DoDistributorEdeliver();
                            LogOut();
                        }

                        currentUser = "Agent";
                        GoToUrl(PolicyInfo.Agent);
                        DoAction();

                    }
                    
                }

                if (currentUser == "Distributor")
                {
                    
                    if (PolicyInfo.Action == "e-Deliver")
                    {
                        DoDistributorEdeliver();
                    }
                    else if (PolicyInfo.Action == "Print")
                    {
                        DoDistributorPrint();
                    }
                    else if (PolicyInfo.Action == "Change")
                    {
                        DoDistributorChange();
                    }
                    else if (PolicyInfo.Action == "Resend")
                    {
                        if (!PolicyInfo.DistributorRole.Equals("CC") && !PolicyInfo.DistributorRole.Equals("CCRO"))
                        {
                            DoDistributorEdeliver();

                        }

                        DoDistributorResend();
                    }
                    else if (PolicyInfo.Action == "Transfer")
                    {
                        DoDistributorTransfer();
                    }
                    else if (PolicyInfo.Action == "TransferSubGA")
                    {
                        DoDistributorTransferSubGA();
                    }
                    else if (PolicyInfo.Action == "Take")
                    {
                        DoDistributorTake();
                    }
                    else if (PolicyInfo.Action == "CancelChange")
                    {
                        DoDistributorChange();

                        Thread.Sleep(2000);

                        DoDistributorCancelChange();
                    }
                    else if (PolicyInfo.Action == "RequestExt")
                    {
                        DoDistributorRequestExt();
                    }

                    LogOut();

                    if (PolicyInfo.Actor == "Agent")
                    {
                        currentUser = "Agent";
                        GoToUrl(PolicyInfo.Agent);
                        DoAction();
                    }
                    else
                    {
                        currentUser = String.Empty;
                    }

                }

                if (currentUser == "Agent")
                {
                    
                    if (PolicyInfo.Action == "e-Deliver")
                    {
                        DoAgentEdeliver();
                    }
                    else if (PolicyInfo.Action == "Print")
                    {
                        DoAgentPrint();
                    }
                    else if (PolicyInfo.Action == "Change")
                    {
                        DoAgentChange();
                    }
                    else if (PolicyInfo.Action == "Decline")
                    {
                        DoAgentDecline();
                    }
                    else if (PolicyInfo.Action == "CancelChange")
                    {
                        DoAgentChange();

                        Thread.Sleep(2000);

                        DoAgentCancelChange();
                    }
                    else if (PolicyInfo.Action == "RequestExt")
                    {
                        DoAgentRequestExt();
                    }

                    LogOut();

                    currentUser = String.Empty;
                }
                
            }
            else if (PolicyInfo.Flow == "CAC-DW")
            {
                if (currentUser == "Carrier")
                {
                    CreateCACDW();
                    SearchPolicyCreated();
                    VerifyStatusAndActions(PolicyInfo.SaveOrSend);

                    Thread.Sleep(4000);

                    WebElement GoToDashboardLink = new WebElement().ById("GoToDashboardLink");
                    GoToDashboardLink.Click();

                    if (PolicyInfo.Actor == "CCM")
                    {
                        
                        if (PolicyInfo.Action == "Send")
                        {
                            DoCarrierSend();
                        }
                        else if (PolicyInfo.Action == "Cancel")
                        {
                            DoCarrierCancel();
                        }
                        else if (PolicyInfo.Action == "Print")
                        {
                            DoCarrierPrint();
                        }
                        else if (PolicyInfo.Action == "Approve")
                        {
                            DoCarrierApprove();
                        }
                        else if (PolicyInfo.Action == "Transfer")
                        {
                            DoCarrierTransfer();
                        }
                        else if (PolicyInfo.Action == "Change")
                        {
                            DoCarrierChange();
                        }
                        else if (PolicyInfo.Action == "Resend")
                        {
                            DoCarrierResend();
                        }
                        else if (PolicyInfo.Action == "Take")
                        {
                            DoCarrierTake();
                        }
                        else if (PolicyInfo.Action == "Decline")
                        {
                            LogOut();
                            GoToUrl(PolicyInfo.Agent);
                            DoAgentRequestExt();

                            LogOut();
                            GoToUrl(PolicyInfo.Carrier);
                            DoCarrierDecline();
                        }
                    }

                    LogOut();


                    if (PolicyInfo.Actor == "Agent")
                    {
                        currentUser = "Agent";
                        GoToUrl(PolicyInfo.Agent);
                        DoAction();
                        currentUser = String.Empty;
                    }
                }


                if (currentUser == "Agent")
                {
                   
                    if (PolicyInfo.Action == "e-Deliver")
                    {
                        DoAgentEdeliver();
                    }
                    else if (PolicyInfo.Action == "Print")
                    {
                        DoAgentPrint();
                    }
                    else if (PolicyInfo.Action == "Change")
                    {
                        DoAgentChange();
                    }
                    else if (PolicyInfo.Action == "Decline")
                    {
                        DoAgentDecline();
                    }
                    else if (PolicyInfo.Action == "CancelChange")
                    {
                        DoAgentChange();

                        Thread.Sleep(2000);

                        DoAgentCancelChange();
                    }
                    else if (PolicyInfo.Action == "RequestExt")
                    {
                        DoAgentRequestExt();
                    }

                    LogOut();

                 }
            }
            else if (PolicyInfo.Flow == "CAC-CA")
            {
                if (currentUser == "Carrier")
                {
                    CreateCACCA();
                    SearchPolicyCreated();
                    VerifyStatusAndActions(PolicyInfo.SaveOrSend);

                    Thread.Sleep(4000);

                    WebElement GoToDashboardLink = new WebElement().ById("GoToDashboardLink");
                    GoToDashboardLink.Click();

                    if (PolicyInfo.Actor == "CCM")
                    {
                        
                        if (PolicyInfo.Action == "Send")
                        {
                            DoCarrierSend();
                        }
                        else if (PolicyInfo.Action == "Cancel")
                        {
                            DoCarrierCancel();
                        }
                        else if (PolicyInfo.Action == "Print")
                        {
                            DoCarrierPrint();
                        }
                        else if (PolicyInfo.Action == "Approve")
                        {
                            DoCarrierApprove();
                        }
                        else if (PolicyInfo.Action == "Transfer")
                        {
                            DoCarrierTransfer();
                        }
                        else if (PolicyInfo.Action == "Change")
                        {
                            DoCarrierChange();
                        }
                        else if (PolicyInfo.Action == "Resend")
                        {
                            DoCarrierResend();
                        }
                        else if (PolicyInfo.Action == "Take")
                        {
                            DoCarrierTake();
                        }
                        else if (PolicyInfo.Action == "Decline")
                        {
                            LogOut();
                            GoToUrl(PolicyInfo.Agent);
                            DoAgentRequestExt();

                            LogOut();
                            GoToUrl(PolicyInfo.Carrier);
                            DoCarrierDecline();
                        }
                    }

                    LogOut();

                    if (PolicyInfo.Actor == "Agent")
                    {
                        currentUser = "Agent";
                        GoToUrl(PolicyInfo.Agent);
                        DoAction();
                        currentUser = String.Empty;
                    }
                }


                if (currentUser == "Agent")
                {
                    
                    if (PolicyInfo.Action == "e-Deliver")
                    {
                        DoAgentEdeliver();
                    }
                    else if (PolicyInfo.Action == "Print")
                    {
                        DoAgentPrint();
                    }
                    else if (PolicyInfo.Action == "Change")
                    {
                        DoAgentChange();
                    }
                    else if (PolicyInfo.Action == "Decline")
                    {
                        DoAgentDecline();
                    }
                    else if (PolicyInfo.Action == "CancelChange")
                    {
                        DoAgentChange();

                        Thread.Sleep(2000);

                        DoAgentCancelChange();
                    }
                    else if (PolicyInfo.Action == "RequestExt")
                    {
                        DoAgentRequestExt();
                    }

                    LogOut();

                }
            }
            else // DTC
            {
                if (currentUser == "Carrier")
                {
                    CreateDTC();
                    SearchPolicyCreated();
                    VerifyStatusAndActions(PolicyInfo.SaveOrSend);

                    Thread.Sleep(4000);

                    WebElement GoToDashboardLink = new WebElement().ById("GoToDashboardLink");
                    GoToDashboardLink.Click();
                   
                    if (PolicyInfo.Action == "Send")
                    {
                        DoCarrierSend();
                    }
                    else if (PolicyInfo.Action == "Cancel")
                    {
                        DoCarrierCancel();
                    }
                    else if (PolicyInfo.Action == "Print")
                    {
                        DoCarrierPrint();
                    }
                    else if (PolicyInfo.Action == "Approve")
                    {
                        DoCarrierApprove();
                    }
                    else if (PolicyInfo.Action == "Transfer")
                    {
                        DoCarrierTransfer();
                    }
                    else if (PolicyInfo.Action == "Change")
                    {
                        DoCarrierChange();
                    }
                    else if (PolicyInfo.Action == "Resend")
                    {
                        DoCarrierResend();
                    }
                    else if (PolicyInfo.Action == "Take")
                    {
                        DoCarrierTake();
                    }
                }

                LogOut();
            }

            
        }

        public struct Policy
        {
            public string Server;
            public string Browser;
            public string Flow;
            public string DistributorRole;
            public string AgentRole;
            public string Product;
            public bool AnnualPremium;
            public bool ESV;
            public bool CCQ;
            public bool CQ;
            public bool Additional;
            public bool PrivateAttachment;
            public bool NewAgent;
            public bool PIEmail;
            public string SaveOrSend;
            public string Actor;
            public string Action;
            public string Supplier;
            public string DistributorID;
            public string DCMID;
            public string AgentID;
            public string AgentSearch;
            public string Carrier;
            public string Distributor;
            public string Agent;

        }

        private void SearchPolicyCreated()
        {
            Thread.Sleep(7000);

            WebElement SearchTextBox = new WebElement().ByXPath(".//*[@id='SearchTextBox']");
            SearchTextBox.SendKeys(polNbr);

            WebElement A3 = new WebElement().ByXPath(".//*[@id='A3']/img");
            A3.Click();

            Thread.Sleep(2000);
        }

        private void CheckPIEmail()
        {
            Thread.Sleep(2000);

            if (PolicyInfo.PIEmail)
            {
                WebElement ConsumerEmail = new WebElement().ById("ConsumerEmail");
                ConsumerEmail.SendKeys(DocFast.WebObjects.Resource.Consumer_Email);
            }

        }
        
        private void SendOrSave()
        {
            if (PolicyInfo.SaveOrSend == "Send") // Send Policy
            {
                WebElement btnSend = new WebElement().ByXPath(".//*[@id='add-policy-btn']");
                btnSend.Click();
                
            }
            else // Save as Incomplete
            {
                WebElement btnSaveAsIncomplete = new WebElement().ByXPath(".//*[@id='btnSaveAsIncomplete']");
                btnSaveAsIncomplete.Click();
                
            }

            Thread.Sleep(25000);

            WebElement GoToDashboardLink = new WebElement().ById("GoToDashboardLink");
            GoToDashboardLink.Click();
        }

        public string polNbr { get; set; }

        public void GoToUrl(string username)
        {

            if (PolicyInfo.Server == "QA")
            {
                new RSALogin().DoLogin(DocFast.WebObjects.Resource.QA_Url, username, DocFast.WebObjects.Resource.User_Pwd);
            }
            else if (PolicyInfo.Server == "UAT")
            {
                new RSALogin().DoLogin(DocFast.WebObjects.Resource.UAT_Url, username, DocFast.WebObjects.Resource.User_Pwd);
            }
            else if (PolicyInfo.Server == "QA2")
            {
                new RSALogin().DoLogin(DocFast.WebObjects.Resource.QA2_Url, username, DocFast.WebObjects.Resource.User_Pwd);
            }
            else if (PolicyInfo.Server == "PROD")
            {
                new RSALogin().DoLogin(DocFast.WebObjects.Resource.PROD_Url, username, DocFast.WebObjects.Resource.User_Pwd);
            }

            Thread.Sleep(2000);
        }


        private void LogOut()
        {
            WebElement A1 = new WebElement().ByXPath("//a[contains(@href, '/cleartrust/ct_logout.asp')]");
            A1.Click();

            Thread.Sleep(2000);

            Browser.Quit();
                        
        }
        
    }
}