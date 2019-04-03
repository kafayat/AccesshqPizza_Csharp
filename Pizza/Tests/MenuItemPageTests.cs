using NUnit.Framework;
using Pizza.Menu;
using PizzaHq.Dialog;
using PizzaHq.Pages;
using System.Collections.Generic;

namespace PizzaHq.Tests
{
    class MenuItemPageTests : BaseTestSuite
    {
        [Test]
        public void ValidItemByKilojoulesAndPrice()
        {
            HomePage homepage = new HomePage(driver);
            MenuItemPage menupage = homepage.clickMenuLink();
            menupage.ClickSideTab();
            List<Item> items = menupage.getMenuItems(new MatchByTitle("Chunky Chips and Aioli"));
            Assert.AreEqual(items[0].getProductKilojoules(), "3273 kJ", "Kilojoules are incoorect");
            Assert.AreEqual(items[0].getProductPrice(), "$9.99", "Item price is incoorect");
        }

        [Test]
        public void ValidateNewItems()
        {
            HomePage homepage = new HomePage(driver);
            MenuItemPage menupage = homepage.clickMenuLink();
            menupage.ClickSideTab();
            List<Item> items = menupage.getMenuItems(new MatchByRibbon("NEW"));

            Assert.AreEqual(items[0].getTitle(), "Korean Sticky Wings", "Name of the new item is not correct");
            Assert.AreEqual(items[0].getImageAltTag(), "Korean Sticky Wings", "Image alt tag of the new item is not correct");
        }

        [Test]
        public void ValidVeganPizzaPrice()
        {
            HomePage homepage = new HomePage(driver);
            MenuItemPage menupage = homepage.clickMenuLink();
            menupage.clickPizzaTab();
            List<Item> items = menupage.getMenuItems(new MatchByVegan());
            foreach (Item menuItem in items)
            {
                Assert.AreEqual(menuItem.getProductPrice(), "$14.99", "price of " + menuItem.GetItemName() + " is not correct");

            }
        }

        [Test]
        public void MenuItemStarRating()
        {
            HomePage homepage = new HomePage(driver);
            MenuItemPage menupage = homepage.clickMenuLink();
            menupage.clickDrinkTab();
            List<Item> items = menupage.getMenuItems(new MatchByStar(0));
            items[0].ClickStar(3);
            Assert.AreEqual(items[0].getStarRating(), 0, "All star did not have 0 rating ");

            LoginDialog loginDialog = menupage.ClickLoginLink();
            loginDialog.SetUserName("bob");
            loginDialog.SetPassowrd("ilovepizza");
            loginDialog.ClickLogin();

            items[0].ClickStar(3);
            Assert.AreEqual(items[0].getStarRating(), 3, "Incorrect number of stars ");


        }
    }
}




