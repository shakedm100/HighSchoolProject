using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class Kidomet : Base
    {
        private String areaCode;

        public string AreaCode
        {
            get => areaCode;
            set => areaCode = value;
        }
    }
}
