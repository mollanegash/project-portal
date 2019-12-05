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
    class SearchProject:TestBase
    {
        // Project List find a Project Name
        [Test]
        public void FindProjectTestName()
        {
            //open page
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/ProjectList.aspx");

            //Enter project details
            driver.FindElement(By.Id("DropDownList1")).SendKeys("Project Name");
            driver.FindElement(By.Id("TextBox1")).SendKeys("AutoTest Pname");


            //click to enter into the system

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

        }


        // Project List find a Project Author
        [Test]
        public void FindProjectTestAuthor()
        {
            
            //open page
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/ProjectList.aspx");

            //Enter project details
            driver.FindElement(By.Id("DropDownList1")).SendKeys("Author Name");
            driver.FindElement(By.Id("TextBox1")).SendKeys("AutoTest Fname");


            //click to enter into the system

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

        }


        // Add Comment
        [Test]
        public void AddCommentTest()
        {
            //open page
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/ProjectList.aspx");

            //click view project
            driver.FindElement(By.Id("EmpGridView_EditButton1_5")).Click();

            //Enter name
            driver.FindElement(By.Id("TextName")).SendKeys("Testing Zue");

            //Enter commnet details
            driver.FindElement(By.Id("TextComment")).SendKeys("Testing comment feature");

            //click to enter into the system
            driver.FindElement(By.Id("Comment")).Click();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

        }

        // Project List find a Project tag
        [Test]
        public void findProjectTestTag()
        {
            //open page
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/ProjectList.aspx");

            //Enter project details
            driver.FindElement(By.Id("DropDownList1")).SendKeys("Project Tag");
            driver.FindElement(By.Id("TextBox1")).SendKeys("#AutoTest");

            //click to enter into the system
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max
        }
        // Project List find a Project ID
        [Test]
        public void FindProjectTestTag()
        {
            //open page
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/ProjectList.aspx");

            //Enter project details
            driver.FindElement(By.Id("DropDownList1")).SendKeys("Project ID");
            driver.FindElement(By.Id("TextBox1")).SendKeys("#8");

            //click to enter into the system
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max
        }
        
    }
}

