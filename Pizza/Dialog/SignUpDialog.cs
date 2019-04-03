using OpenQA.Selenium;
using PizzaHq.Pages;
using PizzaHq.Utilities;

namespace PizzaHq.Dialog
{
    class SignUpDialog : BaseNavigation
    {
        private new IWebDriver _driver;
        public SignUpDialog(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        By UserNameError = By.Id("username-err");
        By PasswordError = By.Id("password-err");
        By ConfirmPasswordError = By.Id("confirm-err");
        By UsernameField = By.CssSelector(".v-dialog__content--active input[aria-label='Username']");
        By PasswordField = By.CssSelector(".v-dialog__content--active input[aria-label='Password']");
        By ConfirmPasswordField = By.CssSelector(".v-dialog__content--active input[aria-label='Confirm Password']");
        By PopUpMessage = By.CssSelector("div.v-snack--active span.popup-message");
        By SignupButton = By.CssSelector("#signupDialog button[aria-label='signup']");

        public string GetUserNameError(){
            return Utilites.ElementExists(_driver, UserNameError, 90) ?
                    _driver.FindElement(UserNameError).Text : "";}

    }
}
