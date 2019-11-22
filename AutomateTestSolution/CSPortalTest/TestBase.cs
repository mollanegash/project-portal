using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace CSPortalTest
{
    class TestBase
    {
        [Test]
        static void Main(string[] args)
        {
            //open login-/index page
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");
            Console.WriteLine("Opening" + driver.Url);

            //start with a valid user
            ValidateLogin(driver);
            LogoutTest(driver);
            InvalidateLogin(driver);
            
        }


        [Test]
        static void ValidateLogin(IWebDriver driver)
        {

            //Enter Username and Paswword
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("ayumi@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("Ayumi1234*");
            Console.Write("Enter UN and PWD");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.Write("Clicked Login Button");

            driver.Manage().Window.Maximize(); // maximizer Browser
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

            /*IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine("Validate Alert Text");

            //validate when the login success
            Assert.Pass(alert.Text, Does.Match("SUCCESS"));
            Assert.Equals(alert.Text, "SUCCESS");*/
        }

        [Test]
        static void LogoutTest(IWebDriver driver)
        {
            driver.FindElement(By.Id("logOutButton")).Click();
            driver.FindElement(By.Id("logOutButton")).Click();
            driver.Manage().Window.Maximize(); // maximizer Browser
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max
        }

        [Test]
        static void InvalidateLogin(IWebDriver driver)
        {
            //Enter Username and Paswword
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("miyabi@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("miya1234*");
            Console.Write("Enter UN and PWD");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.Write("Clicked Login Button");

            driver.Manage().Window.Maximize(); // maximizer Browser
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

            /*IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine("Validate Alert Text");

            //validate when the login success
            Assert.That(alert.Text, Does.Match("SUCCESS"));
            Assert.Equals(alert.Text, "SUCCESS");*/
        }
    }
}




 
