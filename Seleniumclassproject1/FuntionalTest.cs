using OpenQA.Selenium.Edge;
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
    
    public class FuntionalTest
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
        public void DropDown()
        {
           IWebElement dropdown=driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("Teacher");
            s.SelectByValue("consult");
            s.SelectByIndex(1);
            //radiobutton
            IList <IWebElement> rdos= driver.FindElements(By.CssSelector("input[type='radio']"));
            //rdos[1].Click();
            foreach(  IWebElement radiobutton in rdos)
            {
               if(radiobutton.GetAttribute("value").Equals("user"))
                {
                    radiobutton.Click();
                }
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));

            driver.FindElement(By.Id("okayBtn")).Click();
        /*  Boolean result=  driver.FindElement(By.Id("userType")).Selected;//in our site selected option not available so return failed test

            Assert.That(result, Is.True);*///for boolean assertion 

        }


    }
}
