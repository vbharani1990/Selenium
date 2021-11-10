using NUnit.Framework;
using SeleniumCharpTutorials.BaseClass;
using SeleniumCharpTutorials.Helpers;

namespace SeleniumCharpTutorials
{
    [TestFixture] 
    public class TestClass : BaseTest
    {
        UIHelper _helper = new UIHelper();

        [Test, Category("Smoke Testing")]
        public void SwagLabsLogin()
        {
            //Enter UserName
            _helper.SendKeysByXpath(_driver, loginElement.userNameTextField, readData.username);
            //Enter Password
            _helper.SendKeysByXpath(_driver, loginElement.passwordTextField, readData.password);
            //Click Login Button
            _helper.ClickButtonByXpath(_driver, loginElement.loginButton);
            //Wait For Home Page to Load. Shopping Cart Icon to displayed.
            _helper.WaitForElementToVisible(_driver, homePageElements.ShoppingCart);
        }

        [Test, Category("Smoke Testing")]
        public void LoginFailTest()
        {
            //Enter UserName
            _helper.SendKeysByXpath(_driver, loginElement.userNameTextField, readData.username);
            //Enter Password
            _helper.SendKeysByXpath(_driver, loginElement.passwordTextField, "12345");
            //Click Login Button
            _helper.ClickButtonByXpath(_driver, loginElement.loginButton);
            //Wait For Home Page to Load. Shopping Cart Icon to displayed.
            _helper.WaitForElementToVisible(_driver, homePageElements.ShoppingCart);
        }
    }
}
