using OpenQA.Selenium;
using PizzaHq.Pages;
using PizzaHq.Utilities;

namespace PizzaHq.Dialog
{
    class LoginDialog :BaseNavigation
    {
        By LoginButton = By.CssSelector("div.v-dialog--active button[aria-label='login']");
        By AlertMessage = By.CssSelector("div.v-dialog--active i + div");
        By DismissIcon = By.CssSelector("div.v-dialog--active a.v-alert__dismissible");
        By UserNameField = By.CssSelector("div.v-dialog--active input[id*='username']");
        By PassowrdField = By.CssSelector("div.v-dialog--active input[id*='password']");
        By SignupLink = By.LinkText("Sign Up");

        private new IWebDriver _driver;
        public LoginDialog(IWebDriver driver)
             : base(driver)  {
            _driver = driver;}

        public void ClickLogin() {
            _driver.FindElement(LoginButton).SendKeys(Keys.Enter);}

        public string GetAlertMessage(){
            return Utilites.ElementExists(_driver, AlertMessage, 90) ?
               _driver.FindElement(AlertMessage).Text : "";}

        public void ClickDismissIcon(){
            _driver.FindElement(DismissIcon).Click();}

        public void SetUserName(string username){
            _driver.FindElement(UserNameField).SendKeys(username);}

        public void SetPassowrd(string password){
            _driver.FindElement(PassowrdField).SendKeys(password);}

        public SignUpDialog clickSignUpLink(){
            _driver.FindElement(SignupLink).Click();
            return new SignUpDialog(_driver);}

    }
}
