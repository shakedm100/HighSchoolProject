using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class Worker : People
    {
        private String bankAccount;
        private double rating;
        private int jobType;
        private double longtitude;
        private double latitude;

        public string BankAccount
        {
            get => bankAccount;
            set => bankAccount = value;
        }
        public double Rating
        {
            get => rating;
            set => rating = value;
        }
        public int JobType
        {
            get => jobType;
            set => jobType = value;
        }
        public double Longtitude
        {
            get => longtitude;
            set => longtitude = value;
        }
        public double Latitude
        {
            get => latitude;
            set => latitude = value;
        }
    }
}
