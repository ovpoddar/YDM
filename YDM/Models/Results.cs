using System;
using System.Collections.Generic;
using System.Text;

namespace YDM.Models
{
    class Results<T>
    {
        public string Exception { get; set; }
        public T Result { get; set; }
        public bool Success { get; set; }
    }
}
