﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Ivan", "Ivanov");
            if (!applicationManager.Contacts.IsElementPresent(By.Name("selected[]")))
            {
                applicationManager.Contacts.Create(new ContactData("Test", "Test"));
            }

            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.Modify(0, newData);

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
