using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
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

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string Home { get; set; }

        [Column(Name = "mobile")]
        public string Mobile { get; set; }

        [Column(Name = "work")]
        public string Work { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string Bday { get; set; }

        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }

        [Column(Name = "byear")]
        public string Byear { get; set; }

        [Column(Name = "aday")]
        public string Aday { get; set; }

        [Column(Name = "amonth")]
        public string Amonth { get; set; }

        [Column(Name = "ayear")]
        public string Ayear { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
        }

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
