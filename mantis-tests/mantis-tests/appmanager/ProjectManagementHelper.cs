using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Menu.GoToManageProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tbody.tr.td.a"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.Text));
            }

            return projects;
        }

        internal int GetProjectsCount()
        {
            return GetProjectsList().Count;
        }

        internal ProjectManagementHelper Create(ProjectData project)
        {
            manager.Menu.GoToManageProjectPage();
            manager.Menu.GoToAddProjectPage();
            FillProjectForm(project);
            SubmitProjectCreation();
            manager.Menu.GoToManageProjectPage();
            return this;
        }

        private ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        private ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            return this;
        }
    }
}
