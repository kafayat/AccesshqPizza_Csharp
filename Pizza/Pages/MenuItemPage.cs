using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pizza.Menu;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace PizzaHq.Pages
{
    class MenuItemPage : BaseNavigation
    {
        private new IWebDriver _driver;
        public MenuItemPage(IWebDriver driver)
             : base(driver)
        {
            _driver = driver;
        }

        By SidesTabLink = By.PartialLinkText("SIDES");
        By PizzaTabLink = By.PartialLinkText("PIZZAS");
        By DrinksTabLink = By.PartialLinkText("DRINKS");
        By SideList = By.CssSelector("div.sides-tab");
        By MenuItemsContainer = By.ClassName("v-window-item");
        By MenuItem = By.ClassName("menuItem");
        By SidesTabPage = By.ClassName("sides-tab");
        By PizzaTabPage = By.ClassName("pizza-tab");
        By DrinksTabPage = By.ClassName("drinks-tab");

        public void ClickSideTab()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            _driver.FindElement(SidesTabLink).Click();
            waitForItemsToDisplay(SidesTabPage);
        }
        
        public void clickPizzaTab()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _driver.FindElement(PizzaTabLink).Click();
           //  waitForItemsToDisplay(PizzaTabPage);
        }

        public void clickDrinkTab()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _driver.FindElement(DrinksTabLink).Click();
            waitForItemsToDisplay(DrinksTabPage);
        }
        
        private void waitForItemsToDisplay(By expectedTab)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3))
           .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(expectedTab));

            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 3));
            wait.Until(condition =>
            {
                try
                {
                    return visibleMenuItems() > 0;
                }
                catch (Exception e)
                {
                    return _driver.FindElement(MenuItemsContainer).Text.Length != 0;
                }

            });
        }

        private int visibleMenuItems()
        {
            int visibleCount = 0;
            IWebElement visibleContainer = getVisibleMenuItemPage();
            IList<IWebElement> items = visibleContainer.FindElements(MenuItem);

            foreach (IWebElement item in items)
            {
                if (item.Displayed)
                {
                    visibleCount++;
                }
            }
            return visibleCount;
        }

        private IWebElement getVisibleMenuItemPage()
        {
            IList<IWebElement> items = _driver.FindElements(MenuItemsContainer);
            foreach (IWebElement item in items)
            {
                if (item.Displayed)
                {
                    return item;
                }
            }
            throw new Exception("Page is not visible");
        }

        private IWebElement getVisibleItemContainer()
        {
            IList<IWebElement> itemContainers = _driver.FindElements(MenuItemsContainer);
            foreach (IWebElement itemContainer in itemContainers)
            {
                if (itemContainer.Displayed)
                {
                    return itemContainer;
                }
            }
            throw new Exception("no visible container found");
        }

        public List<Item> getMenuItems(IMatchStrategy strategy)
        {
            List<Item> menuitems = new List<Item>();
            IWebElement visibleContainer = getVisibleItemContainer();
            IList<IWebElement> items = visibleContainer.FindElements(MenuItem);
            foreach (IWebElement item in items)
            {
                if (items.Count > 0)
                {
                    Item menuitem = new Item(item, _driver);
                    if (strategy.MatchProduct(menuitem))
                    {
                        menuitems.Add(menuitem);
                    }
                }
            }
            return menuitems;
        }
    }
}


    