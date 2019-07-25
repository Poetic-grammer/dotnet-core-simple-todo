using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_To_Do.Models
{
    public class ToDoItemModel
    {
        public int id { get; set; }

        public string label { get; set; }

        public bool completed { get; set; }
    }
}
