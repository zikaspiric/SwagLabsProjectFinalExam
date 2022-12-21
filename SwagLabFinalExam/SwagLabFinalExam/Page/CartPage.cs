using OpenQA.Selenium;
using SwagLabFinalExam.Driver;

namespace SwagLabFinalExam.Page
{
    public class CartPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement Checkout => driver.FindElement(By.Id("checkout"));
        public IWebElement FirstName => driver.FindElement(By.Id("first-name"));
        public IWebElement LastName => driver.FindElement(By.Id("last-name"));
        public IWebElement ZipCode => driver.FindElement(By.Id("postal-code"));
        public IWebElement RemoveOnesie => driver.FindElement(By.Id("remove-sauce-labs-onesie"));
        public IWebElement RemoveBikeLight => driver.FindElement(By.Id("remove-sauce-labs-bike-light"));
        public IWebElement ButtonContinueShopping => driver.FindElement(By.Id("continue-shopping"));
        public IWebElement ButtonContinue => driver.FindElement(By.Id("continue"));
        public IWebElement YourCartPage => driver.FindElement(By.ClassName("header_secondary_container"));
        public IWebElement Finish => driver.FindElement(By.Id("finish"));
        public IWebElement OrderFinished => driver.FindElement(By.CssSelector("#checkout_complete_container .complete-header"));
        public IWebElement Total => driver.FindElement(By.ClassName("summary_total_label"));
        public IWebElement ItemTotal => driver.FindElement(By.ClassName("summary_subtotal_label"));
    }
}
