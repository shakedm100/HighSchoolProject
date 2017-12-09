using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class People : Base
    {
        private String firstName;
        private String lastName;
        private String username;
        private String password;
        private DateTime birthday;
        private Kidomet kidomet;
        private String phoneNumber;
        private String taz;
        private City city;

        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }
        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }
        public string Username
        {
            get => username;
            set => username = value;
        }
        public string Password
        { get => password;
            set => password = value;
        }
        public DateTime Birthday
        {
            get => birthday;
            set => birthday = value;
        }
        public Kidomet Kidomet
        {
            get => kidomet;
            set => kidomet = value;
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set => phoneNumber = value;
        }
        public string Taz
        {
            get => taz;
            set => taz = value;
        }
        public City GetSetCity
        {
            get => city;
            set => city = value;
        }
    }
}
