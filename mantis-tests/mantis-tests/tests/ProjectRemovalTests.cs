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
    }
}
