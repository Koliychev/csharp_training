﻿using System;
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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNewPage();
            ContactData contact = new ContactData("Arthur", "Kolychev");
            FillContactForm(contact);
            SubmitContactCreation();
            Logout();
        }
        
    }
}
