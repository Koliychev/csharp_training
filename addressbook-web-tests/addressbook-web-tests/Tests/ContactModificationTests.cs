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
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Ivan", "Ivanov");
            if (!applicationManager.Contacts.IsElementPresent(By.Name("selected[]")))
            {
                applicationManager.Contacts.Create(new ContactData("Test", "Test"));
            }

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData oldData = oldContacts[0];
            applicationManager.Contacts.Modify(oldData, newData);

            Assert.AreEqual(oldContacts.Count, applicationManager.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldData.Firstname = newData.Firstname;
            oldData.Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }
    }
}
