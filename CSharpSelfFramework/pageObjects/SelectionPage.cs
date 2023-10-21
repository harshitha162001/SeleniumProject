using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelfFramework.pageObjects
{
    public  class SelectionPage
    {
        private IWebDriver driver;
        public SelectionPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);//wherever it finds FindsBy that will initialize with driver
        }
        // driver.FindElement(By.Id("country")).SendKeys("ind");
        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement selectingElement;

        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement linkTextproperty;

        [FindsBy(How=How.CssSelector,Using = "label[for*='checkbox2']")]
        private IWebElement checkboxbtn;

        [FindsBy(How = How.CssSelector, Using = "[value='Purchase']")]
        private IWebElement purchasebtn;
        //driver.FindElement(By.CssSelector(".alert-success")).Text;


        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement successbtn;



        public IWebElement getSelectingName()
        {
            return selectingElement;
        }
        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }
       

       /* driver.FindElement(By.LinkText("India")).Click();
        driver.FindElement(By.CssSelector(".checkbox-primary")).Click();
        driver.FindElement(By.CssSelector("[value='Purchase']")).Click();*/
       public void validSelection()
        {
            linkTextproperty.Click();
            checkboxbtn.Click();
            purchasebtn.Click();
        }
        public IWebElement getSuccessBtn()
        {
            return successbtn;
        }
    }
}
