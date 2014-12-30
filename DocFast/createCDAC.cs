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

        #region Elements

        private static readonly WebElement PolicyCreate = new WebElement().ByXPath("//a[contains(@href, 'javascript:PolicyCreate();')]");
        private static readonly WebElement ProductTypeDropDown = new WebElement().ById("ProductTypeDropDown");
        private static readonly WebElement PolicyNumber = new WebElement().ById("PolicyNumber");
        private static readonly WebElement AnnualPremium = new WebElement().ById("AnnualPremium");
        private static readonly WebElement tbxDeliveryDate = new WebElement().ById("DeliveryDate");
        private static readonly WebElement uploadDocumentMulti = new WebElement().ById("uploadDocumentMulti");
        private static readonly WebElement LincolnMoneyGuard_Sample1_pdf_Template = new WebElement().ById("LincolnMoneyGuard_Sample1_pdf_Template");
        private static readonly WebElement agentdocs2013_pdf_Template = new WebElement().ById("agentdocs2013_pdf_Template");
        private static readonly WebElement iPipeline_Sample_Policy_pdf_Template = new WebElement().ById("1iPipeline_Sample_Policy_pdf_Template");
        private static readonly WebElement ESVCbx = new WebElement().ByXPath(".//*[@id='EnforceSignerVisibilityCheckBox']");
        private static readonly WebElement iPipelineAgentInstructions_pdf_Template = new WebElement().ById("1iPipelineAgentInstructions_pdf_Template");
        private static readonly WebElement FirstName = new WebElement().ById("FirstName");
        private static readonly WebElement LastName = new WebElement().ById("LastName");
        private static readonly WebElement chkConsumerQuizQuestion_1 = new WebElement().ById("chkConsumerQuizQuestion_1");
        private static readonly WebElement chkConsumerQuizQuestion_3 = new WebElement().ById("chkConsumerQuizQuestion_3");
        private static readonly WebElement txtConsumerQuizAnswerChoiceText_3 = new WebElement().ById("txtConsumerQuizAnswerChoiceText_3");
        private static readonly WebElement chkConsumerQuizQuestion_2 = new WebElement().ById("chkConsumerQuizQuestion_2");
        private static readonly WebElement txtConsumerQuizAnswerChoiceText_2 = new WebElement().ById("txtConsumerQuizAnswerChoiceText_2");
        private static readonly WebElement txtConsumerQuizAnswerChoiceText_1 = new WebElement().ById("txtConsumerQuizAnswerChoiceText_1");
        private static readonly WebElement txtLastFourDigitsSSN = new WebElement().ById("LastFourDigitsSSN");
        private static readonly WebElement DocuSignIDCheckCheckBox = new WebElement().ById("DocuSignIDCheckCheckBox");
        private static readonly WebElement txtAddressLine1 = new WebElement().ById("AddressLine1");
        private static readonly WebElement txtCity = new WebElement().ById("City");
        private static readonly WebElement StateDropDown = new WebElement().ById("StateDropDown");
        private static readonly WebElement txtZip = new WebElement().ById("Zip");
        private static readonly WebElement AddNewConsumerLinkAboveTable = new WebElement().ById("AddNewConsumerLinkAboveTable");
        private static readonly WebElement FirstNameAdd = new WebElement().ById("NewConsumerFirstName");
        private static readonly WebElement LastNameAdd = new WebElement().ById("NewConsumerLastName");
        private static readonly WebElement EmailAdd = new WebElement().ById("NewConsumerEmail");
        private static readonly WebElement CQAdd = new WebElement().ById("txtConsumerQuizAnswerChoiceTextA_1");
        private static readonly WebElement btnSave = new WebElement().ById("btnSave");
        private static readonly WebElement TemplateRolesDropDown0 = new WebElement().ById("TemplateRolesDropDown0");
        private static readonly WebElement uploadPrivateDocumentMulti = new WebElement().ById("uploadPrivateDocumentMulti");
        private static readonly WebElement PrivateConfidentialDocument_pdf_RecipientListCombo = new WebElement().ById("PrivateConfidentialDocument_pdf_RecipientListCombo");
        private static readonly WebElement PrivateConfidentialDocument_pdf_DocumentTypeCombo = new WebElement().ById("PrivateConfidentialDocument_pdf_DocumentTypeCombo");
        private static readonly WebElement DistributorCheckBox = new WebElement().ById("DistributorCheckBox");
        private static readonly WebElement DistributorDropDown = new WebElement().ById("DistributorDropDown");
        private static readonly WebElement CaseManagerID = new WebElement().ByXPath(".//*[@id='CaseManagerID']");
        private static readonly WebElement AgentCheckBox = new WebElement().ById("AgentCheckBox");
        private static readonly WebElement findagent = new WebElement().ById("find-agent");
        private static readonly WebElement AgentSearchFirstName = new WebElement().ById("AgentSearchFirstName");
        private static readonly WebElement AgentSearchLastName = new WebElement().ById("AgentSearchLastName");
        private static readonly WebElement AgentSearchEmail = new WebElement().ById("AgentSearchEmail");
        private static readonly WebElement AgentSearchButton = new WebElement().ById("AgentSearchButton");
        private static readonly WebElement Agent = new WebElement().ByXPath(".//*[@id='divAgentList']");
        private static readonly WebElement SelectAgent = new WebElement().ById("SelectAgent");

        #endregion

        private void CreateCDAC()
        {
            Thread.Sleep(7000);
                        
            PolicyCreate.Click();

            Thread.Sleep(10000);

            if (PolicyInfo.Product != string.Empty) // Product Type
            {
                ProductTypeDropDown.SelectByText(PolicyInfo.Product);
            }

            // Policy Number
            polNbr = DateTime.Now.ToString();
            polNbr = polNbr.Replace(":", "_");
            PolicyNumber.SendKeys(polNbr);

            Thread.Sleep(2000);

            // Annual Premium
            if (PolicyInfo.AnnualPremium)
            {
                              
                if (DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
                {
                    AnnualPremium.SendKeys("1234");
                }
                else
                {
                    AnnualPremium.SendKeys(DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
                }
            }

            Thread.Sleep(2000);

            // Delivery Date
            tbxDeliveryDate.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            
            //WebElement DeliveryDate = new WebElement().ByLinkText(DateTime.Now.Day.ToString());
            //DeliveryDate.Click();

            // PDF Document
            if (PolicyInfo.Supplier == "Lincoln")
            {
                uploadDocumentMulti.SendKeys(DocFast.WebObjects.Resource.PDF_LocationLincoln);
                LincolnMoneyGuard_Sample1_pdf_Template.SelectByText(DocFast.WebObjects.Resource.PDF_TemplateLincoln);
            }
            else if (PolicyInfo.Supplier == "Standard")
            {
                uploadDocumentMulti.SendKeys(DocFast.WebObjects.Resource.PDF_LocationStd);
                agentdocs2013_pdf_Template.SelectByText(DocFast.WebObjects.Resource.PDF_TemplateStd);
            }
            //else if (PolicyInfo.Supplier == "Standard NY")
            //{
            //    driver.FindElement(By.Id("uploadDocumentMulti")).SendKeys(DocFast.WebObjects.Resource.PDF_LocationStdNY);
            //    new SelectElement(driver.FindElement(By.Id("agentdocs2013_pdf_Template"))).SelectByText(DocFast.WebObjects.Resource.PDF_TemplateStdNY);
            //}
            else
            {
                uploadDocumentMulti.SendKeys(DocFast.WebObjects.Resource.PDF_LocationTest);
                iPipeline_Sample_Policy_pdf_Template.SelectByText(DocFast.WebObjects.Resource.PDF_TemplateTest);
                
            }

           
            // Enforce Signer Visibility
            if (PolicyInfo.ESV)
            {
                if (!ESVCbx.Selected)
                {
                    ESVCbx.Click();
                }

                uploadDocumentMulti.Click();
                uploadDocumentMulti.SendKeys(DocFast.WebObjects.Resource.PDFEsv_Location);
                iPipelineAgentInstructions_pdf_Template.SelectByText(DocFast.WebObjects.Resource.PDFEsv_Template);
                
            }
            else
            {
                if (ESVCbx.Selected)
                {
                    ESVCbx.Click();
                }
            }

            Thread.Sleep(2000);
            
            // First Name and Last Name
            if (!PolicyInfo.CCQ) // PolicyEX ID Check
            {
                FirstName.SendKeys(DocFast.WebObjects.Resource.CDAC_PI_FN);
              
                LastName.SendKeys(DocFast.WebObjects.Resource.CDAC_PI_LN);
            }
            else // DocuSign ID Check
            {
                FirstName.SendKeys(DocFast.WebObjects.Resource.PI_IDCheck_FN);

                LastName.SendKeys(DocFast.WebObjects.Resource.PI_IDCheck_LN);
            }

            // Authentication
            if (!PolicyInfo.CCQ) // PolicyEX ID Check
            {
                if (!PolicyInfo.Supplier.Equals("Standard") && !PolicyInfo.Supplier.Equals("Standard NY"))
                {
                    
                    if (chkConsumerQuizQuestion_1.Selected)
                    {
                        chkConsumerQuizQuestion_1.Click();
                    }

                    if (DateTime.Now.Minute % 2 == 0)
                    {
                        chkConsumerQuizQuestion_3.Click();
                        txtConsumerQuizAnswerChoiceText_3.SendKeys(DocFast.WebObjects.Resource.CDAC_PI_LN);
                    }
                    else if (DateTime.Now.Minute % 3 == 0)
                    {
                        chkConsumerQuizQuestion_2.Click();
                        txtConsumerQuizAnswerChoiceText_2.SendKeys(DocFast.WebObjects.Resource.Birth_Date);
                    }
                    else
                    {
                        chkConsumerQuizQuestion_1.Click();
                        txtConsumerQuizAnswerChoiceText_1.SendKeys(DocFast.WebObjects.Resource.SSN);
                    }
                }
                else
                {
                    txtLastFourDigitsSSN.SendKeys(DocFast.WebObjects.Resource.SSN);
                }
            }
            else // DocuSign ID Check
            {
                DocuSignIDCheckCheckBox.Click();

                txtAddressLine1.SendKeys(DocFast.WebObjects.Resource.PI_AddressLine1);
                txtCity.SendKeys(DocFast.WebObjects.Resource.PI_City);
                StateDropDown.Select(DocFast.WebObjects.Resource.PI_State);
                txtZip.SendKeys(DocFast.WebObjects.Resource.PI_Zip);
                chkConsumerQuizQuestion_1.Click();
            }

            Thread.Sleep(2000);

            // Additional Consumer
            if (PolicyInfo.Additional)
            {
                AddNewConsumerLinkAboveTable.Click();

                Thread.Sleep(7000);

                FirstNameAdd.SendKeys(DocFast.WebObjects.Resource.CDAC_PI_FN);
                LastNameAdd.SendKeys(DocFast.WebObjects.Resource.CDAC_Add_LN);
                EmailAdd.SendKeys(DocFast.WebObjects.Resource.Consumer_Email);
                CQAdd.SendKeys("1234");
                btnSave.Click();
                TemplateRolesDropDown0.SelectByText(DocFast.WebObjects.Resource.Template_Add_Role);
            }

            Thread.Sleep(2000);

            // Private Attachment
            if (PolicyInfo.PrivateAttachment)
            {
                if (PolicyInfo.Server == "QA")
                {
                    uploadPrivateDocumentMulti.SendKeys(DocFast.WebObjects.Resource.PA_Location);

                    if (!PolicyInfo.CCQ)
                    {
                        PrivateConfidentialDocument_pdf_RecipientListCombo.SelectByText(DocFast.WebObjects.Resource.CDAC_PI_FN + " " + DocFast.WebObjects.Resource.CDAC_PI_LN);
                    }
                    else
                    {
                        PrivateConfidentialDocument_pdf_RecipientListCombo.SelectByText(DocFast.WebObjects.Resource.PI_IDCheck_FN + " " + DocFast.WebObjects.Resource.PI_IDCheck_LN);
                    }

                    if (DateTime.Now.Minute % 2 == 0)
                    {
                        PrivateConfidentialDocument_pdf_DocumentTypeCombo.ByIndex(1);
                    }
                    else if (DateTime.Now.Minute % 3 == 0)
                    {
                        PrivateConfidentialDocument_pdf_DocumentTypeCombo.ByIndex(2);
                    }
                    else
                    {
                        PrivateConfidentialDocument_pdf_DocumentTypeCombo.ByIndex(3);
                    }
                }
                else
                {
                    uploadPrivateDocumentMulti.SendKeys(DocFast.WebObjects.Resource.PA_Location);

                    if (!PolicyInfo.CCQ)
                    {
                        PrivateConfidentialDocument_pdf_RecipientListCombo.SelectByText(DocFast.WebObjects.Resource.CDAC_PI_FN + " " + DocFast.WebObjects.Resource.CDAC_PI_LN);
                    }
                    else
                    {
                        PrivateConfidentialDocument_pdf_RecipientListCombo.SelectByText(DocFast.WebObjects.Resource.PI_IDCheck_FN + " " + DocFast.WebObjects.Resource.PI_IDCheck_LN);
                    }

                    PrivateConfidentialDocument_pdf_DocumentTypeCombo.ByIndex(0);
                }
            }

            // Distributor
            DistributorCheckBox.Click();
            DistributorDropDown.Select(Convert.ToInt32(PolicyInfo.DistributorID));
            
            Thread.Sleep(2000);

            // Distributor Case Manager
            CaseManagerID.Select(PolicyInfo.DCMID);

            //foreach (IWebElement option in CaseManagerID.ByTagName(SeleNUnit.WebObjects.Tags.TagNames.Option))
            //{
            //    if (option.GetAttribute("value") == PolicyInfo.DCMID) // QA = 60 DCM_4, 56 DCMA_4, 333 Maggie's; UAT = 627 DCM_2, 624 DCMA_2
            //    {
            //        option.Click();
            //        break;
            //    }
            //}
                        
            Thread.Sleep(2000);

            // Distributor's Role
            DistributorPolicyRole();

            // Agent setup
            if (PolicyInfo.AgentID != "0") // No Agent
            {
                AgentCheckBox.Click();
                findagent.Click();
                string searchField = PolicyInfo.AgentSearch.Substring(3,PolicyInfo.AgentSearch.Count()-3);

                if (PolicyInfo.AgentSearch.Contains("FN")) // Search by FN
                {
                    AgentSearchFirstName.SendKeys(searchField);
                }
                else if (PolicyInfo.AgentSearch.Contains("LN")) // Search by LN
                {
                    AgentSearchLastName.SendKeys(searchField);
                }
                else // Search by Email
                {
                    AgentSearchEmail.SendKeys(searchField);
                }

                AgentSearchButton.Click();

                Thread.Sleep(2000);
                    
                Agent.ByName("AgentListRadio").Select(PolicyInfo.AgentID);
                //foreach (IWebElement option in Agent.ByName("AgentListRadio"))
                //{
                //    if (option.GetAttribute("value") == PolicyInfo.AgentID) // QA = 64 A_4, 400 IA_3, 334 Maggie's ; UAT = 631 
                //    {
                //        option.Click();
                //        break;
                //    }
                //}

                SelectAgent.Click();

                Thread.Sleep(2000);

                // Agent's Role
                AgentPolicyRole();
            }
            
            // PI Email setup
            CheckPIEmail();

            // Send Policy or Save as Incomplete
            SendOrSave();
        }
    }
}