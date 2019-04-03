using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace Pizza.Menu
{
    public class Item
    {
        private IWebElement items;
        private IWebDriver driver;

        public Item(IWebElement items, IWebDriver driver)
        {
            this.items = items;
            this.driver = driver;
        }

        By ribbon = By.ClassName("ribbon-top-left");
        By title = By.CssSelector(".menuItem h3 span");
        By productImage = By.TagName("img");
        By kilojoules = By.ClassName("kilojoules");
        By productName = By.ClassName("name");
        By price = By.ClassName("price");
        By veganIcon = By.ClassName("orange");
        By vegetarianIcon = By.ClassName("green");
        By addtoOrdertButton = By.CssSelector("button[aria-label='Add to order']");
        By StarRating = By.CssSelector("div.v-rating > i");


        public string getTitle(){

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string Titletext = items.FindElements(title).Count > 0 ?
                            items.FindElement(title).Text : "";

            return Titletext;

            
        }

        public string getImageAltTag() {
            return items.FindElement(productImage).GetAttribute("alt").ToString();
        }

        public string getRibbonText() {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string ribbonText = items.FindElements(ribbon).Count > 0 ?
                            items.FindElement(ribbon).Text : "";
                    
            return ribbonText;
        }
        
        public string GetItemName()   {
      
          // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
           
            string itemName = items.FindElement(productName).Text;
           // System.Console.Out.WriteLine(itemName);
            //char[] character = "\\r?\\n".ToCharArray();
            string[] lines = itemName.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return lines[0].Trim();
            

        }
        
        public string getProductKilojoules() {
            return items.FindElement(kilojoules).Text;
        }

        public string getProductPrice() {
            return items.FindElement(price).Text;
        }

        public bool getVeganPizza() {
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            bool isVegan = items.FindElements(veganIcon).Count > 0 ? true : false;
                   return isVegan; }

        public bool getVegetarianPizza()
        {
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            bool isVegetarian = items.FindElements(vegetarianIcon).Count > 0 ? true : false;
            return isVegetarian;
        }

        public void ClickOrderButton()
        {
            items.FindElement(addtoOrdertButton).Click();
        }

        public int getStarRating()
        {
            int starCount = 0;
            IList<IWebElement> stars = items.FindElements(StarRating);
            foreach (IWebElement star in stars)
            {
                if (star.Text.Equals("star"))
                {
                    starCount++;
                }
            }
            return starCount;
        }
        
        public void ClickStar(int starposition)
        {

            starposition = starposition > 0 ? starposition - 1 : 0;
            IList<IWebElement> stars = items.FindElements(StarRating);
            Actions actions = new Actions(driver);
             actions.MoveToElement(stars[starposition]);
           //actions.sendKeys("");
            actions.Click();
            actions.Build().Perform();
            

        }
        


    }
}
