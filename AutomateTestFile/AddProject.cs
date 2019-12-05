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
    class AddProject:TestBase
    {
        // Add new project
        [Test]
        public void AddNewProjectTest()
        {
            //Student Login
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");
            //Enter Username and Paswword
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("ratti@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("Ratti1234*");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Login");

            //navigate add project tab
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/AddProject.aspx");

            //Enter project details
            driver.FindElement(By.Id("ProjectNameBox")).SendKeys("AutoTest Pname");
            driver.FindElement(By.Id("projectDesBox")).SendKeys("AutoTest P Desc.");
            driver.FindElement(By.Id("LinkBox")).SendKeys("AutoTest www.testProject.com");
            driver.FindElement(By.Id("uploadBox")).SendKeys("12/02/2019");
            driver.FindElement(By.Id("projectTagBox")).SendKeys("#AutoTest");

            //click to enter into the system
            driver.FindElement(By.Id("sumbit")).Click();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max
        }
    }
}
