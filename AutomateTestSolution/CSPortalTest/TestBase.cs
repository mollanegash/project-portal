using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using System.Threading;

namespace CSPortalTest
{
    class TestBase
    {
        //reference to string
        IWebDriver driver = new ChromeDriver();


        [SetUp]
        public void Initialized()
        {
         
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");
            Console.WriteLine("Open URL");
           
        }

        [Test]
        public void ValidateLogin()
        {

            //Enter Username and Paswword
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("ayumi@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("Ayumi1234*");
           
            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Login");

            //logout
            Thread.Sleep(2000);
            driver.FindElement(By.Id("loggoutButton")).Click();
            Console.WriteLine("Execute Test Logout");
        }      

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            Console.WriteLine("Closed the browser");
        }       
    }
}




 
