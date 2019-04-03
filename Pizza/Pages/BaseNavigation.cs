using OpenQA.Selenium;
using Pizza.Pages;
using PizzaHq.Dialog;
using PizzaHq.Tests;
using PizzaHq.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHq.Pages
{
    class BaseNavigation
    {

        protected static IWebDriver _driver { get; set; }

        By homeLink = By.ClassName("nav-home");
        By menuLink = By.ClassName("nav-menu");
        By contactLink = By.ClassName("nav-contact");
        By userLink = By.ClassName("nav-login-signup");
        By profileLink = By.ClassName("nav-profile");
        By logoutLink = By.LinkText("Logout");
        By orderLink = By.ClassName("nav-order");
        By orderCount = By.ClassName("order-count");

        public BaseNavigation(IWebDriver driver){
            _driver = driver;}

        public ContactPage clickContactLink(){
         _driver.FindElement(contactLink).Click();
            return new ContactPage(_driver);}

        public LoginDialog ClickLoginLink(){
            _driver.FindElement(userLink).Click();
            return new LoginDialog(_driver);}

        public ProfilePage ClickProfileLink() { 
            _driver.FindElement(profileLink).Click();
            return new ProfilePage(_driver);
        }

        public LogoutDialog clickLogoutLink()
        {
            Utilites.moveToElement(_driver, profileLink);
            _driver.FindElement(logoutLink).Click();
            return new LogoutDialog(_driver);
        }

        public MenuItemPage clickMenuLink(){
            _driver.FindElement(menuLink).Click();
            return new MenuItemPage(_driver);
        }

        public string GetOrderCount()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
           // return Utilites.ElementExists(_driver, orderCount, 20) ?
            //  _driver.FindElement(orderCount).Text : "";
            return _driver.FindElement(orderCount).Text;
        }
        public OrderPage ClickOrderLink()
        {
            _driver.FindElement(orderLink).Click();
            return new OrderPage(_driver);
        }
    }

    
}
