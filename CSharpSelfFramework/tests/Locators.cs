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
using CSharpSelfFramework.utilities;

namespace Seleniumclassproject1
{
    [Parallelizable(ParallelScope.Self)]
    public class Locators:Base
    {
        //selenium supports locators like Xpath,css,id,classname,name,tagname,LinkText

       
        [Test]
        public void UsernameTest()
        {
            
            driver.Value.FindElement(By.Id("username")).SendKeys("Harshithaaithal");
            driver.Value.FindElement(By.Id("username")).Clear();
            driver.Value.FindElement(By.Id("username")).SendKeys("Harshithaaithal16");
            driver.Value.FindElement(By.Name("password")).SendKeys("123456");

            // CssSelector
            //Tagname[atribute='value']

            /*    driver.FindElement(By.CssSelector("button[type='submit']")).Click();*/

            //checkbox
            //css-.text-info span:nth-child(1) input
            // xpath-label[@class='text-info']/span/input
            //if u have id we have to convert to css then --->#id or id=terms ==>#terms
            //classname=.class
            driver.Value.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            //XPath
            //      //tagname[@atribute='value']
            driver.Value.FindElement(By.XPath("//input[@type='submit']")).Click();


            //Thread.Sleep(3000);
            //if  this takes 8 sec then we cant change it globally because performance become slow
            //in this case explicit wait is used

            //declare
            WebDriverWait wait = new WebDriverWait(driver.Value,TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            .TextToBePresentInElementValue(driver.Value.FindElement(By.Id("signInBtn")),"Sign In"));


            String errormsg=   driver.Value.FindElement(By.ClassName("alert")).Text;//grab the test 
            TestContext.Progress.WriteLine(errormsg);// prnt it

            //linktext
             IWebElement link=  driver.Value.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
              String  hrefAttribute  = link.GetAttribute("href");

            String expectedUrl= "https://rahulshettyacademy.com/documents-request";

            Assert.AreEqual(expectedUrl, hrefAttribute);//validate url ofthe link text
        }

    }
}
