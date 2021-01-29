using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : ProjectTestBase
    {
        public static IEnumerable<ProjectData> RandomProjectDataProvider()
        {
            List<ProjectData> projects = new List<ProjectData>();
            for (int i = 0; i < 1; i++)
            {
                projects.Add(new ProjectData(GenerateRandomString(10)));
            }
            return projects;
        }

        [Test, TestCaseSource("RandomProjectDataProvider")]
        public void ProjectCreationTest(ProjectData project)
        {
            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            app.Projects.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectsCount());

            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test, TestCaseSource("RandomProjectDataProvider")]
        public void APIProjectCreationTest(ProjectData project)
        {            
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            
            var oldProjects = app.API.GetProjectList(account);
            var oldProjectsData = new List<ProjectData>();
            foreach (var proj in oldProjects)
            {
                oldProjectsData.Add(new ProjectData(proj.name)
                {
                    Id = proj.id
                }); 
            }

            project.Id = app.API.CreateNewProject(account, project);

            Assert.AreEqual(oldProjects.Count() + 1, app.API.GetProjectList(account).Count());
            
            var newProjects = app.API.GetProjectList(account);
            var newProjectsData = new List<ProjectData>();
            foreach (var proj in newProjects)
            {
                newProjectsData.Add(new ProjectData(proj.name)
                {
                    Id = proj.id
                });
            }

            oldProjectsData.Add(project);
            oldProjectsData.Sort();
            newProjectsData.Sort();
            Assert.AreEqual(oldProjectsData, newProjectsData);            
        }
    }
}
