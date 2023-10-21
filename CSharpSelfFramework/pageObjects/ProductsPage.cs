﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelfFramework.pageObjects
{
    public class ProductsPage
    {
        /* WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
         wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));*/
        //IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
        //driver.FindElement(By.PartialLinkText("Checkout")).Click();
        IWebDriver driver;
        By cardTitle = By.CssSelector(".card-title a");
        By addToCart = By.CssSelector(".card-footer button");

        public ProductsPage(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);//we have to register driver
        }


        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkoutButton;



        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout"))); 
        }
        public IList<IWebElement> getCards()
        {
            return cards;

        }
        public By getCardTitle()
        {
            return cardTitle;
        }
        public By AddToCardButton()
        {
            return addToCart;
        }
        public CheckoutPage checkout()
        {
           checkoutButton.Click();
            return new CheckoutPage(driver);
        }

    }
}
