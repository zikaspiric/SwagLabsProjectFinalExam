using SwagLabFinalExam.Driver;
using SwagLabFinalExam.Page;

namespace SwagLabFinalExam.Tests
{
    public class BuyProductsTest
    {
        LoginPage loginPage;
        ProductsPage productsPage;
        YourCartPage yourCartPage;
        YourInfoPage yourInfoPage;
        OverViewPage overViewPage;
        CompletePage completePage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productsPage = new ProductsPage();
            yourCartPage = new YourCartPage();
            yourInfoPage = new YourInfoPage();
            overViewPage= new OverViewPage();
            completePage= new CompletePage();
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
            productsPage.AddBackPack.Click();
            productsPage.AddBoltT_Shirt.Click();
            productsPage.AddJacket.Click();
            productsPage.Cart.Click();

            Assert.That(yourCartPage.YourCart.Displayed);
        }

        [Test]
        public void TC02_SortProductByLowPrice_ShouldSortByLowPrice()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productsPage.SelectOption("Price (low to high)");
            productsPage.AddOnesie.Click();
            productsPage.AddBikeLight.Click();
            productsPage.AddBoltT_Shirt.Click();

            Assert.That("3", Is.EqualTo(productsPage.Cart.Text));
        }

        [Test]
        public void TC03_AddAndRemoveTwoProducts_ShouldAddedAndRemovedTwoProducts()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productsPage.AddOnesie.Click();
            productsPage.AddBikeLight.Click();
            productsPage.ShopCartClick.Click();
            yourCartPage.RemoveOnesie.Click();
            yourCartPage.RemoveBikeLight.Click();
            yourCartPage.ButtonContinueShopping.Click();

            Assert.That("", Is.EqualTo(productsPage.EmptyCart.Text));

        }

        [Test]
        public void TC04_CheckItemTotalPrice_ItemTotalPriceShouldBeChecked()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productsPage.AddOnesie.Click();
            productsPage.AddBikeLight.Click();
            productsPage.AddBoltT_Shirt.Click();
            productsPage.ShopCartClick.Click();
            yourCartPage.Checkout.Click();
            yourInfoPage.FirstName.SendKeys("Zika");
            yourInfoPage.LastName.SendKeys("Spiric");
            yourInfoPage.ZipCode.SendKeys("11000");
            yourInfoPage.ButtonContinue.Submit();

            Assert.That("Item total: $33.97", Is.EqualTo(overViewPage.ItemTotal.Text));

        }

        [Test]
        public void TC05_CheckTotalPrice_TotalPriceShouldBeChecked()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productsPage.AddOnesie.Click();
            productsPage.AddBikeLight.Click();
            productsPage.AddBoltT_Shirt.Click();
            productsPage.ShopCartClick.Click();
            yourCartPage.Checkout.Click();
            yourInfoPage.FirstName.SendKeys("Zika");
            yourInfoPage.LastName.SendKeys("Spiric");
            yourInfoPage.ZipCode.SendKeys("11000");
            yourInfoPage.ButtonContinue.Submit();

            Assert.That("Total: $36.69", Is.EqualTo(overViewPage.Total.Text));

        }

        [Test]
        public void TC06_Buy3Products_ShouldBuy3Products()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productsPage.AddOnesie.Click();
            productsPage.AddBikeLight.Click();
            productsPage.AddBoltT_Shirt.Click();
            productsPage.ShopCartClick.Click();
            yourCartPage.Checkout.Click();
            yourInfoPage.FirstName.SendKeys("Zika");
            yourInfoPage.LastName.SendKeys("Spiric");
            yourInfoPage.ZipCode.SendKeys("11000");
            yourInfoPage.ButtonContinue.Submit();
            overViewPage.Finish.Click();
            completePage.ButtonBurger.Click();
            completePage.Logout.Click();

            String currentUrl = WebDrivers.Instance.Url;
            Assert.That(currentUrl, Is.EqualTo(loginPage.HomeUrl));

        }
    }
}
