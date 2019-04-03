using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHq.Pages
{
     class HomePage  :BaseNavigation
    {
        private new IWebDriver _driver;
        public HomePage(IWebDriver driver)
             : base(driver) {
            _driver = driver; }

        public  void NaivgatetoUrl(string url){
            _driver.Navigate().GoToUrl(url);}




    }
}
