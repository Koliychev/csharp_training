﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected ProjectManagementHelper projectManagementHelper;
        protected ManagementMenuHelper managementMenuHelper;

        public RegistrationHelper Registration { get; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            baseURL = "http://localhost/mantisbt-2.24.4";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);

            loginHelper = new LoginHelper(this);
            projectManagementHelper = new ProjectManagementHelper(this);
            managementMenuHelper = new ManagementMenuHelper(this, baseURL);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }
        
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.24.4/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver 
        {
            get
            {
                return driver;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public ProjectManagementHelper Projects
        {
            get
            {
                return projectManagementHelper;
            }
        }

        public ManagementMenuHelper Menu
        {
            get
            {
                return managementMenuHelper;
            }
        }
    }
}
