using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCare.Structure
{
    public class ServerManager
    {
        public static ITaskManager GetTaskManager
        {
            get
            {
                ITaskManager objTaskManager = new ServerObject();
                return objTaskManager;
            }
        }
    }
}
