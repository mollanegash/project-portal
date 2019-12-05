using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using System.Threading;
using CSPortalTest;

namespace automateTest
{
    class Login: TestBase
    {
        [Test]
        public void ValidateLogin()
        {
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");
            //Enter Username and Paswword
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("ayumi@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("Ayumi1234*");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Login");


            Thread.Sleep(2000);
            driver.FindElement(By.Id("loggoutButton")).Click();
            Console.WriteLine("Execute Test Logout");

        }

        [Test]
        public void StudentLogin()
        {
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");
            //Enter Username and Paswword
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("ratti@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("Ratti1234*");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Login");

        }

        [Test]
        public void FacultyLogin()
        {
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");
            //Enter Username and Paswword
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("Natalia12@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("Natalia1234*");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Login");

        }

        [Test]
        public void InvalidateLogin_ClassA_OnlyChar()
        {
            //open the web page
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");

            //Enter Username and Paswword missing the special character
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("ayumi@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("Ayumi");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Login");


            Thread.Sleep(2000);
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Logout");

        }

        [Test]
        public void InvalidateLogin_ClassB_OnlyNumber()
        {
            //open the web page
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");

            //Enter Username and Paswword missing the special character
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("ayumi@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("1234");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Login");


            Thread.Sleep(2000);
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Logout");

        }

    }
}
