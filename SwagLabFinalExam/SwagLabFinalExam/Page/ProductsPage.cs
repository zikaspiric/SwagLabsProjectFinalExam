using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwagLabFinalExam.Driver;

namespace SwagLabFinalExam.Page
{
    public class ProductsPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement AddOnesie => driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));
        public IWebElement AddBikeLight => driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        public IWebElement AddBoltT_Shirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        public IWebElement Cart => driver.FindElement(By.CssSelector("#shopping_cart_container .shopping_cart_badge"));
        public IWebElement EmptyCart => driver.FindElement(By.Id("shopping_cart_container"));
        public IWebElement SortByPrice => driver.FindElement(By.ClassName("product_sort_container"));
        public IWebElement ShopCartClick => driver.FindElement(By.Id("shopping_cart_container"));
        public IWebElement AddBackPack => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        public IWebElement AddJacket => driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket"));


        public string InventoryUrl = "https://www.saucedemo.com/inventory.html";
        

        public void SelectOption(string text)

        {
            SelectElement element = new SelectElement(SortByPrice);
            element.SelectByText(text);
        }
    }
}
