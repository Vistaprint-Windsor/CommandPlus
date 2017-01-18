using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.yppiti.FileCommandProcessor.Functions.AppOnlyScope
{
    class Disposal
    {
        public static void RunCleanup()
        {
            GC.Collect();
        }
    }
}
