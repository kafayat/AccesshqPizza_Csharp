using System;
using OpenQA.Selenium;
using PizzaHq.Utilities;

namespace PizzaHq.Pages
{
    class ContactPage : BaseNavigation
    {
        private new IWebDriver _driver;
        public ContactPage(IWebDriver driver)
             : base(driver)
        {
            _driver = driver;
        }

        By fornameField = By.Id("forename");
        By emailField = By.Id("email");
        By messageField = By.Id("message");
        By phoneField = By.Id("telephone");
        By submitButton = By.CssSelector("a[aria-label='submit']");
        By clearButton = By.CssSelector("a[aria-label='clear']");
        By forenameError = By.Id("forename-err");
        By emailError = By.Id("email-err");
        By messageError = By.Id("message-err");
        By phoneError = By.Id("telephone-err");
        By successMessage = By.CssSelector("div.success-message div");


        public void ClickSubmit()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(submitButton).Click();
        }

        public void SetFornameField(string forname)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(fornameField).SendKeys(forname);
        }

        public void SetEmailField(string email)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(emailField).SendKeys(email);
        }

        public void SetMessageField(string message)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(messageField).SendKeys(message);
        }

        public void SetPhoneField(string phone)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            _driver.FindElement(phoneField).SendKeys(phone);
        }

        public string GetEmailError()
        {
             return Utilites.ElementExists(_driver, emailError, 20) ?
               _driver.FindElement(emailError).Text : "";

        }
    }
}

   
