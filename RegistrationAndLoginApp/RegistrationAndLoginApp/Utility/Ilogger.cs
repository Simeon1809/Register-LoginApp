using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Energy_Managers.Utility
{
    public interface Ilogger
    {
        void Debug(string message);
        void Warning(string message);
        void Info(string message);
        void Error(string message);


    }
}
