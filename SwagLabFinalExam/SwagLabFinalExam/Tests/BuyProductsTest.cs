using SwagLabFinalExam.Driver;
using SwagLabFinalExam.Page;

namespace SwagLabFinalExam.Tests
{
    public class BuyProductsTest
    {
        LoginPage loginPage;
        ProductPage productPage;
        CartPage cartPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cartPage = new CartPage();
        }

        [TearDown]
        public void ClosePage()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_AddThreeNewProductInCart_ShouldDisplayedThreeProductsInCart()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPack.Click();
            productPage.AddBoltT_Shirt.Click();
            productPage.AddJacket.Click();
            productPage.Cart.Click();

            Assert.That(cartPage.YourCartPage.Displayed);
        }

        [Test]
        public void TC02_SortProductByLowPrice_ShouldSortByLowPrice()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.SelectOption("Price (low to high)");
            productPage.AddOnesie.Click();
            productPage.AddBikeLight.Click();
            productPage.AddBoltT_Shirt.Click();

            Assert.That("3", Is.EqualTo(productPage.Cart.Text));
        }

        [Test]
        public void TC03_AddAndRemoveTwoProducts_ShouldAddedAndRemovedTwoProducts()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddOnesie.Click();
            productPage.AddBikeLight.Click();
            productPage.ShopCartClick.Click();
            cartPage.RemoveOnesie.Click();
            cartPage.RemoveBikeLight.Click();
            cartPage.ButtonContinueShopping.Click();

            Assert.That("", Is.EqualTo(productPage.EmptyCart.Text));

        }

        [Test]
        public void TC04_CheckItemTotalPrice_ItemTotalPriceShouldBeChecked()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddOnesie.Click();
            productPage.AddBikeLight.Click();
            productPage.AddBoltT_Shirt.Click();
            productPage.ShopCartClick.Click();
            cartPage.Checkout.Click();
            cartPage.FirstName.SendKeys("Zika");
            cartPage.LastName.SendKeys("Spiric");
            cartPage.ZipCode.SendKeys("11000");
            cartPage.ButtonContinue.Submit();

            Assert.That("Item total: $33.97", Is.EqualTo(cartPage.ItemTotal.Text));

        }

        [Test]
        public void TC05_CheckTotalPrice_TotalPriceShouldBeChecked()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddOnesie.Click();
            productPage.AddBikeLight.Click();
            productPage.AddBoltT_Shirt.Click();
            productPage.ShopCartClick.Click();
            cartPage.Checkout.Click();
            cartPage.FirstName.SendKeys("Zika");
            cartPage.LastName.SendKeys("Spiric");
            cartPage.ZipCode.SendKeys("11000");
            cartPage.ButtonContinue.Submit();

            Assert.That("Total: $36.69", Is.EqualTo(cartPage.Total.Text));

        }

        [Test]
        public void TC06_Buy3Products_ShouldBuy3Products()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddOnesie.Click();
            productPage.AddBikeLight.Click();
            productPage.AddBoltT_Shirt.Click();
            productPage.ShopCartClick.Click();
            cartPage.Checkout.Click();
            cartPage.FirstName.SendKeys("Zika");
            cartPage.LastName.SendKeys("Spiric");
            cartPage.ZipCode.SendKeys("11000");
            cartPage.ButtonContinue.Submit();
            cartPage.Finish.Click();

            Assert.That("THANK YOU FOR YOUR ORDER", Is.EqualTo(cartPage.OrderFinished.Text));

        }
    }
}
