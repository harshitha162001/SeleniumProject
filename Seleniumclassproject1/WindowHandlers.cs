using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Reflection.Metadata;

namespace Seleniumclassproject1
{
    public class WindowHandlers
    {
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
        public void WindowHandle()
        {
            string email = "mentor@rahulshettyacademy.com";
            String parentWindowId = driver.CurrentWindowHandle;
            driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2, driver.WindowHandles.Count);//perent and child
            String childWindowName = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindowName);
          TestContext.Progress.WriteLine(  driver.FindElement(By.CssSelector(".red")).Text);
            String text = driver.FindElement(By.CssSelector(".red")).Text;
            //please email us at mentor@rahulshettyacedamy.com with below templete to 
            String[] spittedTest = text.Split("at");
            // mentor@rahulshettyacedamy.com with below templete to
            //remove first space then split
            String[] trimmedString = spittedTest[1].Trim().Split(" ");
            Assert.AreEqual(email, trimmedString[0]);
            driver.SwitchTo().Window(parentWindowId);
            driver.FindElement(By.Id("username")).SendKeys(trimmedString[0]);


        }
    }
}
