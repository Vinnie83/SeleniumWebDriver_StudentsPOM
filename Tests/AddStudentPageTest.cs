using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverStudentsPOM.Pages;

namespace WebDriverStudentsPOM.Tests
{
    public class AddStudentPageTest : BaseTest

    {
        [Test]
        public void Test_TestAddStudentPage_Content()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            Assert.That(page.GetPageTitle,Is.EqualTo("Add Student"));
            Assert.That(page.GetPageHeadingText, Is.EqualTo("Register New Student"));
            Assert.That(page.FieldName.Text, Is.EqualTo(""));
            Assert.That(page.FieldEmail.Text, Is.EqualTo(""));
            Assert.That(page.ButtonSubmit.Text, Is.EqualTo("Add"));
        }

        [Test]
        public void Test_TestAddStudentPage_Links()
        {
            var addStudentPage = new AddStudentPage(driver);

            addStudentPage.Open();
            addStudentPage.HomeLink.Click();
            Assert.IsTrue(new HomePage(driver).IsPageOpen());

            addStudentPage.Open();
            addStudentPage.AddStudentLink.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsPageOpen());

            addStudentPage.Open();
            addStudentPage.ViewStudentLink.Click();
            Assert.IsTrue(new ViewStudentPage(driver).IsPageOpen());
        }

        [Test]
        public void Test_TestAddStudentPage_AddValidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            string name = "Maria" + DateTime.Now.Ticks;
            string email = "maria" + DateTime.Now.Ticks + "@gmail.com";
            page.AddStudent(name, email);
            var viewStudentsPage = new ViewStudentPage(driver);
            Assert.IsTrue(viewStudentsPage.IsPageOpen());
            var students = viewStudentsPage.GetRegisteredStudents();
            string newStudent = name + " (" + email + ")";
            Assert.Contains(newStudent, students);
        }

        [Test]
        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            string name = "";
            string email = "pesho" + DateTime.Now.Ticks + "@gmail.com";
            page.AddStudent(name, email);
            Assert.IsTrue(page.IsPageOpen());
            Assert.IsTrue(page.ElementErrorMsg.Text.Contains("Cannot add student"));
        }



    }
}
