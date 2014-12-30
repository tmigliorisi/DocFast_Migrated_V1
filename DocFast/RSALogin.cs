using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleNUnit.WebObjects.WebElement;
using SeleNUnit.WebObjects.Tags;
using SeleNUnit.WebObjects;

namespace DocFast.WebObjects
{
    public class RSALogin : PageBase
    {

        #region Elements

        private static readonly WebElement User = new WebElement().ByName("user");
        private static readonly WebElement Password = new WebElement().ByName("password");
        private static readonly WebElement Submit = new WebElement().ByName("Submit");

        #endregion



        public void Open(string urlParams)
        {

           //var url = GetUriByRelativePath(urlParams);

            Navigate(urlParams);
        }

        public void DoLogin(string urlParams, string userName, string password)
        {
            this.Open(urlParams);
            User.SendKeys(userName);
            Password.SendKeys(password);
            Submit.Click(useJQuery: false);
        }

        
    }
}

