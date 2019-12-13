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
        protected IWebDriver driver;


        [SetUp]
        public void Initialized()
        {
            driver = new ChromeDriver();
            Console.WriteLine("Open URL");
           
        }

       
        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            Console.WriteLine("Closed the browser");
        }       
    }
}




 
