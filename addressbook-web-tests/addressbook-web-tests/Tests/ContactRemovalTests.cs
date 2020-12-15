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
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!applicationManager.Contacts.IsElementPresent(By.Name("selected[]")))
            {
                applicationManager.Contacts.Create(new ContactData("Test", "Test"));
            }

            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.Remove(0);

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
