using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Drawing;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace Seleniumclassproject1
{
    public  class SeleniumTest1
    {

        /*[Test]
        public void SimpleTest()
        {
          
            
            
            var driver = new FirefoxDriver();
            driver.Manage().Window.Size = new Size(1134, 824);
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");

            *//* Thread.Sleep(5000);
             driver.FindElement(By.Id("Register")).Click();*/
        /* driver.Quit();*//*

     }*/
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            //geckodriver for firefoxdriver
            //chromedriver.exe selenium sends all commands to chromedriver.exe and
            //this will pass those cmds and perform action on chromebrowser
            //99  .exe(99) 
            //to overcome this problem introdruced WebDriverManager -(
            
            //WebDriverManager is the namespace
             // DriverManager is classname and setupDriver is the method 
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            // driver = new FirefoxDriver();
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Test1()
        {
            driver.Url = "https://www.youtube.com/";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
           // driver.PageSource
           // driver.Close();//1 window will be closed
            //driver.Quit();//both window will be closed
        }
    }
}
