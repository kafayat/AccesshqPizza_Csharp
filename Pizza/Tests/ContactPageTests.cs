using NUnit.Framework;
using PizzaHq.Pages;


namespace PizzaHq.Tests
{
    class ContactPageTests : BaseTestSuite
    {
        [Test]
        public void FieldValidationErrorMessages()
        {
            HomePage homePage = new HomePage(driver);
            ContactPage contactPage = homePage.clickContactLink();

            contactPage.SetEmailField("xxx");
            contactPage.SetPhoneField("xxxx");
            contactPage.SetMessageField("");
            contactPage.ClickSubmit();
            Assert.AreEqual("Email is invalid", contactPage.GetEmailError(), "Email format error did not display correctly");

        }
    }
}
