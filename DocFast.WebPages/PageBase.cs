using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using SeleNUnit.WebObjects;
using SeleNUnit.WebObjects.WebElement;


namespace SeleNUnit.WebObjects
{
   
    public abstract class PageBase
    {
        public Uri BaseUrl
        {
            get
            {
                Browser.WaitAjax();

               return  new Uri("Settings.Default.TestEnvironment");
                //GetUriByRelativePath(RelativePath);
            }
        }

        public void Open()
        {
            Contract.Requires(BaseUrl != null);
            Contract.Ensures(Browser.Url == BaseUrl);

            Browser.WaitAjax();

            if (Browser.Url == BaseUrl) return;

            Browser.Navigate(BaseUrl);

            //Contract.Assert(Browser.Url == BaseUrl, string.Format("{0} != {1}", Browser.Url, BaseUrl));
        }

        public Type PageName()
        {
            return GetType();
        }

        public bool TextExists(string text, bool exactMach = true, int timeout = 5)
        {
            return new WebElement.WebElement().ByText(text, exactMach).Exists(timeout);
        }

        protected void Navigate(Uri url)
        {
            Contract.Requires(url != null);

            Browser.Navigate(url);
        }

        protected void Navigate(String url)
        {
            Contract.Requires(url != null);

            Browser.Navigate(url);
        }

        protected static Uri GetUriByRelativePath(string relativePath)
        {
           return new Uri(("Settings.Default.TestEnvironment + relativePath").ToLower());
        }

        private string RelativePath
        {
            get
            {
                const string rootNamespaceName = "DocFast.WebObjects.Root";
                var className = GetType().FullName;

                Contract.Assume(className != null);

                var path = className
                    .Replace(rootNamespaceName, string.Empty)
                    .Replace(".", "/");
                
                path = Regex.Replace(path, "/Index$", "");

                return path;
            }
        }
    }
}



