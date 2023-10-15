using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverStudentsPOM.Pages
{
    internal class ViewStudentPage : BasePage
    {
        public ViewStudentPage(WebDriver driver) : base(driver)
        {
        }

        public override string BaseUrl =>
           "https://studentsregistry.softuniqa.repl.co/students";

        public ReadOnlyCollection<IWebElement> ListItemsStudents =>
           driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetRegisteredStudents()
        {
            var elementsStudents = this.ListItemsStudents.Select(s => s.Text).ToArray();
            return elementsStudents;
        }
    }
}
