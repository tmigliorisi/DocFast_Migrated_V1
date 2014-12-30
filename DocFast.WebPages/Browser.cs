using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using System.Threading;
using SeleNUnit.WebObjects;


namespace SeleNUnit.WebObjects
{
    [Serializable]
    public enum Browsers
    {
        [Description("Windows Internet Explorer")]
        InternetExplorer,

        [Description("Mozilla Firefox")]
        Firefox,

        [Description("Google Chrome")]
        Chrome
    }

    public class Browser
    {
        #region Public properties

        private static Browsers selectedBrowser;
        public static Browsers SelectedBrowser    
        {
            get { return selectedBrowser; }
            set { selectedBrowser = (value.Equals(null)) ? Browsers.Firefox : value;  }
        }
        //public static Browsers SelectedBrowser
        //{
        //    get { return Settings.Default.Browser; }
        //}

        public static Uri Url
        {
            get { WaitAjax(); return new Uri(WebDriver.Url); }
        }

        public static string Title
        {
            get
            {
                WaitAjax();
                return string.Format("{0} - {1}", WebDriver.Title, EnumHelper.GetEnumDescription(SelectedBrowser));
            }
        }

        public static string PageSource
        {
            get { WaitAjax(); return WebDriver.PageSource; }
        }

        #endregion

        #region Public methods

        public static void Start(string remoteServerAddress)
        {
            _webDriver = StartWebDriver(remoteServerAddress);
        }

        public static void Navigate(Uri url)
        {
            Contract.Requires(url != null);

            WebDriver.Navigate().GoToUrl(url);
        }

        public static void Navigate(String url)
        {
            Contract.Requires(url != null);

            WebDriver.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            if (_webDriver == null) return;

            _webDriver.Quit();
            _webDriver = null;
        }

        public static void WaitReadyState()
        {
            Contract.Assume(WebDriver != null);

            var ready = new Func<bool>(() => (bool)ExecuteJavaScript("return document.readyState == 'complete'"));

            Contract.Assert(WaitHelper.SpinWait(ready, TimeSpan.FromSeconds(120), TimeSpan.FromMilliseconds(100)));
        }

        public static void WaitAjax()
        {
            Contract.Assume(WebDriver != null);

            var ready = new Func<bool>(() => (bool)ExecuteJavaScript("return (typeof($) === 'undefined') ? true : !$.active;"));

            Contract.Assert(WaitHelper.SpinWait(ready, TimeSpan.FromSeconds(120), TimeSpan.FromMilliseconds(100)));
        }

        public static void SwitchToFrame(IWebElement inlineFrame)
        {
            WebDriver.SwitchTo().Frame(inlineFrame);
        }

        public static void SwitchToPopupWindow()
        {
            foreach (var handle in WebDriver.WindowHandles.Where(handle => handle != _mainWindowHandler)) // TODO:
            {
                WebDriver.SwitchTo().Window(handle);
            }
        }

        public static void SwitchToMainWindow()
        {
            WebDriver.SwitchTo().Window(_mainWindowHandler);
        }

        public static void SwitchToDefaultContent()
        {
            WebDriver.SwitchTo().DefaultContent();
        }

        public static void AcceptAlert()
        {
            var accept = WaitHelper.MakeTry(() => WebDriver.SwitchTo().Alert().Accept());

            WaitHelper.SpinWait(accept, TimeSpan.FromSeconds(5));
        }

        public static IEnumerable<IWebElement> FindElements(By selector)
        {
            Contract.Assume(WebDriver != null);

            return WebDriver.FindElements(selector);
        }

        public static Screenshot GetScreenshot()
        {
            WaitReadyState();

            return ((ITakesScreenshot)WebDriver).GetScreenshot();
        }

        public static void SaveScreenshot(string path)
        {
            Contract.Requires(!string.IsNullOrEmpty(path));

            GetScreenshot().SaveAsFile(path, ImageFormat.Jpeg);
        }

        public static void DragAndDrop(IWebElement source, IWebElement destination)
        {
            (new Actions(WebDriver)).DragAndDrop(source, destination).Build().Perform();
        }

        public static void ResizeWindow(int width, int height)
        {
            ExecuteJavaScript(string.Format("window.resizeTo({0}, {1});", width, height));
        }

        public static void NavigateBack()
        {
            WebDriver.Navigate().Back();
        }

        public static void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }

        public static object ExecuteJavaScript(string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)WebDriver;

            return javaScriptExecutor.ExecuteScript(javaScript, args);
        }

        public static void KeyDown(string key)
        {
            new Actions(WebDriver).KeyDown(key);
        }

        public static void KeyUp(string key)
        {
            new Actions(WebDriver).KeyUp(key);
        }

        public static void AlertAccept()
        {
            Thread.Sleep(2000);
            WebDriver.SwitchTo().Alert().Accept();
            WebDriver.SwitchTo().DefaultContent();
        }

        #endregion

        #region Private

        private static IWebDriver _webDriver;
        private static string _mainWindowHandler;
        private static string _remoteServerAddress = "http://localhost:4444/wd/hub";
        private static IWebDriver WebDriver
        {
            get { return _webDriver ?? StartWebDriver(_remoteServerAddress); }
        }

        private static IWebDriver StartWebDriver(string remoteServerAddress)
        {
            Contract.Ensures(Contract.Result<IWebDriver>() != null);

            if (_webDriver != null) return _webDriver;

            switch (SelectedBrowser)
            {
                case Browsers.InternetExplorer:
                    _webDriver = StartInternetExplorer(remoteServerAddress);
                    break;
                case Browsers.Firefox:
                    _webDriver = StartFirefox(remoteServerAddress);
                    break;
                case Browsers.Chrome:
                    _webDriver = StartChrome(remoteServerAddress);
                    break;
                default:
                    throw new Exception(string.Format("Unknown browser selected: {0}.", SelectedBrowser));
            }

            _webDriver.Manage().Window.Maximize();
            _mainWindowHandler = _webDriver.CurrentWindowHandle;

            return WebDriver;
        }

        private static IWebDriver StartInternetExplorer(string remoteServerAddress)
        {
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();
            // Force Windows to launch IE through Create Process API and in "private" browsing mode
            ieOptions.ForceCreateProcessApi = true;
            ieOptions.BrowserCommandLineArguments = "-private";
            ieOptions.AddAdditionalCapability("version", "10");
            ieOptions.AddAdditionalCapability("webdriver.ie.driver", "");

            // Convert ieOptions to an ICapabilities object and instantiate driver
            return new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), ieOptions.ToCapabilities());

        }

        private static IWebDriver StartFirefox(string remoteServerAddress)
        {
           
            DesiredCapabilities desiredCapabilities = DesiredCapabilities.Firefox();
            var remoteAddress = new Uri(remoteServerAddress);
            return ( new RemoteWebDriver(remoteAddress, desiredCapabilities));
   
        }

        private static IWebDriver StartChrome(string remoteServerAddress)
        {
            //var chromeOptions = new ChromeOptions();
            DesiredCapabilities desiredCapabilities = DesiredCapabilities.Chrome();
            //desiredCapabilities.SetCapability(ChromeOptions.Capability,chromeOptions);
            
            var remoteAddress = new Uri(remoteServerAddress);
            return (new RemoteWebDriver(remoteAddress, desiredCapabilities));
        }

        #endregion
    }
}

