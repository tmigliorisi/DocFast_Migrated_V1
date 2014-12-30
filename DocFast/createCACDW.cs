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
        
        private void CreateCACDW()
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
            tbxDeliveryDate.Click();
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
                        txtConsumerQuizAnswerChoiceText_3.SendKeys(DocFast.WebObjects.Resource.CACDW_PI_LN);
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

                FirstNameAdd.SendKeys(DocFast.WebObjects.Resource.CACDW_PI_FN);

                LastNameAdd.SendKeys(DocFast.WebObjects.Resource.CACDW_Add_LN);

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
                        PrivateConfidentialDocument_pdf_RecipientListCombo.SelectByText(DocFast.WebObjects.Resource.CACDW_PI_FN + " " + DocFast.WebObjects.Resource.CACDW_PI_LN);
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
                        PrivateConfidentialDocument_pdf_RecipientListCombo.SelectByText(DocFast.WebObjects.Resource.CACDW_PI_FN + " " + DocFast.WebObjects.Resource.CACDW_PI_LN);
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

            DistributorDropDown.Select(PolicyInfo.DistributorID);

            Thread.Sleep(2000);

            // Agent's Role
            AgentPolicyRole();
           

            // PI Email setup
            CheckPIEmail();

            // Send Policy or Save as Incomplete
            SendOrSave();
        }
    }
}