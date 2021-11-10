using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCharpTutorials.Data;
using System;
using System.IO;
using System.Reflection;

namespace SeleniumCharpTutorials.BaseClass
{
    public class BaseTest
    {

        public IWebDriver _driver;
        public ConfigData readData = new ConfigData();
        public LoginUIElements loginElement = new LoginUIElements();
        public HomePageUIElements homePageElements = new HomePageUIElements();

        [SetUp]
        public void ReadData()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Config\Data.json");

            StreamReader sr = new StreamReader(path);

            //Read Json File
            string json = sr.ReadToEnd();
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            readData.URL = result.URL.ToString();
            readData.username = result.username.ToString();
            readData.password = result.password.ToString();
            loginElement.userNameTextField = result.HTML_Elements.usernameElement;
            loginElement.passwordTextField = result.HTML_Elements.passwordElement;
            loginElement.loginButton = result.HTML_Elements.loginbtnElement;
            homePageElements.ShoppingCart = result.HTML_Elements.cartIcon;
        }
        [SetUp]
        public void OpenBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Url = readData.URL;
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }

        [TearDown]
        public void TakeScreenshotonFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                string failedTestName = TestContext.CurrentContext.Test.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

                Directory.CreateDirectory(Path.Combine(TestContext.CurrentContext.WorkDirectory, "Failed_Tests"));

                string screenShotFile = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Failed_Tests", failedTestName + ".jpeg");

                ss.SaveAsFile(screenShotFile);

                TestContext.AddTestAttachment(screenShotFile, "My Screenshot");
            }
        }
    }
}
