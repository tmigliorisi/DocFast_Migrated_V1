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
        public void DoAgentEdeliver()
        {
            SearchPolicyCreated();

            WebElement ActionClick = new WebElement().ByXPath("//a[contains(@href, 'javascript:ActionClick();')]");
            ActionClick.Click();
            WebElement eSign = new WebElement().ByText("e-Sign and e-Deliver to Consumer");
            eSign.Click();
            
            Thread.Sleep(4000);

            WebElement dsCbx = new WebElement().ByXPath("//input[@class='checkbox']");
            dsCbx.Click();

            Thread.Sleep(2000);

            WebElement btnContinue = new WebElement().ByXPath("//button[@id='action-bar-btn-continue']");
            btnContinue.Click();

            Thread.Sleep(2000);

            WebElement btnInline = new WebElement().ByXPath("//button[@id='ds_hldrBdy_navnexttext_btnInline']");
            btnInline.Click();

            Thread.Sleep(2000);

            WebElement signHere = new WebElement().ByXPath("//button[@title='Sign Here']");
            signHere.Click();
            
            Thread.Sleep(2000);

            WebElement btnFinish = new WebElement().ByXPath("//button[@id='action-bar-bottom-btn-finish']");
            btnFinish.Click();

            Thread.Sleep(4000);
            
            WebElement FTFAnswerYes = new WebElement().ByXPath("//input[contains(@id, 'FTFAnswerYes')]");

            if (FTFAnswerYes.Displayed)
            {
                if (FTFAnswerYes.Selected)
                {
                    WebElement FTFAnswerNo = new WebElement().ByXPath("//input[contains(@id, 'FTFAnswerNo')]");
                    FTFAnswerNo.Click();
                }
            }

            Thread.Sleep(4000);

            WebElement txtEmail = new WebElement().ByXPath("//input[contains(@id, 'txtEmail')]");
            if (txtEmail.InnerHtml.Equals(String.Empty))
            {
                txtEmail.SendKeys(DocFast.WebObjects.Resource.Consumer_Email);
            }

            WebElement AgentResendNotfication = new WebElement().ByXPath("//*[@id='AgentResendNotfication']");
            AgentResendNotfication.Click();

            Thread.Sleep(10000);

            WebElement okBtn = new WebElement().ByXPath("//button[contains(@class, 'ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only')]");
            okBtn.Click();

            Thread.Sleep(2000);
        }
    }
}