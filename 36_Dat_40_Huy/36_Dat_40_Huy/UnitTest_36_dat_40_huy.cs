using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace _36_Dat_40_Huy
{
    [TestClass]
    public class UnitTest_36_Dat_40_Huy
    {
        IWebDriver driver_36_Dat_40_Huy;
        string userName;
        string password;

        public void LoginToPinterest_36_Dat_40_Huy(string email, string password)
        {
            driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"simple-login-button\"]")).Click();
            Thread.Sleep(5000);

            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys(email);
            driver_36_Dat_40_Huy.FindElement(By.Id("password")).SendKeys(password);
            driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"registerFormSubmitButton\"]")).Click();
        }

        /****************
         *  Login Test
         ****************/
        //[TestMethod]
        public void LoginSucess_36_Dat_40_Huy()
        {
            // Mở trình duyệt
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(4000);

            // Tìm và nhấn vào nút login
            IWebElement loginButton_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.XPath("#__PWS_ROOT__ > div > div > div:nth-child(1) > " +
                "div:nth-child(2) > div.QLY._he.zI7.iyn.Hsu > div > div.Eqh.Jea.KS5.s7I.zI7.iyn.Hsu > " +
                "div.H-G.zI7.iyn.Hsu"));
            loginButton_36_Dat_40_Huy.Click();
            Thread.Sleep(2000);

            // Nhập vào thông tin đăng nhập (email, password)
            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys("2251050014dat@ou.edu.vn");
            driver_36_Dat_40_Huy.FindElement(By.Id("password")).SendKeys("075204006947");

            // Nhấn nút Login của Form
            IWebElement submitButton_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"registerFormSubmitButton\"]"));
            submitButton_36_Dat_40_Huy.Click();
            Thread.Sleep(5000);

            try
            {
                // Kiểm tra xem có tìm thấy nút profile không
                driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"header-profile\"]"));
            }
            catch (NoSuchElementException)
            {
                // Nếu không tồn tại nút profile thì test fail
                Assert.IsTrue(false, "Login fail");
            }
        }

        [TestMethod]
        public void LoginFail_36_Dat_40_Huy()
        {
            // Mở trình duyệt
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(4000);

            // Tìm và nhấn vào nút login
            IWebElement loginButton_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"simple-login-button\"]"));
            loginButton_36_Dat_40_Huy.Click();
            Thread.Sleep(2000);

            // Nhập vào thông tin đăng nhập (email, password)
            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys("2251050014dat@ou.edu.vn");
            driver_36_Dat_40_Huy.FindElement(By.Id("password")).SendKeys("143122");

            // Nhấn nút Login của Form
            IWebElement submitButton_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"registerFormSubmitButton\"]"));
            submitButton_36_Dat_40_Huy.Click();
            Thread.Sleep(4000);

            // Kiểm tra lỗi
            IWebElement errorElement_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"touchableErrorMessage\"]"));
            string errorMessage = errorElement_36_Dat_40_Huy.Text;
            Assert.IsTrue(errorMessage.Contains("The password you entered is incorrect."), "Error message not displayed correctly!");
        }
        [TestMethod]
        public void LoginCheckMail_36_Dat_40_Huy()
        {
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(3000);
            driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"simple-login-button\"]")).Click();
            Thread.Sleep(5000);
            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys("2251050014dat");
            driver_36_Dat_40_Huy.FindElement(By.Id("password")).SendKeys("143122");

            driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"registerFormSubmitButton\"]")).Click();

            string actualErrorText = driver_36_Dat_40_Huy.FindElement(By.Id("email-error")).Text;
            string expectedErrorText = "Hmm...that doesn't look like an email address.";
            Assert.AreEqual(actualErrorText, expectedErrorText, "Error texts are not equal!");
        }
        /****************
         *  Download Test
         ****************/
        [TestMethod]
        public void DownloadWithLogin_36_Dat_40_Huy()
        {
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(5000);
            LoginToPinterest_36_Dat_40_Huy("2251050014dat@ou.edu.vn", "075204006947");
            Thread.Sleep(10000);
            /* 
             * Login success
             */
            string downloadPath = "C:\\Users\\datle\\Downloads";
            int fileCountBefore = Directory.GetFiles(downloadPath).Length;
            int numFiles = 3;

            for (int idx_36_Dat_40_Huy = 0; idx_36_Dat_40_Huy < numFiles; idx_36_Dat_40_Huy++)
            {
                List<IWebElement> imgElements_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"pin\"]")).ToList();
                imgElements_36_Dat_40_Huy[idx_36_Dat_40_Huy].Click();
                Thread.Sleep(5000);

                IWebElement button = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"closeup-action-bar-button\"]"));
                button.Click();
                Thread.Sleep(1000);

                IWebElement downloadButton = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"pin-action-dropdown-download\"]"));
                downloadButton.Click();
                Thread.Sleep(5000);

                driver_36_Dat_40_Huy.Navigate().Back();
                Thread.Sleep(5000);
            }

            int fileCountAfter = Directory.GetFiles(downloadPath).Length;
            Console.WriteLine("(Debug)File count before: " + fileCountBefore);
            Console.WriteLine("(Debug)File count after: " + fileCountAfter);
            Assert.AreEqual(numFiles, fileCountAfter - fileCountBefore);
        }
        [TestMethod]
        public void DownloadWithoutLogin_36_Dat_40_Huy()
        {
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(3000);

            IWebElement exploreButon_Dat36_Huy_40 = driver_36_Dat_40_Huy.FindElement(By.CssSelector("#__PWS_ROOT__ > div > div > div:nth-child(1) > div:nth-child(2) > div.QLY._he.zI7.iyn.Hsu > div > div:nth-child(1) > div.Eqh.fev.zI7.iyn.Hsu"));
            exploreButon_Dat36_Huy_40.Click();
            Thread.Sleep(5000);

            List<IWebElement> categoryList_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"ideas-root-today-articles\"]")).ToList();
            categoryList_36_Dat_40_Huy[0].Click();
            Thread.Sleep(10000);

            List<IWebElement> ideaList = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"pin\"]")).ToList();
            ideaList[0].Click();
            Thread.Sleep(5000);

            IWebElement dropdownList_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("button[data-test-id=\"feedback-button\"]"));
            dropdownList_36_Dat_40_Huy.Click();
            Thread.Sleep(1000);

            IWebElement downloadButton_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"pin-action-dropdown-download\"]"));
            downloadButton_36_Dat_40_Huy.Click();
            Thread.Sleep(1000);

            try
            {
                IWebElement signupModal_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"signup-default-modal\"]"));
            }
            catch (NoSuchElementException)
            {
                Assert.IsTrue(false, "Element not found!");
            }
        }

    }
}
