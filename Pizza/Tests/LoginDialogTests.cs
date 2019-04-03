
using NUnit.Framework;
using PizzaHq.Dialog;
using PizzaHq.Pages;

namespace PizzaHq.Tests
{
    class LoginDialogTests : BaseTestSuite
    {

        [Test]
        public void LoginFieldValidationErrorMessage()
        {
            HomePage homepage = new HomePage(driver);
            LoginDialog logindialog = homepage.ClickLoginLink();
            logindialog.ClickLogin();
            Assert.AreEqual("Your login was unsuccessful - please try again", logindialog.GetAlertMessage(), "Alert Message did not display correctly");           // logindialog.ClickDismissIcon();
            logindialog.ClickDismissIcon();
            Assert.AreEqual("", logindialog.GetAlertMessage(), "Alert Message did not clear correctly");
        }

        [Test]
        public void LoginProfileValidation()
        {
            HomePage homepage = new HomePage(driver);
            //string HomeURL = homepage.NaivgatetoUrl();
            LoginDialog logindialog = homepage.ClickLoginLink();
            string username = "bob";
            logindialog.SetUserName(username);
            logindialog.SetPassowrd("ilovepizza");
            logindialog.ClickLogin();
            ProfilePage profile = homepage.ClickProfileLink();

            string profileUrl = profile.GetProfileUrl();
             LogoutDialog logout = profile.clickLogoutLink();
             logout.clickYesButton();
        }
    }
}
