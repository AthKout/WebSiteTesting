using OpenQA.Selenium;
using System;
using System.Xml.Linq;

namespace WebSiteTesting
{
    [TestFixture]
    public class TestLogoutFromSite : BaseTest
    {
        [Test]
        [Description("Test case to validate the logout functionality.")]
        public void LogoutFromSiteMethod()
        {
            // Login to site
            LogIn(); 
            Thread.Sleep(TIMEOUT_MED);        
            // Click on the menu button
            IWebElement react_burger_menu_btn = wait.Until(c => c.FindElement(By.Id("react-burger-menu-btn")));
            react_burger_menu_btn.Click();
            Thread.Sleep(TIMEOUT_MED);
            // Click on the logout link
            IWebElement logout_sidebar_link = wait.Until(c => c.FindElement(By.Id("logout_sidebar_link")));
            logout_sidebar_link.Click();
            Thread.Sleep(TIMEOUT_MED);
            IWebElement user_name = wait.Until(c => c.FindElement(By.Id("user-name")));
            // Verify user is logged out
            Assert.IsTrue(user_name.Displayed); 
        }
    }
}
