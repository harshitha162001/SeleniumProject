﻿using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace Seleniumclassproject1
{
      public class E2Etest
      {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {

            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }

        [Test]
        public void EndToEndTest()
        {
            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];//creating new arrey
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
           driver.FindElement(By.Name("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList <IWebElement>products= driver.FindElements(By.TagName("app-card"));
            foreach(IWebElement product in products)
            {
               if(expectedProducts.Contains( product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                   // click add to cart
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }
            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            IList <IWebElement> checkoutCards =driver.FindElements(By.CssSelector("h4 a"));
            for(int i = 0;i<checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);


            //clicking checkout button
            driver.FindElement(By.CssSelector(".btn-success")).Click();


            //selecting india 
            driver.FindElement(By.Id("country")).SendKeys("ind");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click() ;

            driver.FindElement(By.CssSelector(".checkbox-primary")).Click();
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();

           String confirmTest=  driver.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirmTest);


        }

    }
}
