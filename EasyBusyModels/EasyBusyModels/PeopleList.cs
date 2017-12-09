using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class PeopleList : List<People>
    {
        public PeopleList() { }

        public PeopleList(IEnumerable<People> list) : base (list) { }

        public PeopleList(IEnumerable<Base> list) : base(list.Cast<People>().ToList()) { }
    }
}
