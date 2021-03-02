using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCare.Structure
{
    public interface ITaskManager
    {
        object Execute(string methodName, object param);
    }
}
