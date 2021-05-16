using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    class User
    {
        private string name { get; set; }
        private string surname { get; set; }
        private string address { get; set; }
        private readonly string uid;
        private static int uidSeed = 987654321;

        public User(string name, string surname, string address)
        {
            this.name = name;
            this.surname = surname;
            this.address = address;
            uid = uidSeed.ToString();
            uidSeed--;
        }

        public string getUid()
        {
            return this.uid;
        }

    }
}
