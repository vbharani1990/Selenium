using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumCharpTutorials.Helpers
{
    public class UIHelper
    {
        public void ClickButtonByXpath(IWebDriver driver = null, string element = null)
        {
            IWebElement button = driver.FindElement(By.XPath(element));
            button.Click();
        }

        public void ClickButtonByID(IWebDriver driver = null, string element = null)
        {
            IWebElement button = driver.FindElement(By.Id(element));
            button.Click();
        }

        public void SendKeysByXpath(IWebDriver driver = null, string element = null, string textToEnter = null)
        {
            IWebElement textField = driver.FindElement(By.XPath(element));
            textField.SendKeys(textToEnter);
        }
        public void SendKeysByID(IWebDriver driver = null, string element = null, string textToEnter = null)
        {
            IWebElement textField = driver.FindElement(By.Id(element));
            textField.SendKeys(textToEnter);
        }

        public void IsElementVisibleByXpath(IWebDriver driver = null, string element = null)
        {
            Assert.IsTrue(driver.FindElement(By.XPath(element)).Displayed);
        }

        public void WaitForElementToVisible(IWebDriver driver = null, string elementXpath = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(elementXpath)));
        }
    }
}
