using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            applicationManager.Navigator.GoToGroupsPage();
            applicationManager.Groups.InitNewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "sss";
            group.Footer = "ddd";
            applicationManager.Groups.FillGroupForm(group);
            applicationManager.Groups.SubmitGroupCreation();
            applicationManager.Navigator.ReturnToGroupsPage();
            applicationManager.Auth.Logout();
        }
                
    }
}
