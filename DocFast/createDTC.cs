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
        private void CreateDTC()
        {
            Thread.Sleep(7000);
            WebElement PolicyCreate = new WebElement().ByXPath("//a[contains(@href, 'javascript:PolicyCreate();')]");
            PolicyCreate.Click();

            Thread.Sleep(10000);

            if (PolicyInfo.Product != string.Empty) // Product Type
            {
                WebElement ProductTypeDropDown = new WebElement().ById("ProductTypeDropDown");
                ProductTypeDropDown.SelectByText(PolicyInfo.Product);
            }

            // Policy Number
            WebElement PolicyNumber = new WebElement().ById("PolicyNumber");
            polNbr = DateTime.Now.ToString();
            polNbr = polNbr.Replace(":", "_");
            PolicyNumber.SendKeys(polNbr);

            // Annual Premium
            if (PolicyInfo.AnnualPremium)
            {
                WebElement AnnualPremium = new WebElement().ById("AnnualPremium");

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
            WebElement DeliveryDate = new WebElement().ById("DeliveryDate");
            DeliveryDate.Click();
            WebElement date = new WebElement().ByText(DateTime.Now.Day.ToString());
            date.Click();

            // PDF Document
            if (PolicyInfo.Supplier == "Lincoln")
            {
                WebElement uploadDocumentMulti = new WebElement().ById("uploadDocumentMulti");
                uploadDocumentMulti.SendKeys(DocFast.WebObjects.Resource.PDF_LocationLincoln);
                WebElement LincolnMoneyGuard_Sample1_pdf_Template = new WebElement().ById("LincolnMoneyGuard_Sample1_pdf_Template");
                LincolnMoneyGuard_Sample1_pdf_Template.SelectByText(DocFast.WebObjects.Resource.PDF_TemplateLincoln);
            }
            else if (PolicyInfo.Supplier == "Standard")
            {
                WebElement uploadDocumentMulti = new WebElement().ById("uploadDocumentMulti");
                uploadDocumentMulti.SendKeys(DocFast.WebObjects.Resource.PDF_LocationStd);
                WebElement agentdocs2013_pdf_Template = new WebElement().ById("agentdocs2013_pdf_Template");
                agentdocs2013_pdf_Template.SelectByText(DocFast.WebObjects.Resource.PDF_TemplateStd);
            }
            //else if (PolicyInfo.Supplier == "Standard NY")
            //{
            //    driver.FindElement(By.Id("uploadDocumentMulti")).SendKeys(DocFast.WebObjects.Resource.PDF_LocationStdNY);
            //    new SelectElement(driver.FindElement(By.Id("agentdocs2013_pdf_Template"))).SelectByText(DocFast.WebObjects.Resource.PDF_TemplateStdNY);
            //}
            else
            {
                WebElement uploadDocumentMulti = new WebElement().ById("uploadDocumentMulti");
                uploadDocumentMulti.SendKeys(DocFast.WebObjects.Resource.PDF_LocationTest);
                WebElement iPipeline_Sample_Policy_pdf_Template = new WebElement().ById("1iPipeline_Sample_Policy_pdf_Template");
                iPipeline_Sample_Policy_pdf_Template.SelectByText(DocFast.WebObjects.Resource.PDF_TemplateTest);
            }


            WebElement ESVCbx = new WebElement().ByXPath(".//*[@id='EnforceSignerVisibilityCheckBox']");
            // Enforce Signer Visibility
            if (PolicyInfo.ESV)
            {
                if (!ESVCbx.Selected)
                {
                    ESVCbx.Click();
                }

                WebElement uploadDocumentMulti = new WebElement().ById("uploadDocumentMulti");
                uploadDocumentMulti.Click();
                uploadDocumentMulti.SendKeys(DocFast.WebObjects.Resource.PDFEsv_Location);

                new WebElement().ById("1iPipelineAgentInstructions_pdf_Template").SelectByText(DocFast.WebObjects.Resource.PDFEsv_Template);
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
                WebElement FirstName = new WebElement().ById("FirstName");
                FirstName.SendKeys(DocFast.WebObjects.Resource.CDAC_PI_FN);

                WebElement LastName = new WebElement().ById("LastName");
                LastName.SendKeys(DocFast.WebObjects.Resource.CDAC_PI_LN);
            }
            else // DocuSign ID Check
            {
                WebElement FirstName = new WebElement().ById("FirstName");
                FirstName.SendKeys(DocFast.WebObjects.Resource.PI_IDCheck_FN);

                WebElement LastName = new WebElement().ById("LastName");
                LastName.SendKeys(DocFast.WebObjects.Resource.PI_IDCheck_LN);
            }

            // Authentication
            if (!PolicyInfo.CCQ) // PolicyEX ID Check
            {
                if (!PolicyInfo.Supplier.Equals("Standard") && !PolicyInfo.Supplier.Equals("Standard NY"))
                {
                    WebElement chkConsumerQuizQuestion_1 = new WebElement().ById("chkConsumerQuizQuestion_1");
                    
                    if (chkConsumerQuizQuestion_1.Selected)
                    {
                        chkConsumerQuizQuestion_1.Click();
                    }

                    if (DateTime.Now.Minute % 2 == 0)
                    {
                        WebElement chkConsumerQuizQuestion_3 = new WebElement().ById("chkConsumerQuizQuestion_3");
                        chkConsumerQuizQuestion_3.Click();
                        WebElement txtConsumerQuizAnswerChoiceText_3 = new WebElement().ById("txtConsumerQuizAnswerChoiceText_3");
                        txtConsumerQuizAnswerChoiceText_3.SendKeys(DocFast.WebObjects.Resource.DTC_PI_LN);
                    }
                    else if (DateTime.Now.Minute % 3 == 0)
                    {
                        WebElement chkConsumerQuizQuestion_2 = new WebElement().ById("chkConsumerQuizQuestion_2");
                        chkConsumerQuizQuestion_2.Click();
                        WebElement txtConsumerQuizAnswerChoiceText_2 = new WebElement().ById("txtConsumerQuizAnswerChoiceText_2");
                        txtConsumerQuizAnswerChoiceText_2.SendKeys(DocFast.WebObjects.Resource.Birth_Date);
                    }
                    else
                    {
                        chkConsumerQuizQuestion_1.Click();
                        WebElement txtConsumerQuizAnswerChoiceText_1 = new WebElement().ById("txtConsumerQuizAnswerChoiceText_1");
                        txtConsumerQuizAnswerChoiceText_1.SendKeys(DocFast.WebObjects.Resource.SSN);
                    }
                }
            }
            else // DocuSign ID Check
            {
                new WebElement().ById("DocuSignIDCheckCheckBox").Click();

                WebElement txtAddressLine1 = new WebElement().ById("AddressLine1");
                txtAddressLine1.SendKeys(DocFast.WebObjects.Resource.PI_AddressLine1);

                WebElement txtCity = new WebElement().ById("City");
                txtCity.SendKeys(DocFast.WebObjects.Resource.PI_City);

                new WebElement().ById("StateDropDown").Select(DocFast.WebObjects.Resource.PI_State);

                WebElement txtZip = new WebElement().ById("Zip");
                txtZip.SendKeys(DocFast.WebObjects.Resource.PI_Zip);

                new WebElement().ById("chkConsumerQuizQuestion_1").Click();
            }

            Thread.Sleep(2000);

            // Additional Consumer
            if (PolicyInfo.Additional)
            {
                 new WebElement().ById("AddNewConsumerLinkAboveTable").Click();

                Thread.Sleep(7000);

                WebElement FirstNameAdd = new WebElement().ById("NewConsumerFirstName");
                FirstNameAdd.SendKeys(DocFast.WebObjects.Resource.DTC_PI_FN);

                WebElement LastNameAdd = new WebElement().ById("NewConsumerLastName");
                LastNameAdd.SendKeys(DocFast.WebObjects.Resource.DTC_Add_LN);

                WebElement EmailAdd = new WebElement().ById("NewConsumerEmail");
                EmailAdd.SendKeys(DocFast.WebObjects.Resource.Consumer_Email);

                WebElement CQAdd = new WebElement().ById("txtConsumerQuizAnswerChoiceTextA_1");
                CQAdd.SendKeys("1234");

                new WebElement().ById("btnSave").Click();

                new WebElement().ById("TemplateRolesDropDown0").SelectByText(DocFast.WebObjects.Resource.Template_Add_Role);
            }

            Thread.Sleep(2000);

            // Private Attachment
            if (PolicyInfo.PrivateAttachment)
            {
                if (PolicyInfo.Server == "QA")
                {
                    new WebElement().ById("uploadPrivateDocumentMulti").SendKeys(DocFast.WebObjects.Resource.PA_Location);

                    if (!PolicyInfo.CCQ)
                    {
                        WebElement PrivateConfidentialDocument_pdf_RecipientListCombo = new WebElement().ById("PrivateConfidentialDocument_pdf_RecipientListCombo");
                        PrivateConfidentialDocument_pdf_RecipientListCombo.SelectByText(DocFast.WebObjects.Resource.DTC_PI_FN + " " + DocFast.WebObjects.Resource.DTC_PI_LN);
                    }
                    else
                    {
                        new WebElement().ById("PrivateConfidentialDocument_pdf_RecipientListCombo").SelectByText(DocFast.WebObjects.Resource.PI_IDCheck_FN + " " + DocFast.WebObjects.Resource.PI_IDCheck_LN);
                    }

                    if (DateTime.Now.Minute % 2 == 0)
                    {
                        WebElement PrivateConfidentialDocument_pdf_DocumentTypeCombo = new WebElement().ById("PrivateConfidentialDocument_pdf_DocumentTypeCombo");
                        PrivateConfidentialDocument_pdf_DocumentTypeCombo.ByIndex(1);
                    }
                    else if (DateTime.Now.Minute % 3 == 0)
                    {
                        WebElement PrivateConfidentialDocument_pdf_DocumentTypeCombo = new WebElement().ById("PrivateConfidentialDocument_pdf_DocumentTypeCombo");
                        PrivateConfidentialDocument_pdf_DocumentTypeCombo.ByIndex(2);
                    }
                    else
                    {
                        WebElement PrivateConfidentialDocument_pdf_DocumentTypeCombo = new WebElement().ById("PrivateConfidentialDocument_pdf_DocumentTypeCombo");
                        PrivateConfidentialDocument_pdf_DocumentTypeCombo.ByIndex(3);
                    }
                }
                else
                {
                    new WebElement().ById("uploadPrivateDocumentMulti").SendKeys(DocFast.WebObjects.Resource.PA_Location);

                    if (!PolicyInfo.CCQ)
                    {
                        WebElement PrivateConfidentialDocument_pdf_RecipientListCombo = new WebElement().ById("PrivateConfidentialDocument_pdf_RecipientListCombo");
                        PrivateConfidentialDocument_pdf_RecipientListCombo.SelectByText(DocFast.WebObjects.Resource.DTC_PI_FN + " " + DocFast.WebObjects.Resource.DTC_PI_LN);
                    }
                    else
                    {
                        WebElement PrivateConfidentialDocument_pdf_RecipientListCombo = new WebElement().ById("PrivateConfidentialDocument_pdf_RecipientListCombo");
                        PrivateConfidentialDocument_pdf_RecipientListCombo.SelectByText(DocFast.WebObjects.Resource.PI_IDCheck_FN + " " + DocFast.WebObjects.Resource.PI_IDCheck_LN);
                    }

                    WebElement PrivateConfidentialDocument_pdf_DocumentTypeCombo = new WebElement().ById("PrivateConfidentialDocument_pdf_DocumentTypeCombo");
                    PrivateConfidentialDocument_pdf_DocumentTypeCombo.ByIndex(0);
                }
            }

                    

            // PI Email setup
            CheckPIEmail();

            // Send Policy or Save as Incomplete
            SendOrSave();
        }
    }
}