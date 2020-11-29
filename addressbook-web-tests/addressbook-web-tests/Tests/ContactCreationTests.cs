using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            applicationManager.Navigator.GoToAddNewPage();
            ContactData contact = new ContactData("Arthur", "Kolychev");
            applicationManager.Contacts.FillContactForm(contact);
            applicationManager.Contacts.SubmitContactCreation();
        }
        
    }
}
