using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelfFramework.pageObjects
{
    public  class CheckoutPage
    {
        // IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));
        private IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);//wherever it finds FindsBy that will initialize with driver
        }
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutButton;

        public IList<IWebElement> getCards()
        {
            return checkoutCards;
        }
        public SelectionPage getButton()
        {

            checkoutButton.Click();
            return new SelectionPage(driver);
        }
    }
}
