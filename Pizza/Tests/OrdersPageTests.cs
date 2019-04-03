using NUnit.Framework;
using Pizza.Menu;
using Pizza.Pages;
using PizzaHq.Pages;
using PizzaHq.Tests;
using System.Collections.Generic;


namespace Pizza.Tests
{
    class OrdersPageTests : BaseTestSuite
    {

        [Test]
        public void OrderSubtotalValidation()
        {

            HomePage homePage = new HomePage(driver);
            MenuItemPage menuPage = homePage.clickMenuLink();
            menuPage.clickDrinkTab();
            List<Item> menuItems = menuPage.getMenuItems(new MatchByTitle("Espresso Thickshake"));
            menuItems[0].ClickOrderButton();
            
            menuPage.clickPizzaTab();
            menuItems = menuPage.getMenuItems(new MatchByTitle("Margherita"));
            menuItems[0].ClickOrderButton();
            menuItems[0].ClickOrderButton();

           Assert.AreEqual("3", menuPage.GetOrderCount(), "The order count is not correct");
             OrderPage orderPage = menuPage.ClickOrderLink();
            Assert.AreEqual("4.99", orderPage.GetItemSubtotal("Espresso Thickshake"), "subtotal was incorrect");
            

        }
    }
}
