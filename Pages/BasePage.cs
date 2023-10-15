using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverStudentsPOM.Pages
{
    public class BasePage
    {
        protected readonly WebDriver driver;

            public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }

        public virtual string BaseUrl { get; }

        public IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));    

        public IWebElement ViewStudentLink => driver.FindElement(By.LinkText("View Students"));    
        public IWebElement AddStudentLink => driver.FindElement(By.LinkText("Add Student"));    

        public IWebElement ElementPageHeading =>
            driver.FindElement(By.CssSelector("body > h1"));

        public void Open()
        {
            driver.Navigate().GoToUrl(BaseUrl); 
        }

        public string GetPageTitle() 
        {
            return driver.Title;

        }

        public string GetPageHeadingText()
        {
            return ElementPageHeading.Text;
        }

        public bool IsPageOpen()
        {
            return driver.Url == BaseUrl;    
        }
    }
}
