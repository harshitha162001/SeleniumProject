using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using AngleSharp.Css.Parser;
using OpenQA.Selenium.Support.UI;

namespace Seleniumclassproject1
{
    public class Locators
    {
        //selenium supports locators like Xpath,css,id,classname,name,tagname,LinkText

        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
           
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            //implicit wait 5seconds can be declared globally
            //if the execution is complited within 3 seconds then rest of 2seconds will be saved
            //whereas in Thread.sleep() it takes all 5seconds
            /*driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);*/
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }
        [Test]
        public void UsernameTest()
        {
            
            driver.FindElement(By.Id("username")).SendKeys("Harshithaaithal");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Harshithaaithal16");
            driver.FindElement(By.Name("password")).SendKeys("123456");

            // CssSelector
            //Tagname[atribute='value']

            /*    driver.FindElement(By.CssSelector("button[type='submit']")).Click();*/

            //checkbox
            //css-.text-info span:nth-child(1) input
            // xpath-label[@class='text-info']/span/input
            //if u have id we have to convert to css then --->#id or id=terms ==>#terms
            //classname=.class
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            //XPath
            //      //tagname[@atribute='value']
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();


            //Thread.Sleep(3000);
            //if  this takes 8 sec then we cant change it globally because performance become slow
            //in this case explicit wait is used

            //declare
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            .TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")),"Sign In"));


            String errormsg=   driver.FindElement(By.ClassName("alert")).Text;//grab the test 
            TestContext.Progress.WriteLine(errormsg);// prnt it

            //linktext
             IWebElement link=  driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
              String  hrefAttribute  = link.GetAttribute("href");

            String expectedUrl= "https://rahulshettyacademy.com/documents-request";

            Assert.AreEqual(expectedUrl, hrefAttribute);//validate url ofthe link text
        }

    }
}
