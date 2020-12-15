using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            if (!applicationManager.Groups.IsElementPresent(By.Name("selected[]")))
            {
                applicationManager.Groups.Create(new GroupData("Test"));
            }

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.Remove(0);

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
        
    }
}
