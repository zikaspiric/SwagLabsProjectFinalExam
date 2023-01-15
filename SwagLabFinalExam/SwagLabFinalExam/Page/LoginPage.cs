using OpenQA.Selenium;
using SwagLabFinalExam.Driver;

namespace SwagLabFinalExam.Page
{
    public class LoginPage
    {
        private IWebDriver driver = WebDrivers.Instance;
        public IWebElement UserName => driver.FindElement(By.Id("user-name"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement ButtonLogin => driver.FindElement(By.Id("login-button"));
        public IWebElement UserNotLogin => driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3"));
        public IWebElement NoDataLogin => driver.FindElement(By.CssSelector("#login_button_container h3"));

        public string HomeUrl = "https://www.saucedemo.com/";


        public void Login(string name, string pass)
        {
            UserName.SendKeys(name);
            Password.SendKeys(pass);
            ButtonLogin.Submit();
        }
    }
}
