using OpenQA.Selenium;
using SwagLabFinalExam.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabFinalExam.Page
{
    public class CompletePage
    {
        private IWebDriver driver = WebDrivers.Instance;
                
        public IWebElement ButtonBurger => driver.FindElement(By.Id("react-burger-menu-btn"));
        public IWebElement Logout => driver.FindElement(By.Id("logout_sidebar_link"));
    }
}
