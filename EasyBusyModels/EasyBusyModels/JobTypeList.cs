using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class JobTypeList : List<JobType>
    {
        public JobTypeList() { }

        public JobTypeList(IEnumerable<JobType> list) : base (list) { }

        public JobTypeList(IEnumerable<Base> list) : base(list.Cast<JobType>().ToList()) { }
    }
}
