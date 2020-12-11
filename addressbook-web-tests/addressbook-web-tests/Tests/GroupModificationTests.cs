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
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            if (!applicationManager.Groups.IsElementPresent(By.Name("selected[]")))
            {
                applicationManager.Groups.Create(new GroupData("Test"));
            }

                applicationManager.Groups.Modify(1, newData);
        }
    }
}
