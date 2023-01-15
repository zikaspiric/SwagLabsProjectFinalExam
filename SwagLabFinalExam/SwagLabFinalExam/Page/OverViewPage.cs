using OpenQA.Selenium;
using SwagLabFinalExam.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabFinalExam.Page
{
    public class OverViewPage
    {
        private IWebDriver driver = WebDrivers.Instance;
       
        public IWebElement Finish => driver.FindElement(By.Id("finish"));        
        public IWebElement Total => driver.FindElement(By.ClassName("summary_total_label"));
        public IWebElement ItemTotal => driver.FindElement(By.ClassName("summary_subtotal_label"));
    }
}
