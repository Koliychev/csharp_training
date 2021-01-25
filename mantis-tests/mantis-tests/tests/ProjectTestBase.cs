using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class ProjectTestBase : AuthTestBase
    {
        [TestFixtureTearDown]

        public void Logout()
        {
            app.Auth.Logout();
        }
    }
}