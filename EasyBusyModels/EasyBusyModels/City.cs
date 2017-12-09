using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class City : Base
    {
        private String name;

        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}
