using OpenQA.Selenium;
using SwagLabFinalExam.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabFinalExam.Page
{
    public class YourCartPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement Checkout => driver.FindElement(By.Id("checkout"));
        public IWebElement RemoveOnesie => driver.FindElement(By.Id("remove-sauce-labs-onesie"));
        public IWebElement RemoveBikeLight => driver.FindElement(By.Id("remove-sauce-labs-bike-light"));
        public IWebElement ButtonContinueShopping => driver.FindElement(By.Id("continue-shopping"));
        public IWebElement YourCart => driver.FindElement(By.ClassName("header_secondary_container"));
                              
    }
}
