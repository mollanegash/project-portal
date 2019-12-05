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
    class Register:TestBase
    {
        [Test]
        public void CreateStudentTest()
        {
            //open url
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/registeration.aspx");

            //Enter student details
            driver.FindElement(By.Id("firstnameTextBox")).SendKeys("AutoTest Fname");
            driver.FindElement(By.Id("lastNameTextBox")).SendKeys("AutoTest Lname");
            driver.FindElement(By.Id("schoolTextBox")).SendKeys("AutoTest SchoolName");
            driver.FindElement(By.Id("DropDownList1")).SendKeys("Student");
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("#AutoTestStudent@bu.edu");
            driver.FindElement(By.Id("passwordTextBox")).SendKeys("#AutoTestPassword");
            driver.FindElement(By.Id("confirmPasswordTextBox")).SendKeys("#AutoTestPassword");


            //click to enter into the system
            driver.FindElement(By.Id("registerButton")).Click();
            Console.WriteLine("Execute Student Registeration");

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

        }


        // Create new faculty account
        [Test]
        public void CreateFacultyTest()
        {
            //open url
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/registeration.aspx");

            //Enter faculty details
            driver.FindElement(By.Id("firstnameTextBox")).SendKeys("AutoTest Fname");
            driver.FindElement(By.Id("lastNameTextBox")).SendKeys("AutoTest Lname");
            driver.FindElement(By.Id("schoolTextBox")).SendKeys("AutoTest SchoolName");
            driver.FindElement(By.Id("DropDownList1")).SendKeys("Faculty");
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("#AutoTestFaculty@bu.edu");
            driver.FindElement(By.Id("passwordTextBox")).SendKeys("#AutoTestPassword");
            driver.FindElement(By.Id("confirmPasswordTextBox")).SendKeys("#AutoTestPassword");


            //click to enter into the system
            driver.FindElement(By.Id("registerButton")).Click();
            Console.WriteLine("Execute register faculty Registeration");

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max

        }
        [Test]
        public void PasswordNotMatch()
        {
            //open url
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/registeration.aspx");

            //Enter student details
            driver.FindElement(By.Id("firstnameTextBox")).SendKeys("FailAutoTestFname");
            driver.FindElement(By.Id("lastNameTextBox")).SendKeys("FailAutoTestLname");
            driver.FindElement(By.Id("schoolTextBox")).SendKeys("FailAutoTestSchoolName");
            driver.FindElement(By.Id("DropDownList1")).SendKeys("Student");
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("FailAutoTestStudent@bu.edu");
            driver.FindElement(By.Id("passwordTextBox")).SendKeys("AutoTestPassword");
            driver.FindElement(By.Id("confirmPasswordTextBox")).SendKeys("AutoTestPassword2");

            //click to enter into the system
            driver.FindElement(By.Id("registerButton")).Click();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // set locatorTimeout to be 20 secound at max
        }
    }
}
    