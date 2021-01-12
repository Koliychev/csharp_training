﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEMails;
        private string allInfo;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "firstname= " + Firstname + "\nlastname = " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int result = Lastname.CompareTo(other.Lastname);
            if (result == 0)
            {
                result = Firstname.CompareTo(other.Firstname);
            }

            return result;
        }

        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }
        public string New_group { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }
        public string Id { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return Regex.Replace(allPhones, "\r\n", "");
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEMails
        {
            get
            {
                if (allEMails != null)
                {
                    return Regex.Replace(allEMails, "\r\n", "");
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEMails = value;
            }
        }

        public string AllInfo
        {
            get
            {
                allInfo = "";

                if (Firstname != null && Firstname != "")
                {
                    allInfo += Firstname;
                }

                if (allInfo == Firstname && Lastname != null && Lastname != "")
                {
                    allInfo += " ";
                }

                if (Lastname != null && Lastname != "")
                {
                    allInfo += Lastname;
                }

                if (Firstname != null && Firstname != "" || Lastname != null && Lastname != "")
                {
                    allInfo += "\r\n\r\n";
                }

                if (Home != null && Home != "")
                {
                    allInfo += "H: " + Home + "\r\n";
                }

                if (Mobile != null && Mobile != "")
                {
                    allInfo += "M: " + Mobile + "\r\n";
                }

                if (Work != null && Work != "")
                {
                    allInfo += "W: " + Work + "\r\n";
                }

                if (Home != null && Home != "" || Mobile != null && Mobile != "" || Work != null && Work != "")
                {
                    allInfo += "\r\n";
                }

                if (Email != null && Email != "")
                {
                    allInfo += Email + "\r\n";
                }

                if (Email2 != null && Email2 != "")
                {
                    allInfo += Email2 + "\r\n";
                }

                if (Email3 != null && Email3 != "")
                {
                    allInfo += Email3 + "\r\n";
                }

                return allInfo.Trim();
            }
            set
            {
                allInfo = value;
            }
        }

        private string CleanUp(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return Regex.Replace(data, "[ -()]", "");
        }

    }
}
