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
        private String birthday;
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
        {
            get => password;
            set => password = value;
        }

        private DateTime StringToDateTime()
        {
            String[] toDateTime = birthday.Split('/');
            int[] dmy = new int[toDateTime.Length];
            for (int i = 0; i < toDateTime.Length; i++)
                dmy[i] = int.Parse(toDateTime[i]);
            return new DateTime(dmy[2], dmy[0], dmy[1]);
        }
        public DateTime Birthday
        {
            get => StringToDateTime();
            set => birthday = value.ToShortDateString();
        }

        public string BirthdayByString
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
