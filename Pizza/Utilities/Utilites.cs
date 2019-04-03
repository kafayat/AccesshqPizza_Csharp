using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PizzaHq.Tests;
using System;

namespace PizzaHq.Utilities
{
    class Utilites
    {
        
        //this will search for the element until a timeout is reached
        public static IWebElement WaitUntilElementVisible(IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }

        public static IWebElement FindElement(IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }


        public static bool ElementExists(IWebDriver driver, By locator, int timeoutInSeconds)
        {

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                //check for existence of element
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
                //check that its visible
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
/*
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSeconds);
                //check for existence of element
                (new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
                //check that its visible
                (new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
                */
                //re enable timeout
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(BaseTestSuite.IMPLICIT_WAIT);
              
                return true;
            }
            catch (Exception e)
            {
                //reset timeout on exception
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(BaseTestSuite.IMPLICIT_WAIT);
                return false;
            }
        }


        public static void moveToElement(IWebDriver driver, By locator)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(locator));
            actions.Click();
            actions.Build().Perform();
        }
    }
}
