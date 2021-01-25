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
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("td > a"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.Text));
            }

            return projects;
        }

        public ProjectManagementHelper Remove(int p)
        {
            manager.Menu.GoToManageProjectPage();
            SelectProject();
            RemoveProject();
            manager.Menu.GoToManageProjectPage();
            return this;
        }

        private ProjectManagementHelper RemoveProject()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-sm.btn-white.btn-round")).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            return this;
        }

        private ProjectManagementHelper SelectProject()
        {
            driver.FindElement(By.CssSelector("td > a")).Click();
            return this;
        }

        public int GetProjectsCount()
        {
            return GetProjectsList().Count;
        }

        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.Menu.GoToAddProjectPage();
            FillProjectForm(project);
            SubmitProjectCreation();
            manager.Menu.GoToManageProjectPage();
            return this;
        }

        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
            return this;
        }

        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            return this;
        }
    }
}
