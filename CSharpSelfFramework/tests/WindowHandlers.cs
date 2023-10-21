using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Reflection.Metadata;
using CSharpSelfFramework.utilities;

namespace Seleniumclassproject1
{
    [Parallelizable(ParallelScope.Self)]
    public class WindowHandlers:Base
    {
       
        [Test]
        public void WindowHandlee()
        {
            string email = "mentor@rahulshettyacademy.com";
            String parentWindowId = driver.Value.CurrentWindowHandle;
            driver.Value.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2, driver.Value.WindowHandles.Count);//perent and child
            String childWindowName = driver.Value.WindowHandles[1];
           
            driver.Value.SwitchTo().Window(childWindowName);
            Thread.Sleep(8000);
          TestContext.Progress.WriteLine(driver.Value.FindElement(By.CssSelector(".red")).Text);
            String text = driver.Value.FindElement(By.CssSelector(".red")).Text;
            //please email us at mentor@rahulshettyacedamy.com with below templete to 
            String[] spittedTest = text.Split("at");
            // mentor@rahulshettyacedamy.com with below templete to
            //remove first space then split
            String[] trimmedString = spittedTest[1].Trim().Split(" ");
            Assert.AreEqual(email, trimmedString[0]);
            driver.Value.SwitchTo().Window(parentWindowId);
            driver.Value.FindElement(By.Id("username")).SendKeys(trimmedString[0]);


        }
    }
}
