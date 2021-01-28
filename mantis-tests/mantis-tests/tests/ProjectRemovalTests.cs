﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : ProjectTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            var oldProjects = app.Projects.GetProjectsList();
            if (!oldProjects.Any())
            {
                app.Projects.Create(new ProjectData("test"));
                oldProjects = app.Projects.GetProjectsList();
            }
            
            ProjectData toBeRemoved = oldProjects[0];

            app.Projects.Remove(0);

            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectsCount());

            List<ProjectData> newProjects = app.Projects.GetProjectsList();

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void APIProjectRemovalTest()
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            
            var oldProjects = client.mc_projects_get_user_accessible(account.Name, account.Password).ToList();
            if (!oldProjects.Any())
            {
                app.API.CreateNewProject(account, new ProjectData("test"));
                oldProjects = client.mc_projects_get_user_accessible(account.Name, account.Password).ToList();
            }

            Mantis.ProjectData projectToRemove = oldProjects[0];

            app.API.DeleteProject(account, projectToRemove);                
            
            var oldProjectsData = new List<ProjectData>();
            foreach (var proj in oldProjects)
            {
                oldProjectsData.Add(new ProjectData(proj.name)
                {
                    Id = proj.id
                });
            }

            Assert.AreEqual(oldProjects.Count() - 1, client.mc_projects_get_user_accessible(account.Name, account.Password).Count());

            var newProjects = client.mc_projects_get_user_accessible(account.Name, account.Password).ToList();
            var newProjectsData = new List<ProjectData>();
            foreach (var proj in newProjects)
            {
                newProjectsData.Add(new ProjectData(proj.name)
                {
                    Id = proj.id
                });
            }

            oldProjectsData.RemoveAt(0);
            oldProjectsData.Sort();
            newProjectsData.Sort();
            Assert.AreEqual(oldProjectsData, newProjectsData);

        }
    }
}
