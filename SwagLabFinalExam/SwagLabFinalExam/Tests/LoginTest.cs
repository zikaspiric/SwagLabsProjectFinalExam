using SwagLabFinalExam.Driver;
using SwagLabFinalExam.Page;

namespace SwagLabFinalExam.Tests
{
    public class Tests
    {
        LoginPage loginpage;
        string Message = "Epic sadface: Username and password do not match any user in this service";

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginpage = new LoginPage();
        }

        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_EnterInvalidUserName_ShouldNotBeLoginOnPage()
        {
            loginpage.Login("aaaaaa", "secret_sauce");
            Assert.That(Message, Is.EqualTo(loginpage.UserNotLogin.Text));

        }

        [Test]
        public void TC02_EnterInvalidPassword_ShouldBeNotLoginOnPage()
        {
            loginpage.Login("standard_user", "xxxxxx");
            Assert.That(Message, Is.EqualTo(loginpage.UserNotLogin.Text));

        }

        [Test]
        public void TC03_EnterInvalidData_ShouldBeNotLoginOnPage()
        {
            loginpage.Login("standard", "secret");
            Assert.That(Message, Is.EqualTo(loginpage.UserNotLogin.Text));

        }
    }
}