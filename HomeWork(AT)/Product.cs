using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_AT_
{
    [Serializable]
    public class Product
    {
        public int PID { get; set; }    
        public string PName { get; set; }
        public int Price { get; set; }  
        public string CategoryName { get; set; }
    }
}
