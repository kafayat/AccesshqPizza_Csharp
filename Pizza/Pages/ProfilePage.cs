

using OpenQA.Selenium;
using PizzaHq.Utilities;

namespace PizzaHq.Pages
{
    class ProfilePage : BaseNavigation
    {
        private new IWebDriver _driver;
        public ProfilePage(IWebDriver driver)
            : base(driver)  {
            _driver = driver;  }

        By WelcomeMessage = By.TagName("h2");
        By UserName = By.CssSelector("h2 em");

        public string GetWelcomeMessage(){
            return Utilites.ElementExists(_driver, WelcomeMessage, 90) ?
               _driver.FindElement(WelcomeMessage).Text : "";
        }

        public string GetProfileUrl(){
            return _driver.Url;}

    }
}
