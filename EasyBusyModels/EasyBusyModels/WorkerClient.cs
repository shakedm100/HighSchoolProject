using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class WorkerClient : Base
    {
        private int workerID;
        private int clientID;
        DateTime contactDate;

        public int WorkerID
        {
            get => workerID;
            set => workerID = value;
        }
        public int ClientID
        {
            get => clientID;
            set => clientID = value;
        }
        public DateTime ContactDate
        {
            get => contactDate;
            set => contactDate = value;
        }
    }
}
