using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]

        public void SearchTest()
        {
            System.Console.Out.Write(applicationManager.Contacts.GetNumberOfSearchResults());
        }

    }
}
