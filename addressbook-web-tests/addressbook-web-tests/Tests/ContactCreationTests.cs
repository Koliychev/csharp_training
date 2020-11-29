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
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
            applicationManager.Navigator.GoToAddNewPage();
            ContactData contact = new ContactData("Arthur", "Kolychev");
            applicationManager.Contacts.FillContactForm(contact);
            applicationManager.Contacts.SubmitContactCreation();
            applicationManager.Auth.Logout();
        }
        
    }
}
