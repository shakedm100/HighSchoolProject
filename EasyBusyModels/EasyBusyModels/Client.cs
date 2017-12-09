using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class Client : People
    {
        private String address;
        private String creditcardNumber;

        public string Address
        {
            get => address;
            set => address = value;
        }
        public string CreditcardNumber
        {
            get => creditcardNumber;
            set => creditcardNumber = value;
        }
    }
}
