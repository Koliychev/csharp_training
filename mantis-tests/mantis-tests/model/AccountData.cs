using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class AccountData
    {
        private string name;
        private string password;

        public AccountData(string username, string password)
        {
            this.name = username;
            this.password = password;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
