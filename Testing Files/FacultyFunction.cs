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
    class FacultyFunction:TestBase
    {
       [Test]
        public void ViewStudentProject()
        {
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");
            //Enter Username and Paswword
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("Natalia12@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("Natalia1234*");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Login");

            //Click view 
            driver.FindElement(By.Id("EmpGridView_ButtonClick1_7")).Click();         

        }

        [Test]
        public void DeleteSupervisee()
        {
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/");
            //Enter Username and Paswword
            driver.FindElement(By.Id("usernameTextBox")).SendKeys("Natalia12@bu.edu");
            driver.FindElement(By.Id("passwordTextBos")).SendKeys("Natalia1234*");

            //click to enter into the system
            driver.FindElement(By.Id("submitButton")).Click();
            Console.WriteLine("Execute Test Login");

            //click view my supervisee
            driver.Navigate().GoToUrl("http://www.computerscienceprojectportal.com/StudentList.aspx");

            //Click view 
            driver.FindElement(By.Id("EmpGridView_ButtonClick1_6")).Click();

        }
    }
}
    
