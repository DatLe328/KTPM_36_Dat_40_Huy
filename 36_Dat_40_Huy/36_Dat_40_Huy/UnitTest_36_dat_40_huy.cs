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
        public void LoginToPinterest_36_Dat_40_Huy(string email, string password)
        {
            // Mở trình duyệt và di chuyển đến trang chủ Pinterest
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(4000);

            // Tìm và nhấn vào nút login
            driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"simple-login-button\"]")).Click();
            Thread.Sleep(2000);

            // Nhập vào thông tin đăng nhập (email, password)
            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys(email);
            driver_36_Dat_40_Huy.FindElement(By.Id("password")).SendKeys(password);

            // Nhấn nút Login của Form
            driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"registerFormSubmitButton\"]")).Click();
            Thread.Sleep(10000);
        }

        /****************
         *  Login Test
         ****************/
        //[TestMethod]
        public void LoginSucess_36_Dat_40_Huy()
        {
            // Mở trình duyệt và di chuyển đến trang chủ Pinterest
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
            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys("email");
            driver_36_Dat_40_Huy.FindElement(By.Id("password")).SendKeys("password");

            // Nhấn nút Login của Form
            IWebElement submitButton_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"registerFormSubmitButton\"]"));
            submitButton_36_Dat_40_Huy.Click();
            Thread.Sleep(10000);

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
            // Mở trình duyệt và di chuyển đến trang chủ Pinterest
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(4000);

            // Tìm và nhấn vào nút login
            IWebElement loginButton_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"simple-login-button\"]"));
            loginButton_36_Dat_40_Huy.Click();
            Thread.Sleep(2000);

            // Nhập vào thông tin đăng nhập (email, password)
            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys("email");
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
        public void LoginWrongMailFormat_36_Dat_40_Huy()
        {
            // Mở trình duyệt và di chuyển đến trang chủ Pinterest
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(3000);

            // Tìm và nhấn vào nút login
            driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"simple-login-button\"]")).Click();
            Thread.Sleep(5000);

            // Nhập vào thông tin đăng nhập (email, password)
            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys("2251050014dat");
            driver_36_Dat_40_Huy.FindElement(By.Id("password")).SendKeys("143122");

            // Nhấn nút Login của Form
            driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"registerFormSubmitButton\"]")).Click();

            // Kiểm tra kết quả
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
            // Truy cập Pinterest và đăng nhập
            LoginToPinterest_36_Dat_40_Huy("email", "password");

            // Lấy đường dẫn thư mục tải về 
            string downloadPath_36_Dat_40_Huy = "C:\\Users\\datle\\Downloads";
            // Lấy số file hiện tại trong thư mục
            int fileCountBefore_36_Dat_40_Huy = Directory.GetFiles(downloadPath_36_Dat_40_Huy).Length;
            // Số hình sẽ tải xuống
            int numImgs_36_Dat_40_Huy = 3;

            // Bắt đầu quá trình tải hình
            for (int idx_36_Dat_40_Huy = 0; idx_36_Dat_40_Huy < numImgs_36_Dat_40_Huy; idx_36_Dat_40_Huy++)
            {
                // Lấy thẻ pin
                List<IWebElement> imgElements_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"pin\"]")).ToList();
                imgElements_36_Dat_40_Huy[idx_36_Dat_40_Huy].Click();
                Thread.Sleep(5000);

                // Lấy nút hiển thị các lựa chọn khác
                IWebElement button = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"closeup-action-bar-button\"]"));
                button.Click();
                Thread.Sleep(1000);

                // Lấy nút tải hình xuống 
                IWebElement downloadButton = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"pin-action-dropdown-download\"]"));
                downloadButton.Click();
                Thread.Sleep(5000);

                // Quay trở lại trang trước
                driver_36_Dat_40_Huy.Navigate().Back();
                Thread.Sleep(5000);
            }

            // Lấy số file hiện tại trong thư mục tải xuống
            int fileCountAfter_36_Dat_40_Huy = Directory.GetFiles(downloadPath_36_Dat_40_Huy).Length;
            Console.WriteLine("(Debug)File count before: " + fileCountBefore_36_Dat_40_Huy);
            Console.WriteLine("(Debug)File count after: " + fileCountAfter_36_Dat_40_Huy);

            // Kiểm tra xem số file đã tải có đúng như dự kiến không
            int actualValue_36_Dat_40_Huy = fileCountAfter_36_Dat_40_Huy - fileCountBefore_36_Dat_40_Huy;
            int expectedValue_36_Dat_40_Huy = numImgs_36_Dat_40_Huy;
            Assert.AreEqual(expectedValue_36_Dat_40_Huy, actualValue_36_Dat_40_Huy);
        }
        [TestMethod]
        public void DownloadWithoutLogin_36_Dat_40_Huy()
        {
            // Mở trình duyệt và di chuyển đến trang chủ Pinterest
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(3000);

            // Lấy thanh tìm kiếm
            IWebElement searchBar_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("input[data-test-id=\"search-box-input\"]"));
            // Nhập từ khóa tìm kiếm
            searchBar_36_Dat_40_Huy.SendKeys("car");
            searchBar_36_Dat_40_Huy.SendKeys(Keys.Enter);
            Thread.Sleep(5000);

            // Lấy các thẻ pin
            List<IWebElement> ideaList = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"pin\"]")).ToList();
            ideaList[0].Click();
            Thread.Sleep(5000);

            // Lấy nút hiển thị các lựa chọn khác
            IWebElement dropdownList_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("button[data-test-id=\"feedback-button\"]"));
            dropdownList_36_Dat_40_Huy.Click();
            Thread.Sleep(1000);

            // Lấy nút tải hình xuống
            IWebElement downloadButton_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"pin-action-dropdown-download\"]"));
            downloadButton_36_Dat_40_Huy.Click();
            Thread.Sleep(1000);

            // Kiểm tra
            try
            {
                // Nếu như chưa đăng nhập mà tải hình sẽ hiển thị form đăng nhập
                IWebElement signupModal_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"signup-default-modal\"]"));
            }
            catch (NoSuchElementException)
            {
                // Nếu đã đăng nhập thì sẽ không hiện form, lúc này test fail
                Assert.IsTrue(false, "Element not found!");
            }
        }

        /****************
         *  Search Test
         ****************/
        [TestMethod]
        public void SeachWithValidKeyword_36_Dat_40_Huy()
        {

            // Mở trình duyệt và di chuyển đến trang chủ Pinterest
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(5000);

            // Lấy nút khám phá
            IWebElement exploreButon_Dat36_Huy_40 = driver_36_Dat_40_Huy.FindElement(By.CssSelector("a[href=\"/ideas/\"]"));
            exploreButon_Dat36_Huy_40.Click();
            Thread.Sleep(5000);

            // Từ khóa để tìm kiếm
            string keyWord_36_Dat_40_Huy = "car";
            // Lấy thanh tìm kiếm
            IWebElement seachBar_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("input[data-test-id=\"search-box-input\"]"));
            // Nhập từ khóa vào để tìm kiếm
            seachBar_36_Dat_40_Huy.SendKeys(keyWord_36_Dat_40_Huy);
            seachBar_36_Dat_40_Huy.SendKeys(Keys.Enter);
            Thread.Sleep(5000);

            // Kiểm tra kết quả
            try
            {
                // Lấy thông báo lỗi, nếu có báo lỗi thì từ khóa không hợp lệ, Test case fail
                IWebElement errorMessage = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"searchAutocorrectLink\"]"));
                Assert.IsTrue(false, keyWord_36_Dat_40_Huy + " is an invalid keyword.");
            }
            catch (NoSuchElementException)
            {
                // Test pass
            }
        }
        [TestMethod]
        public void SeachWithInvalidKeyword_36_Dat_40_Huy()
        {
            // Mở trình duyệt và di chuyển đến trang chủ Pinterest
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(5000);

            // Từ khóa tìm kiếm
            string keyWord_36_Dat_40_Huy = "ca2aq1dda asdq 12";
            // Lấy thanh tìm kiếm
            IWebElement seachBar_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("input[data-test-id=\"search-box-input\"]"));
            // Nhập từ khóa vào để tìm kiếm
            seachBar_36_Dat_40_Huy.SendKeys(keyWord_36_Dat_40_Huy);
            seachBar_36_Dat_40_Huy.SendKeys(Keys.Enter);
            Thread.Sleep(5000);

            // Kiểm tra kết quả
            try
            {
                // Lấy thông báo lỗi, nếu có thông báo thì Test case pass
                IWebElement errorMessage = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"searchAutocorrectLink\"]"));
            }
            catch (NoSuchElementException)
            {
                // Ngược lại nếu không có thông báo lỗi thì Test case fail
                Assert.IsTrue(false, keyWord_36_Dat_40_Huy + " is a valid keyword.");
            }
        }
    }
}
