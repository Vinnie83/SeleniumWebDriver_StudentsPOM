using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverStudentsPOM.Pages;

namespace WebDriverStudentsPOM.Tests
{
    public class ViewStudentPageTest : BaseTest
    {
        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            var page = new ViewStudentPage(driver);
            page.Open();
            Assert.That( page.GetPageTitle, Is.EqualTo("Students"));
            Assert.That(page.GetPageHeadingText, Is.EqualTo("Registered Students"));

            var students = page.GetRegisteredStudents();
            foreach (string st in students)
            {
                Assert.IsTrue(st.IndexOf("(") > 0);
                Assert.IsTrue(st.LastIndexOf(")") == st.Length - 1);
            }
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            var viewStudentsPage = new ViewStudentPage(driver);

            viewStudentsPage.Open();
            viewStudentsPage.HomeLink.Click();
            Assert.IsTrue(new HomePage(driver).IsPageOpen());

            viewStudentsPage.Open();
            viewStudentsPage.AddStudentLink.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsPageOpen());

            viewStudentsPage.Open();
            viewStudentsPage.ViewStudentLink.Click();
            Assert.IsTrue(new ViewStudentPage(driver).IsPageOpen());
        }
    }
}
