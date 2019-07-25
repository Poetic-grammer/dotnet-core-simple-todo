using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_To_Do.Settings
{
    public class DataSettings
    {
        public enum DataMode { SQL, InMemory }

        public DataMode Mode { get; set; }

    }
}
