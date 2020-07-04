using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace TcbcAzureFunctionsTests
{
    [TestFixture("Chrome")]
    // [TestFixture("Firefox")]
    //[TestFixture("IE")]
    public class HomePageTest
    {
        private string browser;
        private IWebDriver driver;

        public HomePageTest(string browser)
        {
            this.browser = browser;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            // The NuGet package for each browser installs driver software
            // in the bin directory, alongside the compiled test code.
            // This tells the driver class where to find the underlying driver software.
            var cwd = Environment.CurrentDirectory;

            // Create the driver for the current browser.
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver(cwd);
                    break;
                case "Firefox":
                    driver = new FirefoxDriver(cwd);
                    break;
                case "IE":
                    driver = new InternetExplorerDriver(cwd);
                    break;
                default:
                    throw new ArgumentException($"'{browser}': Unknown browser");
            }

            // Navigate to the site.
            // The site name is stored in the SITE_URL environment variable to make 
            // the tests more flexible.
            string url = "http://localhost:8080/trainers";// Environment.GetEnvironmentVariable("SITE_URL");
            driver.Navigate().GoToUrl(url + "/");
            
        }

        [Test]
        public void GetTrainers_ShouldReturnData()
        {
            // Skip the test if the driver could not be loaded.
            // This happens when the underlying browser is not installed.
            if (driver == null)
            {
                Assert.Ignore();
                return;
            }
            var baseTable = FindElement(By.TagName("table"), null, 30);
            //To find third row of table
            var tableRow = baseTable.FindElement(By.XPath("//*[@id='__BVID__15']/tbody/tr[1]"));
            String rowtext = tableRow.Text;

            Assert.AreEqual(rowtext, "Serverless Trainer1 5 123 Sunny way, Victoria, BC, Canada");
        }

        private IWebElement FindElement(By locator, IWebElement parent = null, int timeoutSeconds = 30)
        {
            // WebDriverWait enables us to wait for the specified condition to be true
            // within a given time period.
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds))
                .Until(c => {
                    IWebElement element = null;
            // If a parent was provided, find its child element.
            if (parent != null)
                    {
                        element = parent.FindElement(locator);
                    }
            // Otherwise, locate the element from the root of the DOM.
            else
                    {
                        element = driver.FindElement(locator);
                    }
            // Return true after the element is displayed and is able to receive user input.
            return (element != null && element.Displayed && element.Enabled) ? element : null;
                });
        }

        private void ClickElement(IWebElement element)
        {
            // We expect the driver to implement IJavaScriptExecutor.
            // IJavaScriptExecutor enables us to execute JavaScript code during the tests.
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;

            // Through JavaScript, run the click() method on the underlying HTML object.
            js.ExecuteScript("arguments[0].click();", element);
        }

        #region 


        //[Test]
        //public void GetTrainers_ShouldReturnData1()
        //{
        //    // Skip the test if the driver could not be loaded.
        //    // This happens when the underlying browser is not installed.
        //    if (driver == null)
        //    {
        //        Assert.Ignore();
        //        return;
        //    }

        //    //var lastNameElement = FindElement(By.Id("input-lastname"));
        //    //lastNameElement.SendKeys("Pham12345678");

        //    var trainersLink = FindElement(By.Id("trainer-link"));
        //    var navbarToggle = FindElement(By.Id("navbar-toggle"));

        //    // Click the submit button that's part of the modal.
        //    ClickElement(navbarToggle);

        //    ClickElement(trainersLink);

        //    Assert.AreEqual(false, true);
        //}

        #endregion
    }
}