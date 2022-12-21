using SwagLabFinalExam.Driver;
using SwagLabFinalExam.Page;

namespace SwagLabFinalExam.Tests
{
    public class Tests
    {
        LoginPage loginpage;
        ProductPage productPage;
        string Message = "Epic sadface: Username and password do not match any user in this service";

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginpage = new LoginPage();
            productPage = new ProductPage();
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

        [Test]
        public void TC04_EnterValidData_ShouldBeLoginOnPage()
        {
            loginpage.Login("standard_user", "secret_sauce");
            Assert.That("https://www.saucedemo.com/inventory.html", Is.EqualTo(productPage.HomeUrl));

        }

        [Test]
        public void TC05_EnterNoData_ShouldBeNotLoginOnPage()
        {
            loginpage.Login("", "");
            Assert.That("Epic sadface: Username is required", Is.EqualTo(loginpage.NoDataLogin.Text));

        }
    }
}