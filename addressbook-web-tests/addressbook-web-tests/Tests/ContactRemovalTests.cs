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
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!applicationManager.Contacts.IsElementPresent(By.Name("selected[]")))
            {
                applicationManager.Contacts.Create(new ContactData("Test", "Test"));
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            applicationManager.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, applicationManager.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
                        
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
