using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pizza.Table;
using PizzaHq.Pages;
using System;
using System.Collections.Generic;

namespace Pizza.Pages
{
    class OrderPage : BaseNavigation
    {
        private new IWebDriver _driver;
        public OrderPage(IWebDriver driver)
            : base(driver)
        {
            _driver = driver;
        }
        By orderTable = By.ClassName("v-datatable");

        private void WaitForTableToDisplay()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 3));
            wait.Until(condition =>
            {
                return _driver.FindElement(orderTable).Text.Length != 0;
            });
        }

        public string GetItemSubtotal(string itemName)
        {
            WaitForTableToDisplay();
            IWebElement table = _driver.FindElement(orderTable);
            TableHelper tableHelper = new TableHelper(table);
            IList<IWebElement> tableCells = tableHelper.GetItemRowCells(itemName, "Name");
            int subTotalColumn = tableHelper.GetColumnIndex("Subtotal");
            return tableCells[subTotalColumn].Text;
        }
    }
}
