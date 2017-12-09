using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class ClientList : List<Client>
    {
        public ClientList() { }

        public ClientList(IEnumerable<Client> list) : base (list) { }

        public ClientList(IEnumerable<Base> list) : base(list.Cast<Client>().ToList()) { }
    }
}
