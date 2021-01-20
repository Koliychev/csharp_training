using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            var allGroups = GroupData.GetAll();
            if (!allGroups.Any())
            {
                applicationManager.Groups.Create(new GroupData("test"));
                allGroups = GroupData.GetAll();
            }
            GroupData group = allGroups[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList.FirstOrDefault();
            if (contact == null)
            {
                applicationManager.Contacts.Create(new ContactData("test", "test"));
                contact = ContactData.GetAll().Except(oldList).First();
                applicationManager.Contacts.AddContactToGroup(contact, group);
                oldList.Add(contact);
            }

            applicationManager.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}