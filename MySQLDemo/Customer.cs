using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLDemo
{
    class Customer
    {
        private long ID;
        private String name;
        private String address;
        private String email;

        public Customer(long ID, String name, String address, String email)
        {
            this.ID = ID;
            this.name = name;
            this.address = address;
            this.email = email;
        }

        public long getID()
        {
            return ID;
        }

        public String getName()
        {
            return name;
        }

        public String getAddress()
        {
            return address;
        }

        public String getEmail()
        {
            return email;
        }
    }
}
