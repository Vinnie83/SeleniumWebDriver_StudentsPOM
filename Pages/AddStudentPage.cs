using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverStudentsPOM.Pages
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(WebDriver driver) : base(driver)
        {
        }

        public override string BaseUrl =>
            "https://studentsregistry.softuniqa.repl.co/add-student";

        public IWebElement FieldName =>
            driver.FindElement(By.CssSelector("input#name"));

        public IWebElement FieldEmail =>
            driver.FindElement(By.CssSelector("input#email"));

        public IWebElement ButtonSubmit =>
            driver.FindElement(By.CssSelector("button[type='submit']"));

        public IWebElement ElementErrorMsg =>
            driver.FindElement(By.XPath("//div[contains(@style,'background:red')]"));

        public void AddStudent(string name, string email)
        {
            this.FieldName.SendKeys(name);
            this.FieldEmail.SendKeys(email);
            this.ButtonSubmit.Click();
        }
    }
}
