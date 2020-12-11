using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;


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

            applicationManager.Groups.Remove(1);
        }
        
    }
}
