using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class JobType : Base
    {
        private String job;

        public String Job
        {
            get => job;
            set => job = value;
        }
    }
}
