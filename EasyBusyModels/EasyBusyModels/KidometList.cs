using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class KidometList : List<Kidomet>
    {
        public KidometList() { }

        public KidometList(IEnumerable<Kidomet> list) : base (list) { }

        public KidometList(IEnumerable<Base> list) : base(list.Cast<Kidomet>().ToList()) { }
    }
}
