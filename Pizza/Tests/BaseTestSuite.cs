using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PizzaHq.Tests
{
    [TestFixture]
    class BaseTestSuite
    {
        protected static IWebDriver driver;
        public static int IMPLICIT_WAIT = 5;
        [OneTimeSetUp]
        public static void setUpBeforeClass()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void setUp()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://d3sy4dht7a7sfd.cloudfront.net/");
        }

        [TearDown]
        public static void tearDownAfterClass()
        {
            driver.Quit();
        }
    }
}