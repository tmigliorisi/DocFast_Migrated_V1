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
        public void DoDistributorDecline()
        {
            WebElement ActionClick = new WebElement().ByXPath("//a[contains(@href, 'javascript:ActionClick();')]");
            ActionClick.Click();
            WebElement Decline = new WebElement().ByText("Decline Offer");
            Decline.Click();

            Thread.Sleep(4000);

            WebElement RequestSelected0 = new WebElement().ById("RequestSelected0");
            RequestSelected0.Click();

            if (RequestSelected0.Displayed)
            {
                RequestSelected0.Select("23");
                //foreach (IWebElement option in RequestSelected0.ByTagName(SeleNUnit.WebObjects.Tags.TagNames.Option))
                //{
                //    if (option.GetAttribute("value") == "23") // 3 Other, 19 Reissue as paper, 20 Coverage not as expected, 21 Too expensive, 22 No longer interested, 23 Life situation change (ex: divorce, death, move etc.) etc.
                //    {
                //        option.Click();
                //        break;
                //    }
                //}
            }

            Thread.Sleep(2000);

            WebElement DeclinedOfferReason0 = new WebElement().ById("DeclinedOfferReason0");
            DeclinedOfferReason0.SendKeys("D'O test");

            Thread.Sleep(2000);

            WebElement ButtonSubmitDecline = new WebElement().ById("ButtonSubmitDecline");
            ButtonSubmitDecline.Click();

            Thread.Sleep(10000);

            WebElement okBtn = new WebElement().ByXPath("//button[contains(@class, 'ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only')]");
            okBtn.Click();

            Thread.Sleep(2000);
        }
    }
}