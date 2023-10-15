using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverStudentsPOM.Pages
{
    public class HomePage : BasePage
    {
        private WebDriver driver;  
        public HomePage(WebDriver driver) : base(driver)
        {
        }
        public override string BaseUrl =>
            "https://studentsregistry.softuniqa.repl.co/";

        public IWebElement ElementStudentsCount =>
            driver.FindElement(By.CssSelector("body > p > b"));

        public int GetStudentsCount()
        {
            string studentsCountText = this.ElementStudentsCount.Text;
            return int.Parse(studentsCountText);
        }
    }
}
