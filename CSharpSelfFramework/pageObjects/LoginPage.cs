using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelfFramework.pageObjects
{
    public  class LoginPage
    {
        // driver.FindElement(By.Id("username"))
        //By.Id("username")
        //pageobjectFactory

         // driver.FindElement(By.Name("password")).SendKeys("learning");
        //  driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
        // driver.FindElement(By.XPath("//input[@type='submit']")).Click();      
        private IWebDriver driver;
        public LoginPage(IWebDriver driver) 
        {
           this.driver = driver;
            PageFactory.InitElements(driver, this);//wherever it finds FindsBy that will initialize with driver
        }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username; //all the test class if bthey want to identiffy any username 
        //they will call this username fields
        //the username variable cant modify by using private keyword if user wants modify then call getuserName method

        [FindsBy(How =How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkbox;

        [FindsBy(How = How.CssSelector, Using = "input[type='submit']")]
        private IWebElement signInButton;
        
        public ProductsPage validLogin(string user,string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkbox.Click();
            signInButton.Click();
            return new ProductsPage(driver);

        }
       /* public IWebElement getUserName()
        {
            return username;
        }*/





    }
}
