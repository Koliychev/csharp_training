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
    public class ContactInformationTests : AuthTestBase
    {
        [Test]

    public void ContactInformationTest()
        {
            ContactData fromTable = applicationManager.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = applicationManager.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEMails, fromForm.AllEMails);
        }

        [Test]

        public void ContactDetailInformationTest()
        {
            string fromDetailForm = applicationManager.Contacts.GetContactInformationFromDetailForm(0);
            ContactData fromForm = applicationManager.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromDetailForm, fromForm.AllInfo);
        }
    }
}
