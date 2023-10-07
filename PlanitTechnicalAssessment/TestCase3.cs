using NUnit.Framework;
using NUnit.Framework.Interfaces;
using PlanitTechnicalAssessment.TestFrameWork;
using System.Globalization;
using System.Linq;

namespace PlanitTechnicalAssessment
{
    public class TestCase3
    {
        TestConfig testConfig;

        /// <summary>
        /// Initialise all basic configurations of the tests ie web browser, driver, application url, waits
        /// </summary>
        [SetUp]
        public void Setup()
        {
            testConfig = new TestConfig();
            testConfig.InitializeTestConfig();
        }

        [Test]
        public void GoToShopPage_BuySomeProducts_ValidateTotalPurchasePrice()
        {
            Shop shop = new Shop();
            shop.GoTo();

            testConfig.ImplicitWait(15*1000);

            //Buy 2 stuffed Frog
            double stuffedFrogTotalPrice = 0.00;
            for (int NumberOfItems = 0; NumberOfItems < 2; NumberOfItems++)
                stuffedFrogTotalPrice = BuyStuffedFrog(shop, stuffedFrogTotalPrice);

            //But 5 Fluffy Bunny
            double fluffyBunnyTotalPrice = 0.00;
            for (int NumberOfItems = 0; NumberOfItems < 5; NumberOfItems++)
                fluffyBunnyTotalPrice = BuyFluffyBunny(shop, fluffyBunnyTotalPrice);

            // Buy 3 Valentine Bear
            double valentineBearTotalPrice = 0.00;
            for (int NumberOfItems = 0; NumberOfItems < 3; NumberOfItems++)
                valentineBearTotalPrice = BuyValentineBear(shop, valentineBearTotalPrice);

            if (shop.CollapseMenu.Exists)
            {
                shop.CollapseMenu.Click();
            }

            shop.Cart.Click();
            testConfig.ImplicitWait(1 * 500);

            var cart = new Cart();
            var totalPurchaseAmount = double.Parse(cart.Total.InnerText.Split("Total:").LastOrDefault());
            Assert.That(totalPurchaseAmount, Is.EqualTo(stuffedFrogTotalPrice + fluffyBunnyTotalPrice + valentineBearTotalPrice), "The cart total should be equal to sum of sub total of each purchased item");
        }

        private static double BuyFluffyBunny(Shop shop, double fluffyBunnyTotalPrice)
        {
            shop.FluffyBunny.Buy.Click();
            fluffyBunnyTotalPrice += double.Parse(shop.FluffyBunny.Price.InnerText, NumberStyles.Currency);
            return fluffyBunnyTotalPrice;
        }

        private static double BuyStuffedFrog(Shop shop, double fluffyBunnyTotalPrice)
        {
            shop.StuffedFrog.Buy.Click();
            fluffyBunnyTotalPrice += double.Parse(shop.StuffedFrog.Price.InnerText, NumberStyles.Currency);
            return fluffyBunnyTotalPrice;
        }

        private static double BuyValentineBear(Shop shop, double fluffyBunnyTotalPrice)
        {
            shop.ValentineBear.Buy.Click();
            fluffyBunnyTotalPrice += double.Parse(shop.ValentineBear.Price.InnerText, NumberStyles.Currency);
            return fluffyBunnyTotalPrice;
        }


        /// <summary>
        /// close borser and take screenshot. Can add additional cleanups here
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            testConfig.cleanup();
        }
    }
}
