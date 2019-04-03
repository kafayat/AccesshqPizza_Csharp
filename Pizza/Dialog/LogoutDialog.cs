using OpenQA.Selenium;
using PizzaHq.Pages;
using PizzaHq.Utilities;

namespace PizzaHq.Dialog
{
    class LogoutDialog : BaseNavigation
    {
        private new IWebDriver _driver;
        public LogoutDialog(IWebDriver driver)
            : base(driver)  {
            _driver = driver;}

        By YesButton = By.CssSelector("div.v-dialog--active   button[aria-label='yes']");

        public void clickYesButton(){
            _driver.FindElement(YesButton).SendKeys(Keys.Enter);
        }
    }
}
