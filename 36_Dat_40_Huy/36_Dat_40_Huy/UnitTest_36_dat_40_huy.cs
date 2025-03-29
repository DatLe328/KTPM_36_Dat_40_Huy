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

        [TestMethod]
        public void OpenBrowser()
        {
            driver_36_Dat_40_Huy = new ChromeDriver();
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
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
            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys("testemail@ou.edu.vn");
            driver_36_Dat_40_Huy.FindElement(By.Id("password")).SendKeys("testpassword");

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
        public void LoginFailWrongEmail_36_Dat_40_Huy()
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
            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys("2251050014qweasdat@ou.edu.vn");
            driver_36_Dat_40_Huy.FindElement(By.Id("password")).SendKeys("143122");

            // Nhấn nút Login của Form
            IWebElement submitButton_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"registerFormSubmitButton\"]"));
            submitButton_36_Dat_40_Huy.Click();
            Thread.Sleep(4000);

            // Kiểm tra lỗi
            IWebElement errorElement_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.Id("email-error"));
            string errorMessage = errorElement_36_Dat_40_Huy.Text;
            Assert.IsTrue(errorMessage.Contains("The email you entered does not belong to any account."), "Error message not displayed correctly!");
        }

        [TestMethod]
        public void LoginFailWrongPassword_36_Dat_40_Huy()
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
            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys("testemail@ou.edu.vn");
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
            driver_36_Dat_40_Huy.FindElement(By.Id("email")).SendKeys("testemail");
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
            LoginToPinterest_36_Dat_40_Huy("testemail@ou.edu.vn", "testpassword");

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

            // Lấy nút khám phá
            IWebElement exploreButon_Dat36_Huy_40 = driver_36_Dat_40_Huy.FindElement(By.CssSelector("a[href=\"/ideas/\"]"));
            exploreButon_Dat36_Huy_40.Click();
            Thread.Sleep(5000);

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

            // Lấy nút khám phá
            IWebElement exploreButon_Dat36_Huy_40 = driver_36_Dat_40_Huy.FindElement(By.CssSelector("a[href=\"/ideas/\"]"));
            exploreButon_Dat36_Huy_40.Click();
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

        /****************
         *  Pin creation Test
         ****************/
        //[TestMethod]
        public void PinCreationWithValidURL_36_Dat_40_Huy()
        {
            // Truy cập và đăng nhập Pinterest
            LoginToPinterest_36_Dat_40_Huy("testemail@ou.edu.vn", "testpassword");

            /*
             *  Vì tạo pin bằng URL bắt buộc phải có bảng để thêm vào
             *  Nên ta sẽ kiểm tra xem liệu đã có bảng chưa, nếu chưa thì sẽ tạo mới
             *  Nếu đã có bảng thì ta sẽ đếm xem trong đó có bao nhiêu Pin đã tồn tại để so sánh
             *      với kết quả sau khi tạo
             */


            // Lấy profileheader
            IWebElement profileHeader_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"header-profile\"]"));
            profileHeader_36_Dat_40_Huy.Click();
            Thread.Sleep(2000);

            // Đặt tên cho bảng
            string boardName_36_Dat_40_Huy = "Faasdk";
            // Đánh dấu xem có cần tạo bảng không, mặc định là true
            bool needToCreateBoard_36_Dat_40_Huy = true;
            // Số Pin trong bảng trước khi tạo Pin mới
            int numberOfPinBefore_36_Dat_40_Huy = 0;

            try
            {
                // Lấy danh sách các bảng hiện có trong profile
                List<IWebElement> boardList_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"board-card-title\"]")).ToList();
                foreach (var item_36_Dat_40_Huy in boardList_36_Dat_40_Huy)
                {
                    // Nếu tên bảng đã tồn tại
                    if (item_36_Dat_40_Huy.Text == boardName_36_Dat_40_Huy)
                    {
                        // Gán giá trị cần tạo bảng thành false
                        needToCreateBoard_36_Dat_40_Huy = false;

                        // Truy cập vào bảng
                        item_36_Dat_40_Huy.Click();
                        Thread.Sleep(5000);

                        // Lấy danh sách các Pin đã có trong bảng
                        List<IWebElement> pinList = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"pin\"]")).ToList();
                        numberOfPinBefore_36_Dat_40_Huy = pinList.Count;
                        break;
                    }
                }
            }
            catch (NoSuchElementException)
            {
                // Nếu không tìm thấy bảng nào
                numberOfPinBefore_36_Dat_40_Huy = 0;
            }

            // Lấy nút tạo bảng
            IWebElement btnPinCreate_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("a[data-test-id=\"create-tab\"]"));
            btnPinCreate_36_Dat_40_Huy.Click();
            Thread.Sleep(5000);

            // Lấy nút Lưu từ URL
            IWebElement saveFromURL_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"save-from-url-container\"]"));
            saveFromURL_36_Dat_40_Huy.Click();
            Thread.Sleep(5000);

            // Lấy thanh nhập địa chỉ URL
            IWebElement urlInput_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.Id("scrape-view-website-link"));
            urlInput_36_Dat_40_Huy.SendKeys("https://www.youtube.com/");

            // Lấy nút gửi
            IWebElement findURL_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("button[aria-label=\"Gửi\"]"));
            findURL_36_Dat_40_Huy.Click();
            Thread.Sleep(10000);

            /*
             *  Kiểm tra xem URL vừa nhập liệu có hợp lệ hay không
             *  Hoặc có thể cho trang đó chặn không thể lấy hình ảnh vd: https://shopee.vn/
             */
            try
            {
                // Lấy danh sách các hình ảnh
                List<IWebElement> imgElements_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"image-from-search-container\"]")).ToList();
                imgElements_36_Dat_40_Huy[0].Click();
            }
            catch (NoSuchElementException)
            {
                // Trả về kết quả fail nếu không tìm được
                Assert.IsTrue(false, "Invalid URL or can't get any images from URL.");
            }


            // Lấy nút thêm Pin
            IWebElement addPin_36_Dat_40_huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"add-pins-from-search-container\"]"));
            addPin_36_Dat_40_huy.Click();
            Thread.Sleep(5000);

            // Lấy nút chọn bảng
            IWebElement boardDropdown_36_Dat_40_huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"board-dropdown-select-button\"]"));
            boardDropdown_36_Dat_40_huy.Click();
            Thread.Sleep(1000);

            // Trường hợp bảng chưa được tạo
            if (needToCreateBoard_36_Dat_40_Huy)
            {
                // Lấy nút tạo bảng
                IWebElement createBoard_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"create-board-button\"]"));
                createBoard_36_Dat_40_Huy.Click();
                Thread.Sleep(5000);

                // Lấy trường nhập tên của form
                IWebElement boardFormContainer_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"board-form-container\"]"));
                boardFormContainer_36_Dat_40_Huy.FindElement(By.Id("boardEditName")).SendKeys(boardName_36_Dat_40_Huy);

                // Lấy nút xác nhận tạo bảng
                IWebElement boardFormSubmitButton_36_dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("button[data-test-id=\"board-form-submit-button\"]"));
                boardFormSubmitButton_36_dat_40_Huy.Click();
                Thread.Sleep(1000);
            }
            else
            {
                /*
                 * Trường hợp bảng đã tạo chỉ cần tìm bảng
                 */

                // Lấy danh sách các bảng để duyệt
                List<IWebElement> board_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"boardWithoutSection\"]")).ToList();
                foreach (var item_36_Dat_40_Huy in board_36_Dat_40_Huy)
                {
                    if (item_36_Dat_40_Huy.Text == boardName_36_Dat_40_Huy)
                    {
                        item_36_Dat_40_Huy.Click();
                        break;
                    }
                }
            }
            
            // Lấy nút lưu Pin
            IWebElement boardDropdownSaveButton_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"board-dropdown-save-button\"]"));
            boardDropdownSaveButton_36_Dat_40_Huy.Click();
            Thread.Sleep(5000);

            // Di chuyển về trang chủ
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(5000);

            // Lấy header profile
            IWebElement headerProfile = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"header-profile\"]"));
            headerProfile.Click();
            Thread.Sleep(5000);

            // Lấy danh sách các bảng có trong profile
            List<IWebElement> itemsTitle_36_Dat_Huy_40 = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"board-card-title\"]")).ToList();

            // Số Pin đang có trong bảng sau khi tạo
            int numberOfPinAfter_36_Dat_40_Huy = 0;

            // Duyệt từng bảng kiểm tra tên
            foreach (var item_36_Dat_40_Huy in itemsTitle_36_Dat_Huy_40)
            {
                if (item_36_Dat_40_Huy.Text == boardName_36_Dat_40_Huy)
                {
                    // Nếu tìm thấy bảng sẽ truy cập vào
                    item_36_Dat_40_Huy.Click();
                    Thread.Sleep(3000);

                    // Lấy danh sách các Pin có trong bảng
                    List<IWebElement> pinList = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"pin\"]")).ToList();
                    numberOfPinAfter_36_Dat_40_Huy = pinList.Count;
                    break;
                }
            }
            // Giá trị mong đợi sau khi tạo Pin
            int expectedValue_36_Dat_40_Huy = numberOfPinBefore_36_Dat_40_Huy + 1;

            // Giá trị thực tế
            int actualValue_36_Dat_40_Huy = numberOfPinAfter_36_Dat_40_Huy;

            // Console debug
            Console.WriteLine("(Debug)Number of pin before: " + numberOfPinBefore_36_Dat_40_Huy);
            Console.WriteLine("(Debug)Number of pin after: " + numberOfPinAfter_36_Dat_40_Huy);

            // Kiểm tra kết quả
            Assert.AreEqual(expectedValue_36_Dat_40_Huy, actualValue_36_Dat_40_Huy, "Fail to create pin.");
        }

        [TestMethod]
        public void PinCreationWithInvalidURL_36_Dat_40_Huy()
        {
            // Truy cập và đăng nhập Pinterest
            LoginToPinterest_36_Dat_40_Huy("testemail@ou.edu.vn", "testpassword");

            // Lấy nút tạo Pin
            IWebElement btnPinCreate_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("a[data-test-id=\"create-tab\"]"));
            btnPinCreate_36_Dat_40_Huy.Click();
            Thread.Sleep(5000);

            // Láy nút Lưu từ URL
            IWebElement saveFromURL_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"save-from-url-container\"]"));
            saveFromURL_36_Dat_40_Huy.Click();
            Thread.Sleep(5000);

            // Lấy thanh tìm kiếm URL
            IWebElement urlInput_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.Id("scrape-view-website-link"));
            urlInput_36_Dat_40_Huy.SendKeys("abcde");

            // Lấy nút tìm URL
            IWebElement findURL_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("button[aria-label=\"Gửi\"]"));
            findURL_36_Dat_40_Huy.Click();

            /*
             *  Kiểm tra: nếu có thông báo lỗi tìm không thấy thì Test pass
             */
            try
            {
                // Lấy thông báo lỗi
                driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[id=\"scrape-view-website-link-error\"]"));
            }
            catch (NoSuchElementException)
            {
                Assert.IsTrue(false, "This is a valid URL.");
            }
        }

        [TestMethod]
        public void PinCreateWithUpload()
        {
            // Truy cập và đăng nhập Pinterest
            LoginToPinterest_36_Dat_40_Huy("testemail@ou.edu.vn", "testpassword");
            
            // Lấy header profile
            IWebElement headerProfile_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"header-profile\"]"));
            headerProfile_36_Dat_40_Huy.Click();
            Thread.Sleep(2000);

            // Lấy nút chuyển qua danh sách các pin
            IWebElement pinProfileTab_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[id=\"_pins-profile-tab\"]"));
            pinProfileTab_36_Dat_40_Huy.Click();
            Thread.Sleep(2000);

            // Số Pin trước khi tạo Pin mới
            int numberElementBefore_36_Dat_40_Huy;
            try
            {
                // Lấy danh sách các Pin hiện có
                List<IWebElement> pinList_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"pin\"]")).ToList();
                numberElementBefore_36_Dat_40_Huy = pinList_36_Dat_40_Huy.Count;
            }
            catch (NoSuchElementException)
            {
                // Nếu không có Pin nào thì sẽ gán mặc định bằng 0
                numberElementBefore_36_Dat_40_Huy = 0;
            }

            // Lấy nút tạo Pin
            IWebElement btnPinCreate_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("a[data-test-id=\"create-tab\"]"));
            btnPinCreate_36_Dat_40_Huy.Click();
            Thread.Sleep(5000);

            // Lấy trường tải ảnh lên
            IWebElement uploadButton_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("input[data-test-id=\"storyboard-upload-input\"]"));
            // Đường dẫn file ảnh trên máy
            string fileUploadPath_36_Dat_40_Huy = @"C:\Users\datle\Downloads\McLaren Senna Grey.jpg";
            uploadButton_36_Dat_40_Huy.SendKeys(fileUploadPath_36_Dat_40_Huy);
            Thread.Sleep(5000);

            // Nhập tiêu đề
            string title_36_Dat_40_Huy = "McLaren";
            IWebElement titleInput_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("input[id=\"storyboard-selector-title\"]"));
            titleInput_36_Dat_40_Huy.SendKeys(title_36_Dat_40_Huy);

            // Nhập mô tả
            string description_36_Dat_40_Huy = "Super car";
            IWebElement editor_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector(".public-DraftEditor-content"));
            editor_36_Dat_40_Huy.SendKeys(description_36_Dat_40_Huy);
            Thread.Sleep(2000);

            // Lấy nút đăng
            IWebElement uploadSubmit_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"storyboard-creation-nav-done\"]"));
            uploadSubmit_36_Dat_40_Huy.Click();
            Thread.Sleep(4000);

            // Trở lại trang chủ
            driver_36_Dat_40_Huy.Navigate().GoToUrl("https://www.pinterest.com/");
            Thread.Sleep(10000);

            // Lấy header profile
            headerProfile_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[data-test-id=\"header-profile\"]"));
            headerProfile_36_Dat_40_Huy.Click();
            Thread.Sleep(2000);

            // Lấy nút chuyển qua danh sách các Pin
            pinProfileTab_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElement(By.CssSelector("div[id=\"_pins-profile-tab\"]"));
            pinProfileTab_36_Dat_40_Huy.Click();
            Thread.Sleep(2000);

            // Số Pin hiện tại sau khi tạo Pin
            int numberElementAfter_36_Dat_40_Huy;
            try
            {
                // Lấy danh sách các Pin
                List<IWebElement> pinList_36_Dat_40_Huy = driver_36_Dat_40_Huy.FindElements(By.CssSelector("div[data-test-id=\"pin\"]")).ToList();
                numberElementAfter_36_Dat_40_Huy = pinList_36_Dat_40_Huy.Count;
            }
            catch (NoSuchElementException)
            {
                // Nếu không tìm thấy Pin
                numberElementAfter_36_Dat_40_Huy = 0;
            }

            Console.WriteLine("(Debug)Element before: " + numberElementBefore_36_Dat_40_Huy);
            Console.WriteLine("(Debug)Element after: " + numberElementAfter_36_Dat_40_Huy);

            // Giá trị mong đợi
            int actualValue_36_Dat_40_Huy = numberElementAfter_36_Dat_40_Huy - numberElementBefore_36_Dat_40_Huy;
            // Giá trị thực sự
            int expectedValue_36_Dat_40_Huy = 1;

            // Kiểm tra kết quả
            Assert.AreEqual(expectedValue_36_Dat_40_Huy, actualValue_36_Dat_40_Huy, "Fail to create pin.");
        }
    }
}

